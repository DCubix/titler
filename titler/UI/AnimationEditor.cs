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
	public partial class AnimationEditor : UserControl {
		private Element element;

		public Element Element {
			get { return element; }
			set {
				element = value;
				if (element != null) {
					UpdateParams();
				}
			}
		}

		public bool InOut { get; set; }
		private bool lockCb = false;

		public Viewer Viewer { get; set; }

		private Animation SelectedAnimation {
			get {
				return InOut ? Element.InAnimation : Element.OutAnimation;
			}
			set {
				if (InOut) Element.InAnimation = value;
				else Element.OutAnimation = value;
			}
		}

		public AnimationEditor() {
			InitializeComponent();

		}

		private void UpdateParams() {
			var tp = SelectedAnimation?.GetType();
			if (tp != null) {
				lockCb = true;
				if (tp == typeof(Fade)) cbAnimations.SelectedIndex = 1;
				else if (tp == typeof(Reveal)) cbAnimations.SelectedIndex = 2;
				lockCb = false;
			} else {
				lockCb = true;
				cbAnimations.SelectedIndex = 0;
				lockCb = false;
			}

			pgProps.SelectedObject = SelectedAnimation;
		}

		private void cbAnimations_SelectedIndexChanged(object sender, EventArgs e) {
			if (lockCb) return;
			switch (cbAnimations.SelectedIndex) {
				default: SelectedAnimation = null; break;
				case 1: SelectedAnimation = new Fade(); break;
				case 2: SelectedAnimation = new Reveal(); break;
			}
			UpdateParams();
			Viewer.Invalidate();
			Viewer.TriggerDataChange();
		}

		private void btPlayStop_Click(object sender, EventArgs e) {
			
		}

		private void pgProps_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			Viewer.TriggerDataChange();
		}
	}
}
