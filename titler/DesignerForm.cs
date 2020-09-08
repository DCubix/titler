using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using titler.Core;
using titler.Titler;

namespace titler {
	public partial class DesignerForm : Form {

		private Timer timer;
		private int playAnimState = -1;
		private string nameTemp = "";

		private bool saved = true;
		private string fileName = "";

		public DesignerForm() {
			InitializeComponent();

			rectangleEdit.Viewer = vwCanvas;
			elementEdit.Viewer = vwCanvas;
			textEdit.Viewer = vwCanvas;
			imageEdit.Viewer = vwCanvas;
			inEditor.Viewer = vwCanvas;
			outEditor.Viewer = vwCanvas;

			timer = new Timer();
			timer.Interval = 1000 / 24;
			timer.Tick += Timer_Tick;

			pgTitle.SelectedObject = vwCanvas.Title;
		}

		private void Timer_Tick(object sender, EventArgs e) {
			if (playAnimState == 0) {
				foreach (var el in vwCanvas.Title.ElementList) {
					el.OutAnimation?.Reset();
					el.InAnimation?.Update(1.0f / 24);
				}

				var allStop = true;
				foreach (var el in vwCanvas.Title.ElementList) {
					if (el.AnimationPlaying) allStop = false;
				}

				if (allStop) {
					foreach (var el in vwCanvas.Title.ElementList) {
						el.Hide();
					}
					playAnimState = 1;
				}
			} else if (playAnimState == 1) {
				foreach (var el in vwCanvas.Title.ElementList) {
					el.InAnimation?.Reset();
					el.OutAnimation?.Update(1.0f / 24);
				}

				var allStop = true;
				foreach (var el in vwCanvas.Title.ElementList) {
					if (el.AnimationPlaying) allStop = false;
				}

				if (allStop) playAnimState = 2;
			} else if (playAnimState == 2) {
				timer.Stop();

				inEditor.Enabled = true;
				outEditor.Enabled = true;
				rectangleEdit.Enabled = true;
				elementEdit.Enabled = true;
				textEdit.Enabled = true;
				imageEdit.Enabled = true;

				foreach (var el in vwCanvas.Title.ElementList) {
					el.Reset();
				}

				btPreview.Tag = "P";
				btPreview.Text = "Preview";

				playAnimState = -1;
			}
			vwCanvas.Invalidate();
		}

		private void Form1_Load(object sender, EventArgs e) {
			vwCanvas.OnDataChange += VwCanvas_OnDataChange;
			vwCanvas.OnChange += VwCanvas_OnChange;

			RebuildElementList();
			UpdateFormTitle();
		}

		private void VwCanvas_OnDataChange() {
			saved = false;
			UpdateFormTitle();
		}

		private void VwCanvas_OnChange() {
			lsElements.SelectedItems.Clear();
			foreach (var el in vwCanvas.Selected) {
				var lit = lsElements.FindItemWithText(vwCanvas.Title.GetName(el));
				if (lit != null) {
					lit.Selected = true;
				}
			}
			lsElements.Select();

			elementEdit.Visible = vwCanvas.Selected.Count > 0;
			gpIn.Visible = vwCanvas.Selected.Count > 0;
			gpOut.Visible = vwCanvas.Selected.Count > 0;

			if (vwCanvas.Selected.Count > 0) {
				elementEdit.Title = vwCanvas.Title;
				elementEdit.Element = vwCanvas.Selected[0];
				elementEdit.UpdateParams();

				rectangleEdit.Visible = (vwCanvas.Selected[0] is RectangleElement);
				textEdit.Visible = (vwCanvas.Selected[0] is TextElement);
				imageEdit.Visible = (vwCanvas.Selected[0] is ImageElement);

				if ((vwCanvas.Selected[0] is RectangleElement)) {
					rectangleEdit.Element = vwCanvas.Selected[0] as RectangleElement;
				}

				if ((vwCanvas.Selected[0] is TextElement)) {
					textEdit.Title = vwCanvas.Title;
					textEdit.Element = vwCanvas.Selected[0] as TextElement;
				}

				if ((vwCanvas.Selected[0] is ImageElement)) {
					imageEdit.Element = vwCanvas.Selected[0] as ImageElement;
				}

				inEditor.Element = vwCanvas.Selected[0];
				outEditor.Element = vwCanvas.Selected[0];

				inEditor.InOut = true;
				outEditor.InOut = false;
			} else {
				rectangleEdit.Visible = false;
				textEdit.Visible = false;
				imageEdit.Visible = false;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			
		}

		private void pgProps_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			vwCanvas.Invalidate();
			UpdateFormTitle();
		}

