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

	public class Title {
		[Browsable(false)]
		public Dictionary<string, Element> Elements { get; }

		[Category("Output")]
		[Description("Output Resolution")]
		public Size Resolution { get; set; }

		public Title() {
			Elements = new Dictionary<string, Element>();
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

		[Browsable(false)]
		public bool Shown { get; set; }

		public void Show() {
			Shown = true;
			foreach (var el in Elements) el.Value.Show();
		}

		public void Hide() {
			foreach (var el in Elements) el.Value.Hide();
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
			Shown = false;
			foreach (var el in ElementList) {
				if (el.State != ElementState.Hidden) {
					Shown = true;
					break;
				}
			}

			foreach (var el in Elements.Values.OrderBy(o => o.DrawOrder)) {
				if (!el.Visible) continue;

				var st = ctx.Save();
				el.RenderAll(ctx, dt);
				ctx.Restore(st);
			}
		}

		public Bitmap GetPreview(Size sz) {
			var loc = Viewer.GetViewLocation(Resolution, sz);
			var zoom = Viewer.GetZoom(Resolution, sz);

			var bmp = new Bitmap(sz.Width, sz.Height);
			using (var g = Graphics.FromImage(bmp))
			{
				g.TranslateTransform(loc.X, loc.Y);
				g.ScaleTransform(zoom, zoom);
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

				Render(g, 1.0f);
				Render(g, 1.0f);
			}
			return bmp;
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

			foreach (var el in ElementList) {
				el.Reset();
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

			// Assemble
			ob["elements"] = elems;
			ob["links"] = links;
			ob["resolution"] = new JArray(Resolution.Width, Resolution.Height);

			using (var sw = new StreamWriter(fileName)) {
				sw.Write(ob.ToString(Newtonsoft.Json.Formatting.Indented));
			}
		}
	}
}
