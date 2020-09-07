using Newtonsoft.Json.Linq;
using Plasmoid.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using titler.Core;

namespace titler.Titler {
	public static class MathUtil {
		public static double Lerp(double a, double b, double t) {
			return (1.0 - t) * a + b * t;
		}
	}

	public enum AnimationState {
		Idle,
		Waiting,
		Running,
		Finished
	}

	public enum Easing {
		Linear = 0,
		InCubic,
		OutCubic,
		InOutCubic
	}

	public abstract class Animation {
		public static Func<double, double>[] EasingFuncs = {
			(t) => t,
			(t) => t * t * t,
			(t) => (--t) * t * t + 1.0,
			(t) => {
				double k = 2.0 * t - 2.0;
				return t < 0.5 ? 4.0 * t * t * t : (t - 1.0) * k * k + 1.0;
			}
		};

		[Browsable(false)]
		public double Time { get; set; }

		[Browsable(false)]
		public double Value { get; set; }

		public double Delay { get; set; }
		public double Duration { get; set; }
		public Easing EasingFunction { get; set; }

		[Browsable(false)]
		public AnimationState State { get; set; }

		[Browsable(false)]
		public bool Reverse { get; set; }

		public Animation() {
			Time = 0.0f;
			Value = 0.0f;
			Delay = 0.0f;
			Duration = 1.0f;
			State = AnimationState.Idle;
			EasingFunction = Easing.Linear;
			Reverse = false;
		}

		public virtual JObject ToJson() {
			JObject ob = new JObject();
			ob["delay"] = Delay;
			ob["duration"] = Duration;
			ob["easing"] = (int)EasingFunction;
			return ob;
		}

		public virtual Animation FromJson(JObject ob) {
			Delay = ob["delay"].Value<float>();
			Duration = ob["duration"].Value<float>();
			EasingFunction = (Easing)ob["easing"].Value<int>();
			return this;
		}

		public void Play(bool reverse) {
			Time = 0.0f;
			State = AnimationState.Waiting;
			Reverse = reverse;
		}

		public void Reset() {
			State = AnimationState.Idle;
			Time = 0.0f;
		}

		public abstract void Apply(ref AnimatableProperties props);

		public void Update(float dt) {
			switch (State) {
				case AnimationState.Waiting: {
					Time += dt;
					if (Time >= Delay) {
						Time = 0.0f;
						State = AnimationState.Running;
					}
				} break;
				case AnimationState.Running: {
					var v = Time / Duration;
					Value = EasingFuncs[(int)EasingFunction](Reverse ? 1.0f - v : v);
					Time += dt;
					if (Time >= Duration) {
						Time = 0.0f;
						State = AnimationState.Finished;
					}
				} break;
				default: break;
			}
		}
	}

	public struct AnimatableProperties {
		public Rectangle TargetBounds { get; set; }
		public Rectangle Bounds { get; set; }

		public float TargetOpacity { get; set; }
		public float Opacity { get; set; }

		public float TargetZoom { get; set; }
		public float Zoom { get; set; }
	}

	public abstract class Element {
		public const float MaxZoom = 0.2f;

		public Element AutoFit { get; set; }
		public Element Clipper { get; set; }

		public Rectangle Bounds { get; set; }

		public int[] Margin { get; }
		public int DrawOrder { get; set; } = 0;

		public float Opacity { get; set; } = 1.0f;
		public bool Visible { get; set; } = true;

		public Animation InAnimation { get; set; }
		public Animation OutAnimation { get; set;  }

		private AnimatableProperties props = new AnimatableProperties();
		public AnimatableProperties AnimatableProperties { get { return props; } }

		protected Animation ActiveAnimation {
			get {
				Animation ain = InAnimation, aout = OutAnimation;
				if (ain != null && ain.State != AnimationState.Finished && ain.State != AnimationState.Idle) {
					return ain;
				} else if (aout != null && aout.State != AnimationState.Finished && aout.State != AnimationState.Idle) {
					return aout;
				}
				return null;
			}
		}