		private void btPreview_Click(object sender, EventArgs e) {
			if ((btPreview.Tag as string) == "P") {
				playAnimState = 0;
				timer.Start();
				inEditor.Enabled = false;
				outEditor.Enabled = false;
				rectangleEdit.Enabled = false;
				elementEdit.Enabled = false;
				textEdit.Enabled = false;
				imageEdit.Enabled = false;

				btPreview.Tag = "S";
				btPreview.Text = "Stop";

				foreach (var el in vwCanvas.Title.ElementList) {
					el.Show();
				}
			} else {
				playAnimState = 2;
				inEditor.Enabled = true;
				outEditor.Enabled = true;
				rectangleEdit.Enabled = true;
				elementEdit.Enabled = true;
				textEdit.Enabled = true;
				imageEdit.Enabled = true;
				btPreview.Tag = "P";
				btPreview.Text = "Preview";

				foreach (var el in vwCanvas.Title.ElementList) {
					el.Reset();
				}
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e) {

		}

		private void btCreateText_Click(object sender, EventArgs e) {
			var name = GetElementName();
			vwCanvas.Title.AddElement(name, new TextElement());
			vwCanvas.Invalidate();
			RebuildElementList();
		}

		private void btCreateRectangle_Click(object sender, EventArgs e) {
			var name = GetElementName();
			vwCanvas.Title.AddElement(name, new RectangleElement());
			vwCanvas.Invalidate();
			RebuildElementList();
		}

		private void btCreateImage_Click(object sender, EventArgs e) {
			var name = GetElementName();
			vwCanvas.Title.AddElement(name, new ImageElement());
			vwCanvas.Invalidate();
			RebuildElementList();
		}

		private void lsElements_AfterLabelEdit(object sender, LabelEditEventArgs e) {
			var txt = lsElements.Items[e.Item];
			var newName = e.Label != null ? e.Label : txt.Text;

			vwCanvas.Title.RenameElement(nameTemp, newName);

			nameTemp = "";
			vwCanvas.Invalidate();

			RebuildElementList();
		}

		private void lsElements_BeforeLabelEdit(object sender, LabelEditEventArgs e) {
			var txt = lsElements.Items[e.Item];
			nameTemp = txt.Text;
		}

		private string GetElementName() {
			var i = 0;
			while (lsElements.Items.Cast<ListViewItem>().Select(k => k.Text).Contains("element" + i)) {
				i++;
			}
			return "element" + i;
		}

		private void lsElements_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (lsElements.SelectedItems.Count > 0) {
				lsElements.SelectedItems[0].BeginEdit();
			}
		}

		private void pgTitle_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			saved = false;
			vwCanvas.Invalidate();
			UpdateFormTitle();
		}

		private void btDelete_Click(object sender, EventArgs e) {
			if (lsElements.SelectedItems.Count > 0) {
				var res = MessageBox.Show(
					"Are you sure you want to delete " +
					(lsElements.SelectedItems.Count > 1 ? "these" : "this") +
					" element" + (lsElements.SelectedItems.Count > 1 ? "s" : "") + "?",
					"Delete Elements",
					MessageBoxButtons.YesNo
				);

				if (res == DialogResult.Yes) {
					foreach (var el in lsElements.SelectedItems.Cast<ListViewItem>()) {
						vwCanvas.Title.DeleteElement(el.Text);
					}
					vwCanvas.Select(null);
					saved = false;
					vwCanvas.Invalidate();
					UpdateFormTitle();
					RebuildElementList();
				}
			}
		}

		private void RebuildElementList() {
			lsElements.Items.Clear();
			foreach (var v in vwCanvas.Title.Elements) {
				lsElements.Items.Add(new ListViewItem(v.Key));
			}
		}

