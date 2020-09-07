using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace titler.Titler {

	public struct Link {
		public Element Element { get; set; }
		public string Property { get; set; }
	}

	public class Title {
		[Browsable(false)]
		public Dictionary<string, Element> Elements { get; }

		[Browsable(false)]
		public Dictionary<string, string> Variables { get; }

		[Browsable(false)]
		public Dictionary<string, Link> VariableLinks { get; }

		[Browsable(false)]
		public List<string> AvailableVariables {
			get {
				return Variables.Keys.Where(e => !VariableLinks.ContainsKey(e)).ToList();
			}
		}

		[Category("Output")]
		[Description("Output Resolution")]
		public Size Resolution { get; set; }

		public Title() {
			Elements = new Dictionary<string, Element>();
			Variables = new Dictionary<string, string>();
			VariableLinks = new Dictionary<string, Link>();
			Resolution = new Size(1920, 1080);
		}

		[Browsable(false)]
		public List<Element> ElementList {
			get {
				return Elements.Values.ToList();
			}
		}

		[Browsable(false)]
		public List<string> ElementNames {
			get {
				return Elements.Keys.ToList();
			}
		}

		public void LinkVariable(Element element, string variable, string property) {
			var lnk = new Link();
			lnk.Element = element;
			lnk.Property = property;
			VariableLinks.Add(variable, lnk);
		}

		public void UnlinkVariable(string name) {
			if (!VariableLinks.ContainsKey(name)) return;
			VariableLinks.Remove(name);
		}

		public void UnlinkVariable(Element element, string property) {
			var vname = "";
			foreach (var vl in VariableLinks) {
				if (vl.Value.Element == element && vl.Value.Property == property) {
					vname = vl.Key;
				}
			}
			UnlinkVariable(vname);
		}

		public Element GetElement(string name) {
			if (!Elements.ContainsKey(name)) return null;
			return Elements[name];
		}

		public string GetName(Element el) {
			foreach (var e in Elements) {
				if (e.Value == el) return e.Key;
			}
			return null;
		}

		private string GenName(string name) {
			if (!Elements.ContainsKey(name)) return name;

			var i = 0;
			while (Elements.ContainsKey(name + i)) {
				i++;
			}
			return name + i;
		}

		public Element AddElement(string name, Element el) {
			name = GenName(name);
			Elements.Add(name, el);
			return el;
		}

		public string RenameElement(string oldName, string name) {
			if (!Elements.ContainsKey(oldName)) return null;
			var el = Elements[oldName];
			Elements.Remove(oldName);
			name = GenName(name);
			Elements.Add(name, el);
			return name;
		}

		public void SetOrder(string name, int order) {
			if (!Elements.ContainsKey(name)) return;
			Elements[name].DrawOrder = order;
		}

		public void DeleteElement(string name) {
			if (!ElementNames.Contains(name)) return;
			Elements.Remove(name);
		}

		public void Render(Graphics ctx, float dt) {
			// link vars
			foreach (var link in VariableLinks) {
				var value = Variables[link.Key];
				var lnk = link.Value;

				var prop = lnk.Element.GetType().GetProperty(lnk.Property);
				if (prop != null && prop.CanWrite) {
					prop.SetValue(lnk.Element, value);
				}
			}

			foreach (var el in Elements.Values.OrderBy(o => o.DrawOrder)) {
				if (!el.Visible) continue;

				var st = ctx.Save();
				el.RenderAll(ctx, dt);
				ctx.Restore(st);
			}
		}

		public Bitmap GetPreview() {
			using (var bmp = new Bitmap(Resolution.Width, Resolution.Height))
			using (var g = Graphics.FromImage(bmp))
			{
				var state = g.Save();
				var cols = (Resolution.Width + 16) / 16;
				var rows = (Resolution.Height + 16) / 16;
				g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, Resolution));
				for (var c = 0; c < cols; c++) {
					for (var r = 0; r < rows; r++) {
						if (r % 2 == 0 && c % 2 == 1 || r % 2 == 1 && c % 2 == 0) {
							g.FillRectangle(Brushes.LightGray, new Rectangle(c * 16, r * 16, 16, 16));
						}
					}
				}
				g.Restore(state);

				Render(g, 0.0f);
				return bmp;
			}
		}

		public void LoadFromFile(string fileName) {
			JObject ob = JObject.Parse(File.ReadAllText(fileName));

			if (ob.ContainsKey("resolution")) {
				Resolution = new Size(
					(int)ob["resolution"][0],
					(int)ob["resolution"][1]
				);
			}

			// Read elements
			JArray elems = (JArray)ob["elements"];
			foreach (var job in elems.Cast<JObject>()) {
				var type = (string)job["type"];
				Element el = type switch
				{
					"RectangleElement" => new RectangleElement().FromJson(job),
					"TextElement" => new TextElement().FromJson(job),
					"ImageElement" => new ImageElement().FromJson(job),
					_ => null
				};

				if (el == null) continue;
				AddElement((string)job["name"], el);
			}

			// Read clippers and autofitters
			JArray links = (JArray)ob["links"];
			foreach (var job in links.Cast<JObject>()) {
				var efor = GetElement((string)job["for"]);
				var el = GetElement((string)job["element"]);
				var type = (string)job["type"];
				if (type == "Clipper") {
					efor.Clipper = el;
				} else if (type == "AutoFit") {
					efor.AutoFit = el;
				}
			}

			// Read variables
			JObject vars = (JObject)ob["variables"];
			foreach (var ve in vars) {
				Variables[ve.Key] = "";
			}

			// Link variables
			JObject vlinks = (JObject)ob["variableLinks"];
			foreach (var ve in vlinks) {
				var lnk = (JObject) ve.Value;
				var link = new Link();
				link.Element = GetElement((string)lnk["element"]);
				link.Property = (string)lnk["property"];
				VariableLinks[ve.Key] = link;
			}
		}

		public void SaveToFile(string fileName) {
			JObject ob = new JObject();

			// Save elements
			JArray elems = new JArray();
			foreach (var e in Elements) {
				var el = e.Value.ToJson();
				el["name"] = e.Key;
				elems.Add(el);
			}

			// Clippers and AutoFitters
			JArray links = new JArray();
			foreach (var e in Elements) {
				if (e.Value.Clipper == null) continue;
				var lnk = new JObject();
				lnk["type"] = "Clipper";
				lnk["for"] = GetName(e.Value);
				lnk["element"] = GetName(e.Value.Clipper);
				links.Add(lnk);
			}

			foreach (var e in Elements) {
				if (e.Value.AutoFit == null) continue;
				var lnk = new JObject();
				lnk["type"] = "AutoFit";
				lnk["for"] = GetName(e.Value);
				lnk["element"] = GetName(e.Value.AutoFit);
				links.Add(lnk);
			}

			// Variables
			JObject vars = new JObject();
			foreach (var e in Variables) {
				vars[e.Key] = e.Value;
			}

			// Variable Links
			JObject vlinks = new JObject();
			foreach (var e in VariableLinks) {
				var lnk = new JObject();
				lnk["element"] = GetName(e.Value.Element);
				lnk["property"] = e.Value.Property;
				vlinks[e.Key] = lnk;
			}

			// Assemble
			ob["elements"] = elems;
			ob["links"] = links;
			ob["variables"] = vars;
			ob["variableLinks"] = vlinks;
			ob["resolution"] = new JArray(Resolution.Width, Resolution.Height);

			using (var sw = new StreamWriter(fileName)) {
				sw.Write(ob.ToString(Newtonsoft.Json.Formatting.Indented));
			}
		}
	}
}