		public Element() {
			AutoFit = null;
			Clipper = null;
			Bounds = new Rectangle(0, 0, 100, 100);
			Margin = new int[] { 10, 10, 10, 10 };
		}

		public abstract void Render(Graphics ctx, float dt);

		public virtual Size GetPreferredSize() {
			return Bounds.Size;
		}

		protected virtual void SaveProperties() {
			var sz = GetPreferredSize();
			props.Bounds = new Rectangle(Bounds.X, Bounds.Y, sz.Width, sz.Height);
			props.TargetBounds = new Rectangle(Bounds.X, Bounds.Y, sz.Width, sz.Height);
			props.Opacity = Opacity;
			props.TargetOpacity = Opacity;
			props.TargetZoom = MaxZoom;
			props.Zoom = 0.0f;
		}

		public virtual GraphicsPath GetClipPath(Graphics ctx, Rectangle bounds) {
			bounds = bounds.IsEmpty ? Bounds : bounds;
			var gp = new GraphicsPath();
			gp.AddRectangle(bounds);
			return gp;
		}

		public virtual JObject ToJson() {
			JObject ob = new JObject();
			ob["bounds"] = new JArray(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
			ob["margin"] = new JArray(Margin);
			ob["drawOrder"] = DrawOrder;
			ob["opacity"] = Opacity;
			ob["visible"] = Visible;
			if (InAnimation != null)
				ob["in"] = InAnimation.ToJson();
			if (OutAnimation != null)
				ob["out"] = OutAnimation.ToJson();
			return ob;
		}

		public virtual Element FromJson(JObject ob) {
			Bounds = new Rectangle(
				ob["bounds"][0].Value<int>(),
				ob["bounds"][1].Value<int>(),
				ob["bounds"][2].Value<int>(),
				ob["bounds"][3].Value<int>()
			);
			Margin[0] = ob["margin"][0].Value<int>();
			Margin[1] = ob["margin"][1].Value<int>();
			Margin[2] = ob["margin"][2].Value<int>();
			Margin[3] = ob["margin"][3].Value<int>();
			DrawOrder = ob["drawOrder"].Value<int>();
			Opacity = ob["opacity"].Value<float>();
			Visible = ob["visible"].Value<bool>();

			if (ob.ContainsKey("in")) {
				JObject ani = (JObject)ob["in"];
				var type = (string) ani["type"];
				var ael = type switch
				{
					"Fade" => new Fade().FromJson(ani),
					"Reveal" => new Reveal().FromJson(ani),
					_ => null
				};
				InAnimation = ael;
			}

			if (ob.ContainsKey("out")) {
				JObject ani = (JObject)ob["out"];
				var type = (string)ani["type"];
				var ael = type switch
				{
					"Fade" => new Fade().FromJson(ani),
					"Reveal" => new Reveal().FromJson(ani),
					_ => null
				};
				OutAnimation = ael;
			}

			return this;
		}

		public void Show() {
			ActiveAnimation?.Reset();
			SaveProperties();
			InAnimation?.Play(false);
			InAnimation?.Update(1.0f/24);
		}

		public void Hide() {
			ActiveAnimation?.Reset();
			SaveProperties();
			OutAnimation?.Play(true);
			OutAnimation?.Update(0.0f);
		}

		public bool AnimationPlaying {
			get {
				return ActiveAnimation != null && ActiveAnimation.State != AnimationState.Finished && ActiveAnimation.State != AnimationState.Idle;
			}
		}

		public void RenderAll(Graphics ctx, float dt) {
			var state = ctx.Save();

			if (AutoFit != null) {
				var sz = AutoFit.GetPreferredSize();
				Bounds = new Rectangle(
					AutoFit.Bounds.X - Margin[0],
					AutoFit.Bounds.Y - Margin[1],
					sz.Width + Margin[0] + Margin[2],
					sz.Height + Margin[1] + Margin[3]
				);
			}

			Animation ain = InAnimation, aout = OutAnimation;
			if (ain != null && ain.State != AnimationState.Finished && ain.State != AnimationState.Idle) {
				aout?.Reset();
				ain.Apply(ref props);
				ain.Update(dt);
			} else if (aout != null && aout.State != AnimationState.Finished && aout.State != AnimationState.Idle) {
				ain?.Reset();
				aout.Apply(ref props);
				aout.Update(dt);
			}

			if (Clipper != null) {
				GraphicsPath gp;
				if (Clipper is RectangleElement) {
					var c = Clipper as RectangleElement;
					gp = c.GetClipPath(ctx, Rectangle.Empty);
				} else {
					gp = new GraphicsPath();
					gp.AddRectangle(Clipper.Bounds);
				}
				ctx.Clip = new Region(gp);
			}
			Render(ctx, dt);
			ctx.Restore(state);
		}
	}

