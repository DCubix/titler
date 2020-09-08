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
	public partial class TextVarEditor : UserControl {

		public TextElement Element { get; set; }

		public TextVarEditor() {
			InitializeComponent();
		}

		public void UpdateText(string text) {
			txValue.Text = text;
		}

		private void btApply_Click(object sender, EventArgs e) {
			if (Element == null) return;
			Element.Text = txValue.Text;
		}
	}
}
