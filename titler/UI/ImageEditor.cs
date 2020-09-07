using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using titler.Titler;

namespace titler.UI {
	public partial class ImageEditor : UserControl {
		private ImageElement element;

		public ImageElement Element {
			get { return element; }
			set {
				element = value;
				if (element != null) {
					UpdateParams();
				}
			}
		}

		public Viewer Viewer { get; set; }

		private void UpdateParams() {
			btOpenImage.BackgroundImage = element.Image;

			nuX.Value = element.Source.X;
			nuY.Value = element.Source.Y;
			nuW.Value = element.Source.Width;
			nuH.Value = element.Source.Height;
		}

		public ImageEditor() {
			InitializeComponent();
		}

		private void nuX_ValueChanged(object sender, EventArgs e) {
			element.Source = new Rectangle((int)nuX.Value, element.Source.Y, element.Source.Width, element.Source.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuY_ValueChanged(object sender, EventArgs e) {
			element.Source = new Rectangle(element.Source.X, (int)nuY.Value, element.Source.Width, element.Source.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuW_ValueChanged(object sender, EventArgs e) {
			element.Source = new Rectangle(element.Source.X, element.Source.Y, (int)nuW.Value, element.Source.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuH_ValueChanged(object sender, EventArgs e) {
			element.Source = new Rectangle(element.Source.X, element.Source.Y, element.Source.Width, (int)nuH.Value);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void btOpenImage_Click(object sender, EventArgs e) {
			using (var ofd = new OpenFileDialog()) {
				ofd.Filter = "Images (*.jpg,*.jpeg,*.png,*.bmp) | *.jpg;*.jpeg;*.png;*.bmp";
				ofd.Title = "Open Image";
				if (ofd.ShowDialog() == DialogResult.OK) {
					element.Image = new Bitmap(ofd.FileName);
					element.Path = ofd.FileName;
					Viewer.Invalidate();
					Viewer.TriggerDataChange();
				}
			}
		}
	}
}