	public enum RevealDirection {
		FromLeft,
		FromRight,
		FromTop,
		FromBottom
	}

	public class Reveal : Animation {
		public RevealDirection Direction { get; set; } = RevealDirection.FromLeft;

		public override JObject ToJson() {
			var ob = base.ToJson();
			ob["type"] = "Reveal";
			ob["direction"] = (int)Direction;
			return ob;
		}

		public override Animation FromJson(JObject ob) {
			var el = base.FromJson(ob) as Reveal;
			el.Direction = (RevealDirection) ob["direction"].Value<int>();
			return el;
		}

		public override void Apply(ref AnimatableProperties props) {
			var bounds = props.TargetBounds;
			var b = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			switch (Direction) {
				case RevealDirection.FromLeft: {
					b.Width = (int)MathUtil.Lerp(0.0, bounds.Width, Value);
				}
				break;
				case RevealDirection.FromRight: {
					double x = MathUtil.Lerp(bounds.X, bounds.X + bounds.Width, 1.0f - Value);
					double w = MathUtil.Lerp(0.0, bounds.Width, Value);
					b.X = (int)x;
					b.Width = (int)w;
				}
				break;
				case RevealDirection.FromTop: {
					b.Height = (int)MathUtil.Lerp(0.0, bounds.Height, Value);
				}
				break;
				case RevealDirection.FromBottom: {
					double y = MathUtil.Lerp(bounds.Y, bounds.Y + bounds.Height, 1.0f - Value);
					double h = MathUtil.Lerp(0.0, bounds.Height, Value);
					b.Y = (int)y;
					b.Height = (int)h;
				}
				break;
			}
			props.Bounds = b;
		}
	}

	public enum FadeDirection {
		In,
		Out
	}

	public class Fade : Animation {
		public FadeDirection Direction { get; set; } = FadeDirection.In;

		public override JObject ToJson() {
			var ob = base.ToJson();
			ob["type"] = "Fade";
			ob["direction"] = (int)Direction;
			return ob;
		}

		public override Animation FromJson(JObject ob) {
			var el = base.FromJson(ob) as Fade;
			el.Direction = (FadeDirection)ob["direction"].Value<int>();
			return el;
		}

		public override void Apply(ref AnimatableProperties props) {
			if (Direction == FadeDirection.In) {
				props.Opacity = (float)MathUtil.Lerp(0.0f, props.TargetOpacity, Value);
			} else {
				props.Opacity = (float)MathUtil.Lerp(0.0f, props.TargetOpacity, 1.0f - Value);
			}
		}

	}

	public class RectangleElement : Element {
		public Color Fill { get; set; } = Color.Black;
		public int BorderRadius { get; set; } = 0;
		public RectangleEdgeFilter EdgeFilter { get; set; } = RectangleEdgeFilter.None;

