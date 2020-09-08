namespace titler {
	partial class PlayoutForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btOpen = new System.Windows.Forms.ToolStripButton();
			this.tbDesigner = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbRecent = new System.Windows.Forms.TabPage();
			this.lsRecent = new System.Windows.Forms.ListView();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tbShowHide = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.lsPresets = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.btSaveCurrent = new System.Windows.Forms.ToolStripButton();
			this.btDelete = new System.Windows.Forms.ToolStripButton();
			this.lsVars = new System.Windows.Forms.ListBox();
			this.pnEdit = new System.Windows.Forms.Panel();
			this.toolStrip3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tbRecent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btOpen,
            this.tbDesigner});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(668, 31);
			this.toolStrip3.TabIndex = 3;
			// 
			// btOpen
			// 
			this.btOpen.Image = global::titler.Properties.Resources.folder_vertical_open;
			this.btOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btOpen.Name = "btOpen";
			this.btOpen.Size = new System.Drawing.Size(112, 28);
			this.btOpen.Text = "Open Design...";
			this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// tbDesigner
			// 
			this.tbDesigner.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tbDesigner.Image = global::titler.Properties.Resources.layouts_design;
			this.tbDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbDesigner.Name = "tbDesigner";
			this.tbDesigner.Size = new System.Drawing.Size(106, 28);
			this.tbDesigner.Text = "Title Designer";
			this.tbDesigner.Click += new System.EventHandler(this.tbDesigner_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 31);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(668, 422);
			this.splitContainer1.SplitterDistance = 206;
			this.splitContainer1.TabIndex = 4;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbRecent);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(206, 422);
			this.tabControl1.TabIndex = 5;
			// 
			// tbRecent
			// 
			this.tbRecent.Controls.Add(this.lsRecent);
			this.tbRecent.Location = new System.Drawing.Point(4, 22);
			this.tbRecent.Name = "tbRecent";
			this.tbRecent.Padding = new System.Windows.Forms.Padding(3);
			this.tbRecent.Size = new System.Drawing.Size(198, 396);
			this.tbRecent.TabIndex = 0;
			this.tbRecent.Text = "Recent Designs";
			this.tbRecent.UseVisualStyleBackColor = true;
			// 
			// lsRecent
			// 
			this.lsRecent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsRecent.HideSelection = false;
			this.lsRecent.Location = new System.Drawing.Point(3, 3);
			this.lsRecent.MultiSelect = false;
			this.lsRecent.Name = "lsRecent";
			this.lsRecent.Size = new System.Drawing.Size(192, 390);
			this.lsRecent.TabIndex = 0;
			this.lsRecent.UseCompatibleStateImageBehavior = false;
			this.lsRecent.SelectedIndexChanged += new System.EventHandler(this.lsRecent_SelectedIndexChanged);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.pnEdit);
			this.splitContainer2.Panel1.Controls.Add(this.lsVars);
			this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.lsPresets);
			this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
			this.splitContainer2.Size = new System.Drawing.Size(458, 422);
			this.splitContainer2.SplitterDistance = 235;
			this.splitContainer2.TabIndex = 0;
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbShowHide,
            this.toolStripLabel1});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(458, 31);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tbShowHide
			// 
			this.tbShowHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tbShowHide.Image = global::titler.Properties.Resources.eye;
			this.tbShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbShowHide.Name = "tbShowHide";
			this.tbShowHide.Size = new System.Drawing.Size(64, 28);
			this.tbShowHide.Tag = "S";
			this.tbShowHide.Text = "Show";
			this.tbShowHide.Click += new System.EventHandler(this.tbShowHide_Click);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel1.Text = "Variables";
			// 
			// lsPresets
			// 
			this.lsPresets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsPresets.FormattingEnabled = true;
			this.lsPresets.Location = new System.Drawing.Point(0, 25);
			this.lsPresets.Name = "lsPresets";
			this.lsPresets.Size = new System.Drawing.Size(458, 158);
			this.lsPresets.TabIndex = 1;
			this.lsPresets.SelectedIndexChanged += new System.EventHandler(this.lsPresets_SelectedIndexChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.btSaveCurrent,
            this.btDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(458, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
			this.toolStripLabel2.Text = "Presets";
			// 
			// btSaveCurrent
			// 
			this.btSaveCurrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btSaveCurrent.Image = global::titler.Properties.Resources.disk2;
			this.btSaveCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btSaveCurrent.Name = "btSaveCurrent";
			this.btSaveCurrent.Size = new System.Drawing.Size(23, 22);
			this.btSaveCurrent.Text = "Save Current Values";
			this.btSaveCurrent.Click += new System.EventHandler(this.btSaveCurrent_Click);
			// 
			// btDelete
			// 
			this.btDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btDelete.Image = global::titler.Properties.Resources.delete2;
			this.btDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(23, 22);
			this.btDelete.Text = "Delete Selected Entry";
			this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// lsVars
			// 
			this.lsVars.Dock = System.Windows.Forms.DockStyle.Left;
			this.lsVars.FormattingEnabled = true;
			this.lsVars.Location = new System.Drawing.Point(0, 31);
			this.lsVars.Name = "lsVars";
			this.lsVars.Size = new System.Drawing.Size(147, 204);
			this.lsVars.TabIndex = 1;
			this.lsVars.SelectedIndexChanged += new System.EventHandler(this.lsVars_SelectedIndexChanged);
			// 
			// pnEdit
			// 
			this.pnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnEdit.Location = new System.Drawing.Point(147, 31);
			this.pnEdit.Name = "pnEdit";
			this.pnEdit.Size = new System.Drawing.Size(311, 204);
			this.pnEdit.TabIndex = 2;
			// 
			// PlayoutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 453);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip3);
			this.Name = "PlayoutForm";
			this.Text = "PlayoutForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayoutForm_FormClosing);
			this.Load += new System.EventHandler(this.PlayoutForm_Load);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tbRecent.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton btOpen;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbRecent;
		private System.Windows.Forms.ListView lsRecent;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btSaveCurrent;
		private System.Windows.Forms.ToolStripButton btDelete;
		private System.Windows.Forms.ListBox lsPresets;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton tbShowHide;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripButton tbDesigner;
		private System.Windows.Forms.ListBox lsVars;
		private System.Windows.Forms.Panel pnEdit;
	}
}