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
	public partial class ElementEditor : UserControl {
		private Element element;
		private Title title;

		public Element Element {
			get { return element; }
			set {
				element = value;
				if (element != null) {
				}
			}
		}

		public Title Title {
			get { return title; }
			set {
				if (value == null) return;
				title = value;
			}
		}

		public Viewer Viewer { get; set; }

		public ElementEditor() {
			InitializeComponent();
		}

		public void UpdateParams() {
			nuX.Value = element.Bounds.X;
			nuY.Value = element.Bounds.Y;
			nuW.Value = element.Bounds.Width;
			nuH.Value = element.Bounds.Height;

			nuML.Value = element.Margin[0];
			nuMT.Value = element.Margin[1];
			nuMR.Value = element.Margin[2];
			nuMB.Value = element.Margin[3];

			ckVisible.Checked = element.Visible;
			sbOpacity.Value = (int)(element.Opacity * 1000.0f);

			if (title != null) {
				var elems = Title.ElementNames.Where(e => e != Title.GetName(Element)).ToArray();

				cbClipper.Items.Clear();
				cbClipper.Items.AddRange(elems);
				cbClipper.Tag = "LOAD";
				if (element.Clipper != null)
					cbClipper.SelectedIndex = cbClipper.Items.IndexOf(Title.GetName(Element.Clipper));
				else {
					cbClipper.ResetText();
					cbClipper.SelectedIndex = -1;
				}
				cbClipper.Tag = null;

				cbFit.Items.Clear();
				cbFit.Items.AddRange(elems);
				cbFit.Tag = "LOAD";
				if (element.AutoFit != null)
					cbFit.SelectedIndex = cbFit.Items.IndexOf(Title.GetName(Element.AutoFit));
				else {
					cbFit.ResetText();
					cbFit.SelectedIndex = -1;
				}
				cbFit.Tag = null;
			}
		}

		private void nuX_ValueChanged(object sender, EventArgs e) {
			element.Bounds = new Rectangle((int)nuX.Value, element.Bounds.Y, element.Bounds.Width, element.Bounds.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuY_ValueChanged(object sender, EventArgs e) {
			element.Bounds = new Rectangle(element.Bounds.X, (int)nuY.Value, element.Bounds.Width, element.Bounds.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuW_ValueChanged(object sender, EventArgs e) {
			element.Bounds = new Rectangle(element.Bounds.X, element.Bounds.Y, (int)nuW.Value, element.Bounds.Height);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuH_ValueChanged(object sender, EventArgs e) {
			element.Bounds = new Rectangle(element.Bounds.X, element.Bounds.Y, element.Bounds.Width, (int)nuH.Value);
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void sbOpacity_Scroll(object sender, ScrollEventArgs e) {
			element.Opacity = sbOpacity.Value / 1000.0f;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void ckVisible_CheckedChanged(object sender, EventArgs e) {
			element.Visible = ckVisible.Checked;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void cbElements_SelectedIndexChanged(object sender, EventArgs e) {
			if (cbClipper.Tag != null) return;
			if (cbClipper.SelectedIndex >= 0)
				element.Clipper = Title.GetElement(cbClipper.SelectedItem as string);
			else
				element.Clipper = null;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void btReset_Click(object sender, EventArgs e) {
			cbClipper.Tag = "LOAD";
			cbClipper.ResetText();
			cbClipper.SelectedIndex = -1;
			element.Clipper = null;
			cbClipper.Tag = null;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void btResetFit_Click(object sender, EventArgs e) {
			cbFit.Tag = "LOAD";
			cbFit.ResetText();
			cbFit.SelectedIndex = -1;
			element.AutoFit = null;
			cbFit.Tag = null;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void cbFit_SelectedIndexChanged(object sender, EventArgs e) {
			if (cbFit.Tag != null) return;
			if (cbFit.SelectedIndex >= 0)
				element.AutoFit = Title.GetElement(cbFit.SelectedItem as string);
			else
				element.AutoFit = null;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuML_ValueChanged(object sender, EventArgs e) {
			element.Margin[0] = (int) nuML.Value;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuMR_ValueChanged(object sender, EventArgs e) {
			element.Margin[2] = (int)nuMR.Value;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuMB_ValueChanged(object sender, EventArgs e) {
			element.Margin[3] = (int)nuMB.Value;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void nuMT_ValueChanged(object sender, EventArgs e) {
			element.Margin[1] = (int)nuMT.Value;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}
	}
}