		public override GraphicsPath GetClipPath(Graphics ctx, Rectangle bounds) {
			if (bounds.IsEmpty) return base.GetClipPath(ctx, bounds);
			return GraphicsExtension.GenerateRoundedRectangle(ctx, bounds, BorderRadius, EdgeFilter);
		}

		public override JObject ToJson() {
			var ob = base.ToJson();
			ob["type"] = "RectangleElement";
			ob["fill"] = new JArray(Fill.R, Fill.G, Fill.B, Fill.A);
			ob["borderRadius"] = BorderRadius;
			ob["edgeFilter"] = (int)EdgeFilter;
			return ob;
		}

		public override Element FromJson(JObject ob) {
			var el = base.FromJson(ob) as RectangleElement;
			el.Fill = Color.FromArgb(
				ob["fill"][3].Value<int>(),
				ob["fill"][0].Value<int>(),
				ob["fill"][1].Value<int>(),
				ob["fill"][2].Value<int>()
			);
			el.BorderRadius = ob["borderRadius"].Value<int>();
			el.EdgeFilter = (RectangleEdgeFilter) ob["edgeFilter"].Value<int>();
			return el;
		}

		public override void Render(Graphics ctx, float dt) {
			var state = ctx.Save();

			var baseOp = Fill.A / 255.0f;

			var anim = ActiveAnimation;
			var clipping = false;
			var opacity = (int)(Opacity * 255.0f * baseOp);

			Rectangle clipBounds = Rectangle.Empty;

			if (anim != null) {
				if (anim is Reveal) {
					clipBounds = AnimatableProperties.Bounds;
					clipping = true;
				} else if (anim is Fade) {
					opacity = (int)(AnimatableProperties.Opacity * 255.0f * baseOp);
				}
			}

			opacity = Math.Max(0, Math.Min(opacity, 255));
			var sb = new SolidBrush(Color.FromArgb(opacity, Fill));

			var clip = new Region(Bounds);
			if (clipping) {
				clip.Intersect(GetClipPath(ctx, clipBounds));
			}

			if (Clipper != null) {
				if (!clipping)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.Bounds));
				else
					clip.Intersect(Clipper.Bounds);

