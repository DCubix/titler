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
using Plasmoid.Extensions;

namespace titler.UI {
	public partial class RectangleElementEditor : UserControl {
		private RectangleElement element;

		public RectangleElement Element {
			get { return element; }
			set {
				element = value;
				if (element != null) {
					UpdateParams();
				}
			}
		}

		public Viewer Viewer { get; set; }

		public RectangleElementEditor() {
			InitializeComponent();
		}

		private void UpdateParams() {
			btFill.BackColor = element.Fill;
			btFill.ForeColor = Color.FromArgb(255, 255 - element.Fill.R, 255 - element.Fill.G, 255 - element.Fill.B);
			btFill.Text = ColorTranslator.ToHtml(element.Fill).ToLower();

			nuRadius.Value = element.BorderRadius;

			var filter = element.EdgeFilter;
			ckRTL.Checked = (RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilter.TopLeft;
			ckRTR.Checked = (RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilter.TopRight;
			ckRBL.Checked = (RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilter.BottomLeft;
			ckRBR.Checked = (RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilter.BottomRight;
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

		private void nuRTL_ValueChanged(object sender, EventArgs e) {
			element.BorderRadius = (int) nuRadius.Value;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void label7_Click(object sender, EventArgs e) {

		}

		private void ckRTL_CheckedChanged(object sender, EventArgs e) {
			if (ckRTL.Checked)
				element.EdgeFilter |= RectangleEdgeFilter.TopLeft;
			else
				element.EdgeFilter &= ~RectangleEdgeFilter.TopLeft;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void ckRTR_CheckedChanged(object sender, EventArgs e) {
			if (ckRTR.Checked)
				element.EdgeFilter |= RectangleEdgeFilter.TopRight;
			else
				element.EdgeFilter &= ~RectangleEdgeFilter.TopRight;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void ckRBL_CheckedChanged(object sender, EventArgs e) {
			if (ckRBL.Checked)
				element.EdgeFilter |= RectangleEdgeFilter.BottomLeft;
			else
				element.EdgeFilter &= ~RectangleEdgeFilter.BottomLeft;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void ckRBR_CheckedChanged(object sender, EventArgs e) {
			if (ckRBR.Checked)
				element.EdgeFilter |= RectangleEdgeFilter.BottomRight;
			else
				element.EdgeFilter &= ~RectangleEdgeFilter.BottomRight;
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}
	}
}
