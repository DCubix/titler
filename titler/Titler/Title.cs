﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
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
	}
}