				if (Clipper.AnimationPlaying)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.AnimatableProperties.Bounds));
			}

			ctx.Clip = clip;
			ctx.FillRoundedRectangle(sb, Bounds, BorderRadius, EdgeFilter);

			ctx.Restore(state);
		}

	}

	public enum Alignment {
		Near = 0,
		Center,
		Far
	}

	public class TextElement : Element {

		class Line {
			public string Text;
			public float Width, Height;
		}

		public Color Fill { get; set; } = Color.Black;

		public string Text { get; set; } = "Text";

		public Font Font { get; set; } = new Font("Arial", 36.0f);
		public Alignment HorizontalAlign { get; set; } = Alignment.Near;
		public Alignment VerticalAlign { get; set; } = Alignment.Near;
		public bool AutoSize { get; set; } = false;

		private Size preferredSize = new Size();

		public override JObject ToJson() {
			var ob = base.ToJson();
			ob["type"] = "TextElement";
			ob["fill"] = new JArray(Fill.R, Fill.G, Fill.B, Fill.A);
			ob["font"] = new JArray(Font.FontFamily.Name, Font.Size, (int)Font.Style);
			ob["halign"] = (int)HorizontalAlign;
			ob["valign"] = (int)VerticalAlign;
			ob["autoSize"] = AutoSize;
			ob["text"] = Text;
			return ob;
		}

		public override Element FromJson(JObject ob) {
			var el = base.FromJson(ob) as TextElement;
			el.Fill = Color.FromArgb(
				ob["fill"][3].Value<int>(),
				ob["fill"][0].Value<int>(),
				ob["fill"][1].Value<int>(),
				ob["fill"][2].Value<int>()
			);
			el.Font = new Font(
				ob["font"][0].Value<string>(),
				ob["font"][1].Value<float>(),
				(FontStyle) ob["font"][2].Value<int>()
			);
			el.HorizontalAlign = (Alignment)ob["halign"].Value<int>();
			el.VerticalAlign = (Alignment)ob["valign"].Value<int>();
			el.AutoSize = ob["autoSize"].Value<bool>();
			el.Text = ob["text"].Value<string>();
			return el;
		}

		public override Size GetPreferredSize() {
			return AutoSize ? preferredSize : base.GetPreferredSize();
		}

		public override void Render(Graphics ctx, float dt) {
			var state = ctx.Save();

			var sf = new StringFormat();

			var baseOp = Fill.A / 255.0f;

			var anim = ActiveAnimation;
			var clipping = false;
			var opacity = (int)(Opacity * 255.0f * baseOp);

			Rectangle clipBounds = Rectangle.Empty;

			if (anim != null) {
				if (anim is Reveal) {
					clipBounds = AnimatableProperties.Bounds;
					clipping = true;
				} else if (anim is Fade) {
					opacity = (int)(AnimatableProperties.Opacity * 255.0f * baseOp);
				}
			}

			opacity = Math.Max(0, Math.Min(opacity, 255));
			var sb = new SolidBrush(Color.FromArgb(opacity, Fill));

			switch (HorizontalAlign) {
				case Alignment.Near: sf.Alignment = StringAlignment.Near; break;
				case Alignment.Center: sf.Alignment = StringAlignment.Center; break;
				case Alignment.Far: sf.Alignment = StringAlignment.Far; break;
			}

			switch (VerticalAlign) {
				case Alignment.Near: sf.LineAlignment = StringAlignment.Near; break;
				case Alignment.Center: sf.LineAlignment = StringAlignment.Center; break;
				case Alignment.Far: sf.LineAlignment = StringAlignment.Far; break;
			}


			var sz = GetPreferredSize();

			var clip = new Region(new Rectangle(Bounds.Location, sz));
			if (clipping) {
				clip.Intersect(clipBounds);
			}

			if (Clipper != null) {
				if (!clipping)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.Bounds));
				else
					clip.Intersect(Clipper.Bounds);

				if (Clipper.AnimationPlaying)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.AnimatableProperties.Bounds));
			}

			preferredSize = ctx.MeasureString(Text, Font).ToSize();

			ctx.Clip = clip;

			//List<Line> lines = GetLines(ctx);
			//var boxHeight = lines.Select(l => l.Height).Aggregate((a, b) => a + b);
			//var boxWidth = 0.0;
			//foreach (var line in lines) boxWidth = Math.Max(boxWidth, line.Width);

			//float y = Bounds.Height / 2.0f;
			//switch (VerticalAlign) {
			//	case Alignment.Near: y += 0; break;
			//	case Alignment.Center: y += (Bounds.Height / 2 - boxHeight / 2); break;
			//	case Alignment.Far: y += (Bounds.Height - boxHeight); break;
			//}

			ctx.DrawString(Text, Font, sb, new RectangleF(Bounds.X, Bounds.Y, sz.Width, sz.Height), sf);
			//foreach (var line in lines) {
			//	float x = Bounds.Width / 2.0f;
			//	//switch (HorizontalAlign) {
			//	//	case Alignment.Near: x = 0; break;
			//	//	case Alignment.Center: x = (Bounds.Width / 2 - line.Width / 2); break;
			//	//	case Alignment.Far: x = (Bounds.Width - line.Width); break;
			//	//}

			//	ctx.DrawString(line.Text, Font, sb, x + Bounds.X, y + Bounds.Y);

			//	y += line.Height;
			//}

			ctx.Restore(state);
		}

		private List<Line> GetLines(Graphics ctx) {
			List<Line> lines = new List<Line>();
			var spl = Text.Split(' ', '\n');
			var currentLine = spl[0];
			for (int i = 1; i < spl.Length; i++) {
				var word = spl[i];
				var width = ctx.MeasureString(currentLine + "  " + word, Font).Width;
				if (width < Bounds.Width) {
					currentLine += "  " + word;
				} else {
					var ext = ctx.MeasureString(currentLine, Font);
					var ln = new Line();
					ln.Text = currentLine;
					ln.Width = ext.Width;
					ln.Height = ext.Height;
					lines.Add(ln);
					currentLine = word;
				}
			}

			var ext2 = ctx.MeasureString(currentLine, Font);
			var ln2 = new Line();
			ln2.Text = currentLine;
			ln2.Width = ext2.Width;
			ln2.Height = ext2.Height;
			lines.Add(ln2);
			return lines;
		}
	}

	public class ImageElement : Element {
		private Image image;

		public Image Image {
			get {
				return image;
			}
			set {
				image = value;
				Source = new Rectangle(0, 0, image.Width, image.Height);
				Bounds = new Rectangle(Bounds.X, Bounds.Y, image.Width, image.Height);
			}
		}
		public Rectangle Source { get; set; }
		public string Path { get; set; } = "";

		public ImageElement() : base() {
			Source = new Rectangle(0, 0, 1, 1);
		}

		public override JObject ToJson() {
			var ob = base.ToJson();
			ob["type"] = "ImageElement";
			ob["source"] = new JArray(Source.X, Source.Y, Source.Width, Source.Height);
			ob["path"] = Path;
			return ob;
		}

		public override Element FromJson(JObject ob) {
			var el = base.FromJson(ob) as ImageElement;
			var path = ob["path"].Value<string>();
			if (!File.Exists(path)) {
				if (MessageBox.Show("The file \"" + path + "\" doesn't exist. Do you want to search for it?", "Warning") == DialogResult.Yes) {
					using (var ofd = new OpenFileDialog()) {
						ofd.Filter = "Images (*.jpg,*.jpeg,*.png,*.bmp) | *.jpg;*.jpeg;*.png;*.bmp";
						ofd.Title = "Open Image";
						if (ofd.ShowDialog() == DialogResult.OK) {
							path = ofd.FileName;
						}
					}
				} else {
					path = "";
				}
			}
			el.Path = path;
			el.Image = new Bitmap(path);
			el.Source = new Rectangle(
				ob["source"][0].Value<int>(),
				ob["source"][1].Value<int>(),
				ob["source"][2].Value<int>(),
				ob["source"][3].Value<int>()
			);
			return el;
		}

		public override void Render(Graphics ctx, float dt) {

			var state = ctx.Save();

			var anim = ActiveAnimation;
			var opacity = Opacity;
			var clipping = false;

			Rectangle clipBounds = Rectangle.Empty;

			if (anim != null) {
				if (anim is Reveal) {
					clipBounds = AnimatableProperties.Bounds;
					clipping = true;
				} else if (anim is Fade) {
					opacity = AnimatableProperties.Opacity;
				}
			}

			opacity = Math.Max(0.0f, Math.Min(opacity, 1.0f));

			ColorMatrix colormatrix = new ColorMatrix();
			colormatrix.Matrix33 = opacity;

			ImageAttributes attr = new ImageAttributes();
			attr.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			var clip = new Region(Bounds);
			if (clipping) {
				clip.Intersect(clipBounds);
			}

			if (Clipper != null) {
				if (!clipping)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.Bounds));
				else
					clip.Intersect(Clipper.Bounds);

				if (Clipper.AnimationPlaying)
					clip.Intersect(Clipper.GetClipPath(ctx, Clipper.AnimatableProperties.Bounds));
			}

			ctx.Clip = clip;
			if (Image != null)
				ctx.DrawImage(Image, new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height), Source.X, Source.Y, Source.Width, Source.Height, GraphicsUnit.Pixel, attr);
			else
				ctx.FillRectangle(Brushes.Magenta, Bounds);

			ctx.Restore(state);
		}
	}

}
