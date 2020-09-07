using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace titler.Titler {
	public partial class Viewer : Control {

		private const int HandleSize = 8;
		private const int GridSize = 8;

		public Title Title { get; set; }

		private Point p1;

		private bool drag = false, keepAspect = false;
		private int handle = -1;

		public List<Element> Selected { get; }

		public delegate void ChangeEvent();
		public event ChangeEvent OnChange;

		public delegate void DataChangeEvent();
		public event DataChangeEvent OnDataChange;

		public Viewer() {
			InitializeComponent();
			Title = new Title();
			Selected = new List<Element>();

			SetStyle(
				ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true
			); ;
		}

		public void TriggerDataChange() {
			OnDataChange?.Invoke();
		}

		public void Select(string name) {
			if (name == null) {
				Selected.Clear();
				OnChange?.Invoke();
				Invalidate();
				return;
			}

			var el = Title.GetElement(name);
			if (el != null) {
				Selected.Clear();
				Selected.Add(el);
				OnChange?.Invoke();
				Invalidate();
			}
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			if ((e.Modifiers & Keys.Shift) == Keys.Shift)
				keepAspect = true;
		}

		protected override void OnKeyUp(KeyEventArgs e) {
			keepAspect = false;
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if (e.Button != MouseButtons.Left) return;

			Focus();

			drag = true;
			p1 = TransformPoint(e.Location, Title.Resolution, Size);

			var hith = false;
			if (Selected.Count > 0) {
				foreach (var el in Selected) {
					var sz = el.GetPreferredSize();
					var eb = new Rectangle(el.Bounds.X, el.Bounds.Y, sz.Width, sz.Height);
					eb.Inflate(HandleSize / 2 + 2, HandleSize / 2 + 2);

					var isTextAutoSize = el is TextElement && (el as TextElement).AutoSize;

					if (!isTextAutoSize) {
						var handles = GetHandles(eb);
						for (int i = 0; i < handles.Count; i++) {
							if (handles[i].Contains(p1)) {
								handle = i;
								hith = true;
								break;
							}
						}
					}
					if (hith) break;
				}
			}

			if (!hith) {
				var hitsmth = false;
				foreach (var el in Title.Elements.Values.OrderBy(o => o.DrawOrder).Reverse()) {
					if (!el.Visible) continue;

					var sz = el.GetPreferredSize();
					var eb = new Rectangle(el.Bounds.X, el.Bounds.Y, sz.Width, sz.Height);
					eb.Inflate(HandleSize + 2, HandleSize + 2);

					if (eb.Contains(p1)) {
						Selected.Clear();
						Selected.Add(el);
						hitsmth = true;

						var isTextAutoSize = el is TextElement && (el as TextElement).AutoSize;

						if (!isTextAutoSize) {
							eb.Inflate(-HandleSize / 2, -HandleSize / 2);
							var handles = GetHandles(eb);
							for (int i = 0; i < handles.Count; i++) {
								if (handles[i].Contains(p1)) {
									handle = i;
									break;
								}
							}
						}

						OnChange?.Invoke();

						break;
					}
				}

				if (!hitsmth) {
					Selected.Clear();
					OnChange?.Invoke();
				}
			}

			Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);
			if (e.Button != MouseButtons.Left) {
				drag = false;
				handle = -1;
				return;
			}

			if (drag && Selected.Count > 0) {
				var pt = TransformPoint(e.Location, Title.Resolution, Size);
				int dx = pt.X - p1.X;
				int dy = pt.Y - p1.Y;

				foreach (var el in Selected) {
					int x = el.Bounds.X,
						y = el.Bounds.Y,
						w = el.Bounds.Width,
						h = el.Bounds.Height;
					switch (handle) {
						default: x += dx; y += dy; break;
						case 0: x += dx; y += dy; w -= dx; h -= dy; break;
						case 7: w += dx; h += dy; break;
						case 1: y += dy; h -= dy; break;
						case 6: h += dy; break;
						case 2: y += dy; w += dx; h -= dy; break;
						case 5: x += dx; w -= dx; h += dy; break;
						case 3: x += dx; w -= dx; break;
						case 4: w += dx; break;
					}

					x = Math.Min(x + w, x);
					y = Math.Min(y + w, y);
					w = Math.Abs(w);
					h = Math.Abs(h);

					//if (keepAspect) {
					//	var img = el.GetPreferredSize();
					//	var rs = (float)w / h;
					//	var ri = (float)img.Width / img.Height;

					//	w = rs > ri ? (int)(img.Width * ((float)h / img.Height)) : w;
					//	h = rs > ri ? h : (int)(img.Height * ((float)w / img.Width));
					//}

					el.Bounds = new Rectangle(x, y, w, h);
					OnDataChange?.Invoke();
				}

				p1 = new Point(pt.X, pt.Y);

				Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			drag = false;
			handle = -1;
			OnChange?.Invoke();
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e) {
			var ctx = e.Graphics;

			ctx.SmoothingMode = SmoothingMode.HighQuality;
			ctx.InterpolationMode = InterpolationMode.HighQualityBicubic;
			ctx.TextRenderingHint = TextRenderingHint.AntiAlias;
			ctx.CompositingQuality = CompositingQuality.HighQuality;

			var state = ctx.Save();
			var loc = GetViewLocation(Title.Resolution, Size);
			var zoom = GetZoom(Title.Resolution, Size);
			ctx.TranslateTransform(loc.X, loc.Y);
			ctx.ScaleTransform(zoom, zoom);
			
			ctx.Clip = new Region(new Rectangle(Point.Empty, Title.Resolution));
			// bg
			var cols = (Title.Resolution.Width+16) / 16;
			var rows = (Title.Resolution.Height+16) / 16;
			ctx.FillRectangle(Brushes.White, new Rectangle(Point.Empty, Title.Resolution));
			for (var c = 0; c < cols; c++) {
				for (var r = 0; r < rows; r++) {
					if (r % 2 == 0 && c % 2 == 1 || r % 2 == 1 && c % 2 == 0) {
						ctx.FillRectangle(Brushes.LightGray, new Rectangle(c * 16, r * 16, 16, 16));
					}
				}
			}
			ctx.DrawRectangle(Pens.Black, new Rectangle(0, 0, Title.Resolution.Width-2, Title.Resolution.Height-2));

			Title?.Render(ctx, 0.0f);

			var dashPen = new Pen(Color.Black);
			dashPen.DashStyle = DashStyle.Dash;

			foreach (var el in Selected) {
				var sz = el.GetPreferredSize();
				var eb = new Rectangle(el.Bounds.X, el.Bounds.Y, sz.Width, sz.Height);
				eb.Inflate(HandleSize / 2, HandleSize / 2);

				ctx.DrawRectangle(Pens.White, eb);
				ctx.DrawRectangle(dashPen, eb);

				var isTextAutoSize = el is TextElement && (el as TextElement).AutoSize;
				if (!isTextAutoSize) {
					foreach (var h in GetHandles(eb)) {
						ctx.FillRectangle(Brushes.CornflowerBlue, h);
						ctx.DrawRectangle(Pens.Black, h);
					}
				}
			}

			ctx.Restore(state);
		}

		public static float GetZoom(Size resolution, Size view) {
			var rx = view.Width / (float)resolution.Width;
			var ry = view.Height / (float)resolution.Height;
			return rx > ry ? ry : rx;
		}

		public static Point GetViewLocation(Size resolution, Size view) {
			var z = GetZoom(resolution, view);
			var w = resolution.Width * z;
			var h = resolution.Height * z;
			return new Point((int)(view.Width / 2 - w / 2), (int)(view.Height / 2 - h / 2));
		}

		private Point TransformPoint(Point p, Size resolution, Size view) {
			var z = GetZoom(resolution, view);
			var vl = GetViewLocation(Title.Resolution, Size);
			return new Point((int)((p.X - vl.X) / z), (int)((p.Y - vl.Y) / z));
		}

		private List<Rectangle> GetHandles(Rectangle b) {
			var zoom = GetZoom(Title.Resolution, Size);
			var h = (int)((HandleSize / 2) / zoom);
			var ret = new List<Rectangle>();
			ret.Add(new Rectangle(b.X - h, b.Y - h, h * 2, h * 2));
			ret.Add(new Rectangle(b.X - h + b.Width / 2, b.Y - h, h * 2, h * 2));
			ret.Add(new Rectangle(b.X - h + b.Width, b.Y - h, h * 2, h * 2));

			ret.Add(new Rectangle(b.X - h, b.Y - h + b.Height / 2, h * 2, h * 2));
			ret.Add(new Rectangle(b.X - h + b.Width, b.Y - h + b.Height / 2, h * 2, h * 2));

			ret.Add(new Rectangle(b.X - h, b.Y - h + b.Height, h * 2, h * 2));
			ret.Add(new Rectangle(b.X - h + b.Width / 2, b.Y - h + b.Height, h * 2, h * 2));
			ret.Add(new Rectangle(b.X - h + b.Width, b.Y - h + b.Height, h * 2, h * 2));
			return ret;
		}
	}
}
