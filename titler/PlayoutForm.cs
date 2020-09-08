using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using titler.Core;
using titler.Titler;
using titler.UI;

namespace titler {
	public partial class PlayoutForm : Form {

		private JObject appState;
		private Dictionary<string, Title> recentTitles;
		private Dictionary<string, List<List<string>>> presets;

		private ImageList thumbs;

		private NDIOutput output;

		public struct Var {
			public string Element { get; set; }
			public string Label { get; set; }
			public string Type { get; set; }

			public Var(string element, string label, string type) {
				Element = element;
				Label = label;
				Type = type;
			}

			public override string ToString() {
				return Label;
			}
		}

		public PlayoutForm() {
			InitializeComponent();

			recentTitles = new Dictionary<string, Title>();
			presets = new Dictionary<string, List<List<string>>>();

			thumbs = new ImageList();
			thumbs.ImageSize = new Size(120, 120);
			lsRecent.LargeImageList = thumbs;

			output = new NDIOutput(1920, 1080);
			output.Start();
		}

		private void LoadState() {
			if (!File.Exists("state.json")) {
				appState = new JObject();
				return;
			}
			appState = JObject.Parse(File.ReadAllText("state.json"));

			if (appState.ContainsKey("recent")) {
				lsRecent.Clear();
				JArray recent = (JArray)appState["recent"];

				foreach (var path in recent.Select(e => (string)e)) {
					if (!File.Exists(path)) continue;

					var title = new Title();
					title.LoadFromFile(path);
					recentTitles.Add(path, title);
					thumbs.Images.Add(title.GetPreview(thumbs.ImageSize));

					var it = new ListViewItem() {
						Text = Path.GetFileName(path),
						ImageIndex = recentTitles.Count - 1
					};
					it.Tag = path;

					lsRecent.Items.Add(it);
				}
			}

			if (appState.ContainsKey("presets")) {
				lsPresets.Items.Clear();

				JArray pres = (JArray)appState["presets"];
				foreach (var k in pres) {
					var key = (string)k["title"];
					var presLst = (JArray)k["presets"];
					presets[key] = new List<List<string>>();

					foreach (var l in presLst.Cast<JArray>()) {
						presets[key].Add(l.Select(e => (string)e).ToList());
					}
				}
			}
		}

		private void SaveState() {
			appState["recent"] = new JArray(recentTitles.Keys.ToArray());

			JArray pres = new JArray();
			foreach (var k in presets) {
				var ob = new JObject();
				ob["title"] = k.Key;

				JArray arr = new JArray();
				foreach (var pl in k.Value) {
					arr.Add(new JArray(pl.ToArray()));
				}
				ob["presets"] = arr;
				pres.Add(ob);
			}
			appState["presets"] = pres;

			using (var sw = new StreamWriter("state.json")) {
				sw.Write(appState.ToString(Newtonsoft.Json.Formatting.Indented));
			}
		}

		private void PlayoutForm_Load(object sender, EventArgs e) {
			LoadState();
		}

		private void PlayoutForm_FormClosing(object sender, FormClosingEventArgs e) {
			output.Running = false;
			SaveState();
		}

		private void OpenFile() {
			using (var ofd = new OpenFileDialog()) {
				ofd.Filter = "Title Designs (*.tdn)|*.tdn";
				if (ofd.ShowDialog() == DialogResult.OK) {
					if (recentTitles.ContainsKey(ofd.FileName)) {
						MessageBox.Show("This design already exists in the Recent list.", "Warning");
						return;
					}

					var title = new Title();
					title.LoadFromFile(ofd.FileName);

					recentTitles.Add(ofd.FileName, title);
					thumbs.Images.Add(title.GetPreview(thumbs.ImageSize));

					var it = new ListViewItem() {
						Text = Path.GetFileName(ofd.FileName),
						ImageIndex = recentTitles.Count - 1
					};
					it.Tag = ofd.FileName;

					lsRecent.Items.Add(it);
				}
			}
		}

		private void btOpen_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void lsRecent_SelectedIndexChanged(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}
			var tag = lsRecent.SelectedItems[0].Tag as string;
			var selected = recentTitles[tag];

			// get variables
			lsVars.Items.Clear();
			foreach (var k in selected.Elements) {
				if (k.Value is TextElement) {
					var varname = k.Key + "." + "Text";
					lsVars.Items.Add(new Var(k.Key, varname, "T"));
				}
				if (k.Value is ImageElement) {
					var varname = k.Key + "." + "Image";
					lsVars.Items.Add(new Var(k.Key, varname, "I"));
				}
			}

			lsPresets.Items.Clear();
			if (presets.ContainsKey(tag))
				lsPresets.Items.AddRange(presets[tag].Select(e => string.Join(";", e)).ToArray());
		}

		private void PgVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}
			var tag = lsRecent.SelectedItems[0].Tag as string;
			var selected = recentTitles[tag];

		}

		private void btSaveCurrent_Click(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}

			
		}

		private void btDelete_Click(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}
			if (lsPresets.SelectedIndices.Count == 0) {
				return;
			}

			var tag = lsRecent.SelectedItems[0].Tag as string;

			presets[tag].RemoveAt(lsPresets.SelectedIndex);
			lsPresets.Items.RemoveAt(lsPresets.SelectedIndex);
			lsPresets.SelectedIndex = -1;
		}

		private void lsPresets_SelectedIndexChanged(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}
			if (lsPresets.SelectedIndices.Count == 0) {
				return;
			}

			var tag = lsRecent.SelectedItems[0].Tag as string;
			var pres = presets[tag][lsPresets.SelectedIndex];
			
			
		}

		private void tbShowHide_Click(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}

			if ((tbShowHide.Tag as string) == "S") {
				var tag = lsRecent.SelectedItems[0].Tag as string;
				output.Title = recentTitles[tag];
				output.Title.Show();
				lsRecent.Enabled = false;
				tbShowHide.Tag = "H";
				tbShowHide.Text = "Hide";
				tbShowHide.Image = Properties.Resources.eye_close;
			} else {
				output.Title.Hide();
				lsRecent.Enabled = true;
				tbShowHide.Tag = "S";
				tbShowHide.Text = "Show";
				tbShowHide.Image = Properties.Resources.eye;
			}
		}

		private void tbDesigner_Click(object sender, EventArgs e) {
			new DesignerForm().Show();
		}

		private void lsVars_SelectedIndexChanged(object sender, EventArgs e) {
			if (lsRecent.SelectedIndices.Count == 0) {
				return;
			}
			if (lsVars.SelectedIndices.Count == 0) {
				return;
			}

			var tag = lsRecent.SelectedItems[0].Tag as string;
			var selected = recentTitles[tag];
			var v = (Var) lsVars.SelectedItem;

			pnEdit.Controls.Clear();
			if (v.Type == "T") {
				var ed = new TextVarEditor();
				var el = selected.GetElement(v.Element) as TextElement;
				ed.UpdateText(el.Text);
				ed.Element = el;
				ed.Dock = DockStyle.Fill;
				pnEdit.Controls.Add(ed);
			}
		}
	}

	public class NDIOutput : NDI {

		public Title Title { get; set; }

		public NDIOutput(int width, int height) : base(width, height, "Grace Titler") {}

		public override void Render(Graphics ctx, float dt) {
			ctx.Clear(Color.Transparent);
			ctx.ResetClip();
			if (Title != null && Title.Shown)
				Title.Render(ctx, dt);
		}
	}

}
