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
	public partial class TextEditor : UserControl {
		private TextElement element;

		public TextElement Element {
			get { return element; }
			set {
				element = value;
				if (element != null) {
					UpdateParams();
				}
			}
		}

		public bool lockCombo = false;
		public Viewer Viewer { get; set; }
		public Title Title { get; set; }

		public TextEditor() {
			InitializeComponent();
		}

		private void UpdateParams() {
			btFill.BackColor = element.Fill;
			btFill.ForeColor = Color.FromArgb(255, 255 - element.Fill.R, 255 - element.Fill.G, 255 - element.Fill.B);
			btFill.Text = ColorTranslator.ToHtml(element.Fill).ToLower();

			txText.Text = element.Text;
			btSelectFont.Font = new Font(element.Font.Name, 10.0f, element.Font.Style);
			btSelectFont.Text = element.Font.Name + ", " + element.Font.SizeInPoints + "pt";

			lockCombo = true;
			cbHAlign.SelectedIndex = (int)element.HorizontalAlign;
			cbVAlign.SelectedIndex = (int)element.VerticalAlign;
			lockCombo = false;

			ckAutoSize.Checked = element.AutoSize;
		}

		private void TextEditor_Load(object sender, EventArgs e) {

		}

		private void btFill_Click(object sender, EventArgs e) {
			var cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				btFill.BackColor = element.Fill = cd.Color;
				btFill.Text = ColorTranslator.ToHtml(element.Fill).ToLower();
				btFill.ForeColor = Color.FromArgb(255, 255 - element.Fill.R, 255 - element.Fill.G, 255 - element.Fill.B);
				Viewer.Invalidate();
				Viewer.TriggerDataChange();
			}
		}

		private void txText_TextChanged(object sender, EventArgs e) {
			element.Text = txText.Text;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void btSelectFont_Click(object sender, EventArgs e) {
			var fd = new FontDialog();
			if (fd.ShowDialog() == DialogResult.OK) {
				btSelectFont.Font = new Font(fd.Font.Name, 10.0f, fd.Font.Style);
				btSelectFont.Text = btSelectFont.Font.Name + ", " + fd.Font.SizeInPoints + "pt";
				element.Font = fd.Font;
				Viewer.Invalidate();
				Viewer.TriggerDataChange();
			}
		}

		private void cbVAlign_SelectedIndexChanged(object sender, EventArgs e) {
			if (lockCombo) return;
			element.VerticalAlign = Enum.GetValues(typeof(Alignment)).Cast<Alignment>().ToArray()[cbVAlign.SelectedIndex];
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void cbHAlign_SelectedIndexChanged(object sender, EventArgs e) {
			if (lockCombo) return;
			element.HorizontalAlign = Enum.GetValues(typeof(Alignment)).Cast<Alignment>().ToArray()[cbHAlign.SelectedIndex];
			Viewer.Invalidate();
		}

		private void ckAutoSize_CheckedChanged(object sender, EventArgs e) {
			element.AutoSize = ckAutoSize.Checked;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void txText_KeyPress(object sender, KeyPressEventArgs e) {

		}

		private void txText_KeyDown(object sender, KeyEventArgs e) {
			element.Text = txText.Text;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}
	}
}