		private void lsElements_MouseClick(object sender, MouseEventArgs e) {
			if (lsElements.SelectedItems.Count > 0) {
				vwCanvas.Select(lsElements.SelectedItems[0].Text);
			}
		}

		private void btMoveUp_Click(object sender, EventArgs e) {
			if (lsElements.SelectedItems.Count > 0) {
				lsElements.BeginUpdate();
				MoveListViewItems(lsElements, MoveDirection.Up);
				lsElements.EndUpdate();

				int i = 0;
				foreach (ListViewItem item in lsElements.Items) {
					vwCanvas.Title.SetOrder(item.Text, i);
					i++;
				}

				saved = false;
				vwCanvas.Invalidate();
				UpdateFormTitle();
			}
		}

		private void btMoveDown_Click(object sender, EventArgs e) {
			if (lsElements.SelectedItems.Count > 0) {
				lsElements.BeginUpdate();
				MoveListViewItems(lsElements, MoveDirection.Down);
				lsElements.EndUpdate();

				int i = 0;
				foreach (ListViewItem item in lsElements.Items) {
					vwCanvas.Title.SetOrder(item.Text, i);
					i++;
				}

				saved = false;
				vwCanvas.Invalidate();
				UpdateFormTitle();
			}
		}

		private enum MoveDirection { Up = -1, Down = 1 };

		private static void MoveListViewItems(ListView sender, MoveDirection direction) {
			int dir = (int)direction;
			int opp = dir * -1;

			bool valid = sender.SelectedItems.Count > 0 &&
							((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
						|| (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

			if (valid) {
				foreach (ListViewItem item in sender.SelectedItems) {
					int index = item.Index + dir;
					sender.Items.RemoveAt(item.Index);
					sender.Items.Insert(index, item);
				}
			}
		}

		private void btNew_Click(object sender, EventArgs e) {
			if (!saved) {
				var res = MessageBox.Show("You have unsaved changes. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.Yes) {
					vwCanvas.Title = new Title();
					fileName = "";
				}
			} else {
				vwCanvas.Title = new Title();
				fileName = "";
			}
			vwCanvas.Invalidate();
		}

		private void OpenFile() {
			using (var ofd = new OpenFileDialog()) {
				ofd.Filter = "Title Designs (*.tdn)|*.tdn";
				if (ofd.ShowDialog() == DialogResult.OK) {
					fileName = ofd.FileName;
					saved = true;
					vwCanvas.Title = new Title();
					vwCanvas.Title.LoadFromFile(fileName);

					btPreview_Click(null, null);
					btPreview_Click(null, null);

					RebuildElementList();

					vwCanvas.Invalidate();
					UpdateFormTitle();
				}
			}
		}

		private void SaveFile() {
			using (var ofd = new SaveFileDialog()) {
				ofd.FileName = fileName;
				ofd.Filter = "Title Designs (*.tdn)|*.tdn";
				if (ofd.ShowDialog() == DialogResult.OK) {
					fileName = ofd.FileName;
					saved = true;
					vwCanvas.Title.SaveToFile(fileName);
					vwCanvas.Invalidate();
					UpdateFormTitle();
				}
			}
		}

		private void btOpen_Click(object sender, EventArgs e) {
			if (!saved) {
				var res = MessageBox.Show("You have unsaved changes. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.Yes) {
					OpenFile();
				}
			} else {
				OpenFile();
			}
			vwCanvas.Invalidate();
			UpdateFormTitle();
		}

		private void btSave_Click(object sender, EventArgs e) {
			if (!saved) {
				if (fileName.Length > 0) {
					vwCanvas.Title.SaveToFile(fileName);
					saved = true;
					vwCanvas.Invalidate();
					UpdateFormTitle();
				} else {
					SaveFile();
				}
			}
		}

		private void btSaveAs_Click(object sender, EventArgs e) {
			SaveFile();
		}

		private void UpdateFormTitle() {
			var txt = Properties.Resources.appName;
			if (fileName.Length > 0) {
				txt += " - [" + fileName;
				if (!saved) {
					txt += "**";
				}
				txt += "]";
			}
			Text = txt;
		}

	}

}
