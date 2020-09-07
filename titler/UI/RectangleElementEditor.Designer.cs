namespace titler.UI {
	partial class RectangleElementEditor {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.nuRadius = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btFill = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ckRBR = new System.Windows.Forms.CheckBox();
			this.ckRBL = new System.Windows.Forms.CheckBox();
			this.ckRTR = new System.Windows.Forms.CheckBox();
			this.ckRTL = new System.Windows.Forms.CheckBox();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuRadius)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ckRBR);
			this.groupBox2.Controls.Add(this.ckRBL);
			this.groupBox2.Controls.Add(this.ckRTR);
			this.groupBox2.Controls.Add(this.ckRTL);
			this.groupBox2.Controls.Add(this.nuRadius);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(8, 73);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(285, 133);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Border Radius";
			// 
			// nuRadius
			// 
			this.nuRadius.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuRadius.Location = new System.Drawing.Point(94, 22);
			this.nuRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuRadius.Name = "nuRadius";
			this.nuRadius.Size = new System.Drawing.Size(148, 20);
			this.nuRadius.TabIndex = 12;
			this.nuRadius.ValueChanged += new System.EventHandler(this.nuRTL_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 20);
			this.label7.TabIndex = 9;
			this.label7.Text = "Radius";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btFill);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(285, 65);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Rectangle";
			// 
			// btFill
			// 
			this.btFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btFill.BackColor = System.Drawing.Color.Red;
			this.btFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btFill.ForeColor = System.Drawing.Color.Aqua;
			this.btFill.Location = new System.Drawing.Point(131, 26);
			this.btFill.Name = "btFill";
			this.btFill.Size = new System.Drawing.Size(145, 23);
			this.btFill.TabIndex = 18;
			this.btFill.Text = "#FF0000";
			this.btFill.UseVisualStyleBackColor = false;
			this.btFill.Click += new System.EventHandler(this.btFill_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 20);
			this.label1.TabIndex = 17;
			this.label1.Text = "Fill Color";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ckRBR
			// 
			this.ckRBR.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ckRBR.Appearance = System.Windows.Forms.Appearance.Button;
			this.ckRBR.Image = global::titler.Properties.Resources.arrow_mini_bottom_right;
			this.ckRBR.Location = new System.Drawing.Point(169, 78);
			this.ckRBR.Name = "ckRBR";
			this.ckRBR.Size = new System.Drawing.Size(30, 30);
			this.ckRBR.TabIndex = 16;
			this.ckRBR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ckRBR.UseVisualStyleBackColor = true;
			this.ckRBR.CheckedChanged += new System.EventHandler(this.ckRBR_CheckedChanged);
			// 
			// ckRBL
			// 
			this.ckRBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ckRBL.Appearance = System.Windows.Forms.Appearance.Button;
			this.ckRBL.Image = global::titler.Properties.Resources.arrow_mini_bottom_left;
			this.ckRBL.Location = new System.Drawing.Point(133, 78);
			this.ckRBL.Name = "ckRBL";
			this.ckRBL.Size = new System.Drawing.Size(30, 30);
			this.ckRBL.TabIndex = 15;
			this.ckRBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ckRBL.UseVisualStyleBackColor = true;
			this.ckRBL.CheckedChanged += new System.EventHandler(this.ckRBL_CheckedChanged);
			// 
			// ckRTR
			// 
			this.ckRTR.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ckRTR.Appearance = System.Windows.Forms.Appearance.Button;
			this.ckRTR.Image = global::titler.Properties.Resources.arrow_mini_top_right;
			this.ckRTR.Location = new System.Drawing.Point(169, 48);
			this.ckRTR.Name = "ckRTR";
			this.ckRTR.Size = new System.Drawing.Size(30, 30);
			this.ckRTR.TabIndex = 14;
			this.ckRTR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ckRTR.UseVisualStyleBackColor = true;
			this.ckRTR.CheckedChanged += new System.EventHandler(this.ckRTR_CheckedChanged);
			// 
			// ckRTL
			// 
			this.ckRTL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ckRTL.Appearance = System.Windows.Forms.Appearance.Button;
			this.ckRTL.Image = global::titler.Properties.Resources.arrow_mini_top_left;
			this.ckRTL.Location = new System.Drawing.Point(133, 48);
			this.ckRTL.Name = "ckRTL";
			this.ckRTL.Size = new System.Drawing.Size(30, 30);
			this.ckRTL.TabIndex = 13;
			this.ckRTL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ckRTL.UseVisualStyleBackColor = true;
			this.ckRTL.CheckedChanged += new System.EventHandler(this.ckRTL_CheckedChanged);
			// 
			// RectangleElementEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "RectangleElementEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(301, 217);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nuRadius)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown nuRadius;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btFill;
		private System.Windows.Forms.CheckBox ckRBR;
		private System.Windows.Forms.CheckBox ckRBL;
		private System.Windows.Forms.CheckBox ckRTR;
		private System.Windows.Forms.CheckBox ckRTL;
	}
}
