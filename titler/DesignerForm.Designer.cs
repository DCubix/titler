namespace titler
{
    partial class DesignerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			titler.Titler.Title title1 = new titler.Titler.Title();
			this.tbTools = new System.Windows.Forms.TabControl();
			this.tbTitle = new System.Windows.Forms.TabPage();
			this.lsElements = new System.Windows.Forms.ListView();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.btCreate = new System.Windows.Forms.ToolStripDropDownButton();
			this.btCreateText = new System.Windows.Forms.ToolStripMenuItem();
			this.btCreateRectangle = new System.Windows.Forms.ToolStripMenuItem();
			this.btCreateImage = new System.Windows.Forms.ToolStripMenuItem();
			this.btDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btMoveUp = new System.Windows.Forms.ToolStripButton();
			this.btMoveDown = new System.Windows.Forms.ToolStripButton();
			this.pgTitle = new System.Windows.Forms.PropertyGrid();
			this.tbProps = new System.Windows.Forms.TabPage();
			this.imageEdit = new titler.UI.ImageEditor();
			this.textEdit = new titler.UI.TextEditor();
			this.rectangleEdit = new titler.UI.RectangleElementEditor();
			this.elementEdit = new titler.UI.ElementEditor();
			this.tbAnimations = new System.Windows.Forms.TabPage();
			this.btPreview = new System.Windows.Forms.Button();
			this.gpOut = new System.Windows.Forms.GroupBox();
			this.outEditor = new titler.UI.AnimationEditor();
			this.gpIn = new System.Windows.Forms.GroupBox();
			this.inEditor = new titler.UI.AnimationEditor();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btNew = new System.Windows.Forms.ToolStripButton();
			this.btOpen = new System.Windows.Forms.ToolStripButton();
			this.btSave = new System.Windows.Forms.ToolStripButton();
			this.btSaveAs = new System.Windows.Forms.ToolStripButton();
			this.vwCanvas = new titler.Titler.Viewer();
			this.tbTools.SuspendLayout();
			this.tbTitle.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.tbProps.SuspendLayout();
			this.tbAnimations.SuspendLayout();
			this.gpOut.SuspendLayout();
			this.gpIn.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbTools
			// 
			this.tbTools.Controls.Add(this.tbTitle);
			this.tbTools.Controls.Add(this.tbProps);
			this.tbTools.Controls.Add(this.tbAnimations);
			this.tbTools.Dock = System.Windows.Forms.DockStyle.Right;
			this.tbTools.Location = new System.Drawing.Point(825, 31);
			this.tbTools.Name = "tbTools";
			this.tbTools.SelectedIndex = 0;
			this.tbTools.Size = new System.Drawing.Size(323, 713);
			this.tbTools.TabIndex = 1;
			// 
			// tbTitle
			// 
			this.tbTitle.Controls.Add(this.lsElements);
			this.tbTitle.Controls.Add(this.toolStrip2);
			this.tbTitle.Controls.Add(this.pgTitle);
			this.tbTitle.Location = new System.Drawing.Point(4, 22);
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Padding = new System.Windows.Forms.Padding(3);
			this.tbTitle.Size = new System.Drawing.Size(315, 687);
			this.tbTitle.TabIndex = 0;
			this.tbTitle.Text = "Title";
			this.tbTitle.UseVisualStyleBackColor = true;
			// 
			// lsElements
			// 
			this.lsElements.Dock = System.Windows.Forms.DockStyle.Top;
			this.lsElements.GridLines = true;
			this.lsElements.HideSelection = false;
			this.lsElements.LabelEdit = true;
			this.lsElements.Location = new System.Drawing.Point(3, 245);
			this.lsElements.Name = "lsElements";
			this.lsElements.Size = new System.Drawing.Size(309, 150);
			this.lsElements.TabIndex = 3;
			this.lsElements.UseCompatibleStateImageBehavior = false;
			this.lsElements.View = System.Windows.Forms.View.List;
			this.lsElements.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lsElements_AfterLabelEdit);
			this.lsElements.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lsElements_BeforeLabelEdit);
			this.lsElements.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsElements_MouseClick);
			this.lsElements.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsElements_MouseDoubleClick);
			// 
			// toolStrip2
			// 
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.btCreate,
            this.btDelete,
            this.toolStripSeparator1,
            this.btMoveUp,
            this.btMoveDown});
			this.toolStrip2.Location = new System.Drawing.Point(3, 220);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(309, 25);
			this.toolStrip2.TabIndex = 4;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(55, 22);
			this.toolStripLabel2.Text = "Elements";
			// 
			// btCreate
			// 
			this.btCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCreateText,
            this.btCreateRectangle,
            this.btCreateImage});
			this.btCreate.Image = global::titler.Properties.Resources.add;
			this.btCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btCreate.Name = "btCreate";
			this.btCreate.Size = new System.Drawing.Size(29, 22);
			this.btCreate.Text = "Create Element";
			this.btCreate.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// btCreateText
			// 
			this.btCreateText.Image = global::titler.Properties.Resources.layer_shape_text;
			this.btCreateText.Name = "btCreateText";
			this.btCreateText.Size = new System.Drawing.Size(126, 22);
			this.btCreateText.Text = "Text";
			this.btCreateText.Click += new System.EventHandler(this.btCreateText_Click);
			// 
			// btCreateRectangle
			// 
			this.btCreateRectangle.Image = global::titler.Properties.Resources.shape_square;
			this.btCreateRectangle.Name = "btCreateRectangle";
			this.btCreateRectangle.Size = new System.Drawing.Size(126, 22);
			this.btCreateRectangle.Text = "Rectangle";
			this.btCreateRectangle.Click += new System.EventHandler(this.btCreateRectangle_Click);
			// 
			// btCreateImage
			// 
			this.btCreateImage.Image = global::titler.Properties.Resources.image;
			this.btCreateImage.Name = "btCreateImage";
			this.btCreateImage.Size = new System.Drawing.Size(126, 22);
			this.btCreateImage.Text = "Image";
			this.btCreateImage.Click += new System.EventHandler(this.btCreateImage_Click);
			// 
			// btDelete
			// 
			this.btDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btDelete.Image = global::titler.Properties.Resources.delete1;
			this.btDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(23, 22);
			this.btDelete.Text = "Delete Selected";
			this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btMoveUp
			// 
			this.btMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btMoveUp.Image = global::titler.Properties.Resources.arrow_up;
			this.btMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btMoveUp.Name = "btMoveUp";
			this.btMoveUp.Size = new System.Drawing.Size(23, 22);
			this.btMoveUp.Text = "Bring Back";
			this.btMoveUp.Click += new System.EventHandler(this.btMoveUp_Click);
			// 
			// btMoveDown
			// 
			this.btMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btMoveDown.Image = global::titler.Properties.Resources.arrow_down;
			this.btMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btMoveDown.Name = "btMoveDown";
			this.btMoveDown.Size = new System.Drawing.Size(23, 22);
			this.btMoveDown.Text = "Bring Forward";
			this.btMoveDown.Click += new System.EventHandler(this.btMoveDown_Click);
			// 
			// pgTitle
			// 
			this.pgTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pgTitle.Location = new System.Drawing.Point(3, 3);
			this.pgTitle.Name = "pgTitle";
			this.pgTitle.Size = new System.Drawing.Size(309, 217);
			this.pgTitle.TabIndex = 5;
			this.pgTitle.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgTitle_PropertyValueChanged);
			// 
			// tbProps
			// 
			this.tbProps.AutoScroll = true;
			this.tbProps.Controls.Add(this.imageEdit);
			this.tbProps.Controls.Add(this.textEdit);
			this.tbProps.Controls.Add(this.rectangleEdit);
			this.tbProps.Controls.Add(this.elementEdit);
			this.tbProps.Location = new System.Drawing.Point(4, 22);
			this.tbProps.Name = "tbProps";
			this.tbProps.Padding = new System.Windows.Forms.Padding(3);
			this.tbProps.Size = new System.Drawing.Size(315, 687);
			this.tbProps.TabIndex = 1;
			this.tbProps.Text = "Properties";
			this.tbProps.UseVisualStyleBackColor = true;
			// 
			// imageEdit
			// 
			this.imageEdit.BackColor = System.Drawing.SystemColors.Control;
			this.imageEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imageEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.imageEdit.Element = null;
			this.imageEdit.Location = new System.Drawing.Point(3, 822);
			this.imageEdit.Name = "imageEdit";
			this.imageEdit.Padding = new System.Windows.Forms.Padding(8);
			this.imageEdit.Size = new System.Drawing.Size(292, 156);
			this.imageEdit.TabIndex = 3;
			this.imageEdit.Viewer = null;
			this.imageEdit.Visible = false;
			// 
			// textEdit
			// 
			this.textEdit.BackColor = System.Drawing.SystemColors.Control;
			this.textEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.textEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.textEdit.Element = null;
			this.textEdit.Location = new System.Drawing.Point(3, 536);
			this.textEdit.Name = "textEdit";
			this.textEdit.Padding = new System.Windows.Forms.Padding(8);
			this.textEdit.Size = new System.Drawing.Size(292, 286);
			this.textEdit.TabIndex = 2;
			this.textEdit.Title = null;
			this.textEdit.Viewer = null;
			this.textEdit.Visible = false;
			// 
			// rectangleEdit
			// 
			this.rectangleEdit.BackColor = System.Drawing.SystemColors.Control;
			this.rectangleEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.rectangleEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.rectangleEdit.Element = null;
			this.rectangleEdit.Location = new System.Drawing.Point(3, 318);
			this.rectangleEdit.Name = "rectangleEdit";
			this.rectangleEdit.Padding = new System.Windows.Forms.Padding(8);
			this.rectangleEdit.Size = new System.Drawing.Size(292, 218);
			this.rectangleEdit.TabIndex = 1;
			this.rectangleEdit.Viewer = null;
			this.rectangleEdit.Visible = false;
			// 
			// elementEdit
			// 
			this.elementEdit.BackColor = System.Drawing.SystemColors.Control;
			this.elementEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.elementEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.elementEdit.Element = null;
			this.elementEdit.Location = new System.Drawing.Point(3, 3);
			this.elementEdit.Name = "elementEdit";
			this.elementEdit.Padding = new System.Windows.Forms.Padding(8);
			this.elementEdit.Size = new System.Drawing.Size(292, 315);
			this.elementEdit.TabIndex = 0;
			this.elementEdit.Title = null;
			this.elementEdit.Viewer = null;
			this.elementEdit.Visible = false;
			// 
			// tbAnimations
			// 
			this.tbAnimations.Controls.Add(this.btPreview);
			this.tbAnimations.Controls.Add(this.gpOut);
			this.tbAnimations.Controls.Add(this.gpIn);
			this.tbAnimations.Location = new System.Drawing.Point(4, 22);
			this.tbAnimations.Name = "tbAnimations";
			this.tbAnimations.Padding = new System.Windows.Forms.Padding(3);
			this.tbAnimations.Size = new System.Drawing.Size(315, 687);
			this.tbAnimations.TabIndex = 2;
			this.tbAnimations.Text = "Animations";
			this.tbAnimations.UseVisualStyleBackColor = true;
			// 
			// btPreview
			// 
			this.btPreview.Dock = System.Windows.Forms.DockStyle.Top;
			this.btPreview.Location = new System.Drawing.Point(3, 635);
			this.btPreview.Margin = new System.Windows.Forms.Padding(25, 3, 25, 3);
			this.btPreview.Name = "btPreview";
			this.btPreview.Size = new System.Drawing.Size(309, 23);
			this.btPreview.TabIndex = 0;
			this.btPreview.Tag = "P";
			this.btPreview.Text = "Preview";
			this.btPreview.UseVisualStyleBackColor = true;
			this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
			// 
			// gpOut
			// 
			this.gpOut.Controls.Add(this.outEditor);
			this.gpOut.Dock = System.Windows.Forms.DockStyle.Top;
			this.gpOut.Location = new System.Drawing.Point(3, 319);
			this.gpOut.Name = "gpOut";
			this.gpOut.Size = new System.Drawing.Size(309, 316);
			this.gpOut.TabIndex = 1;
			this.gpOut.TabStop = false;
			this.gpOut.Text = "Out";
			this.gpOut.Visible = false;
			// 
			// outEditor
			// 
			this.outEditor.Cursor = System.Windows.Forms.Cursors.Default;
			this.outEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outEditor.Element = null;
			this.outEditor.InOut = false;
			this.outEditor.Location = new System.Drawing.Point(3, 16);
			this.outEditor.Margin = new System.Windows.Forms.Padding(0);
			this.outEditor.Name = "outEditor";
			this.outEditor.Padding = new System.Windows.Forms.Padding(8);
			this.outEditor.Size = new System.Drawing.Size(303, 297);
			this.outEditor.TabIndex = 0;
			this.outEditor.Viewer = null;
			// 
			// gpIn
			// 
			this.gpIn.Controls.Add(this.inEditor);
			this.gpIn.Dock = System.Windows.Forms.DockStyle.Top;
			this.gpIn.Location = new System.Drawing.Point(3, 3);
			this.gpIn.Name = "gpIn";
			this.gpIn.Size = new System.Drawing.Size(309, 316);
			this.gpIn.TabIndex = 0;
			this.gpIn.TabStop = false;
			this.gpIn.Text = "In";
			this.gpIn.Visible = false;
			// 
			// inEditor
			// 
			this.inEditor.Cursor = System.Windows.Forms.Cursors.Default;
			this.inEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inEditor.Element = null;
			this.inEditor.InOut = false;
			this.inEditor.Location = new System.Drawing.Point(3, 16);
			this.inEditor.Margin = new System.Windows.Forms.Padding(0);
			this.inEditor.Name = "inEditor";
			this.inEditor.Padding = new System.Windows.Forms.Padding(8);
			this.inEditor.Size = new System.Drawing.Size(303, 297);
			this.inEditor.TabIndex = 0;
			this.inEditor.Viewer = null;
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNew,
            this.btOpen,
            this.btSave,
            this.btSaveAs});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(1148, 31);
			this.toolStrip3.TabIndex = 2;
			// 
			// btNew
			// 
			this.btNew.Image = global::titler.Properties.Resources.page_white;
			this.btNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(59, 28);
			this.btNew.Text = "New";
			this.btNew.Click += new System.EventHandler(this.btNew_Click);
			// 
			// btOpen
			// 
			this.btOpen.Image = global::titler.Properties.Resources.folder_vertical_open;
			this.btOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btOpen.Name = "btOpen";
			this.btOpen.Size = new System.Drawing.Size(64, 28);
			this.btOpen.Text = "Open";
			this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// btSave
			// 
			this.btSave.Image = global::titler.Properties.Resources.disk;
			this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(59, 28);
			this.btSave.Text = "Save";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btSaveAs
			// 
			this.btSaveAs.Image = global::titler.Properties.Resources.save_as;
			this.btSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btSaveAs.Name = "btSaveAs";
			this.btSaveAs.Size = new System.Drawing.Size(84, 28);
			this.btSaveAs.Text = "Save As...";
			this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
			// 
			// vwCanvas
			// 
			this.vwCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vwCanvas.Location = new System.Drawing.Point(0, 31);
			this.vwCanvas.Name = "vwCanvas";
			this.vwCanvas.Size = new System.Drawing.Size(825, 713);
			this.vwCanvas.TabIndex = 0;
			this.vwCanvas.Text = "viewer1";
			title1.Resolution = new System.Drawing.Size(1920, 1080);
			this.vwCanvas.Title = title1;
			// 
			// DesignerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1148, 744);
			this.Controls.Add(this.vwCanvas);
			this.Controls.Add(this.tbTools);
			this.Controls.Add(this.toolStrip3);
			this.Name = "DesignerForm";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tbTools.ResumeLayout(false);
			this.tbTitle.ResumeLayout(false);
			this.tbTitle.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.tbProps.ResumeLayout(false);
			this.tbAnimations.ResumeLayout(false);
			this.gpOut.ResumeLayout(false);
			this.gpIn.ResumeLayout(false);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private Titler.Viewer vwCanvas;
		private System.Windows.Forms.TabControl tbTools;
		private System.Windows.Forms.TabPage tbProps;
		private System.Windows.Forms.TabPage tbTitle;
		private UI.ElementEditor elementEdit;
		private UI.RectangleElementEditor rectangleEdit;
		private UI.TextEditor textEdit;
		private UI.ImageEditor imageEdit;
		private System.Windows.Forms.TabPage tbAnimations;
		private System.Windows.Forms.GroupBox gpIn;
		private UI.AnimationEditor inEditor;
		private System.Windows.Forms.GroupBox gpOut;
		private UI.AnimationEditor outEditor;
		private System.Windows.Forms.Button btPreview;
		private System.Windows.Forms.ListView lsElements;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripButton btDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btMoveUp;
		private System.Windows.Forms.ToolStripButton btMoveDown;
		private System.Windows.Forms.ToolStripDropDownButton btCreate;
		private System.Windows.Forms.ToolStripMenuItem btCreateText;
		private System.Windows.Forms.ToolStripMenuItem btCreateRectangle;
		private System.Windows.Forms.ToolStripMenuItem btCreateImage;
		private System.Windows.Forms.PropertyGrid pgTitle;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton btNew;
		private System.Windows.Forms.ToolStripButton btOpen;
		private System.Windows.Forms.ToolStripButton btSave;
		private System.Windows.Forms.ToolStripButton btSaveAs;
	}
}

