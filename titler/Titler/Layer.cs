using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using titler.Core;

namespace titler.Titler {
	public class Layer {
		public Dictionary<string, Element> Elements { get; }
		public bool Visible { get; set; } = true;

		public Layer() {
			Elements = new Dictionary<string, Element>();
		}

		public List<string> ElementNames { get { return Elements.Keys.ToList(); } }

		public void AddElement(string name, Element el) {
			if (Elements.ContainsKey(name)) {
				name = "_" + name;
			}
			Elements.Add(name, el);
		}

		public void DeleteElement(string name) {
			if (!Elements.ContainsKey(name)) {
				return;
			}
			Elements.Remove(name);
		}

		public Element GetElement(string name) {
			if (!Elements.ContainsKey(name)) {
				return null;
			}
			return Elements[name];
		}

		public void Render(Graphics ctx, float dt) {
			if (!Visible) return;

			foreach (var el in Elements.Values.OrderBy(o => o.DrawOrder)) {
				if (!el.Visible) continue;
				el.RenderAll(ctx, dt);
			}
		}
	}
}
