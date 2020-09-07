using NewTek;
using NewTek.NDI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;

namespace titler.Core {
	public abstract class NDI {

		public int Width { get; }
		public int Height { get; }
		public string Name { get; }
		public int FPS { get; }
		public bool Running { get; set; }

		public NDI(int width, int height, string name, int fps = 24) {
			Width = width;
			Height = height;
			Name = name;
			FPS = fps;
			Running = false;
		}

		public void Start() {
			Running = true;
			Task.Run(() => Run(this)).ConfigureAwait(false);
		}

		public abstract void Render(Graphics context, float dt);

		private static void Run(NDI ndi) {
			using (Sender sender = new Sender(ndi.Name, true, false, null, "NDI Titler")) {
				float aspect = (float)ndi.Width / ndi.Height;
				using (VideoFrame frame = new VideoFrame(ndi.Width, ndi.Height, aspect, ndi.FPS, 1)) {
					using (var surface = new Bitmap(frame.Width, frame.Height, frame.Stride, PixelFormat.Format32bppPArgb, frame.BufferPtr))
					using (var ctx = Graphics.FromImage(surface)) {
						ctx.SmoothingMode = SmoothingMode.HighQuality;
						ctx.InterpolationMode = InterpolationMode.HighQualityBicubic;
						ctx.TextRenderingHint = TextRenderingHint.AntiAlias;
						ctx.CompositingQuality = CompositingQuality.HighQuality;
						while (ndi.Running) {
							if (sender.GetConnections(10000) < 1) {
								Thread.Sleep(50);
							} else {
								var state = ctx.Save();
								ndi.Render(ctx, 1.0f / ndi.FPS);
								ctx.Restore(state);
								sender.Send(frame);
							}
						}
					}
				}
			}
		}

	}
}
