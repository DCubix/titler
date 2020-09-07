namespace titler.UI {
	partial class ElementEditor {
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nuW = new System.Windows.Forms.NumericUpDown();
			this.nuH = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nuX = new System.Windows.Forms.NumericUpDown();
			this.nuY = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nuMT = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.nuMR = new System.Windows.Forms.NumericUpDown();
			this.nuMB = new System.Windows.Forms.NumericUpDown();
			this.nuML = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ckVisible = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sbOpacity = new System.Windows.Forms.HScrollBar();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btResetFit = new System.Windows.Forms.Button();
			this.cbFit = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btReset = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.cbClipper = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuY)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuMT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuML)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nuW);
			this.groupBox1.Controls.Add(this.nuH);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nuX);
			this.groupBox1.Controls.Add(this.nuY);
			this.groupBox1.Location = new System.Drawing.Point(11, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(141, 133);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bounds";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Width";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Height";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nuW
			// 
			this.nuW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuW.Location = new System.Drawing.Point(61, 74);
			this.nuW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuW.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.nuW.Name = "nuW";
			this.nuW.Size = new System.Drawing.Size(74, 20);
			this.nuW.TabIndex = 8;
			this.nuW.ValueChanged += new System.EventHandler(this.nuW_ValueChanged);
			// 
			// nuH
			// 
			this.nuH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuH.Location = new System.Drawing.Point(61, 100);
			this.nuH.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuH.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.nuH.Name = "nuH";
			this.nuH.Size = new System.Drawing.Size(74, 20);
			this.nuH.TabIndex = 6;
			this.nuH.ValueChanged += new System.EventHandler(this.nuH_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "X";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Y";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nuX
			// 
			this.nuX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuX.Location = new System.Drawing.Point(61, 22);
			this.nuX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.nuX.Name = "nuX";
			this.nuX.Size = new System.Drawing.Size(74, 20);
			this.nuX.TabIndex = 4;
			this.nuX.ValueChanged += new System.EventHandler(this.nuX_ValueChanged);
			// 
			// nuY
			// 
			this.nuY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuY.Location = new System.Drawing.Point(61, 48);
			this.nuY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.nuY.Name = "nuY";
			this.nuY.Size = new System.Drawing.Size(74, 20);
			this.nuY.TabIndex = 2;
			this.nuY.ValueChanged += new System.EventHandler(this.nuY_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.nuMT);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.nuMR);
			this.groupBox2.Controls.Add(this.nuMB);
			this.groupBox2.Controls.Add(this.nuML);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(158, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(129, 133);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Margin";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 20);
			this.label5.TabIndex = 13;
			this.label5.Text = "Bottom";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nuMT
			// 
			this.nuMT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuMT.Location = new System.Drawing.Point(61, 100);
			this.nuMT.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuMT.Name = "nuMT";
			this.nuMT.Size = new System.Drawing.Size(62, 20);
			this.nuMT.TabIndex = 14;
			this.nuMT.ValueChanged += new System.EventHandler(this.nuMT_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 100);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 20);
			this.label6.TabIndex = 15;
			this.label6.Text = "Top";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nuMR
			// 
			this.nuMR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuMR.Location = new System.Drawing.Point(61, 48);
			this.nuMR.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuMR.Name = "nuMR";
			this.nuMR.Size = new System.Drawing.Size(62, 20);
			this.nuMR.TabIndex = 10;
			this.nuMR.ValueChanged += new System.EventHandler(this.nuMR_ValueChanged);
			// 
			// nuMB
			// 
			this.nuMB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuMB.Location = new System.Drawing.Point(61, 74);
			this.nuMB.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuMB.Name = "nuMB";
			this.nuMB.Size = new System.Drawing.Size(62, 20);
			this.nuMB.TabIndex = 16;
			this.nuMB.ValueChanged += new System.EventHandler(this.nuMB_ValueChanged);
			// 
			// nuML
			// 
			this.nuML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nuML.Location = new System.Drawing.Point(61, 22);
			this.nuML.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nuML.Name = "nuML";
			this.nuML.Size = new System.Drawing.Size(62, 20);
			this.nuML.TabIndex = 12;
			this.nuML.ValueChanged += new System.EventHandler(this.nuML_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 20);
			this.label8.TabIndex = 11;
			this.label8.Text = "Right";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 20);
			this.label7.TabIndex = 9;
			this.label7.Text = "Left";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.ckVisible);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.sbOpacity);
			this.groupBox3.Location = new System.Drawing.Point(11, 150);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(276, 56);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			// 
			// ckVisible
			// 
			this.ckVisible.AutoSize = true;
			this.ckVisible.Checked = true;
			this.ckVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckVisible.Location = new System.Drawing.Point(9, 0);
			this.ckVisible.Name = "ckVisible";
			this.ckVisible.Size = new System.Drawing.Size(62, 17);
			this.ckVisible.TabIndex = 10;
			this.ckVisible.Text = "Visibility";
			this.ckVisible.UseVisualStyleBackColor = true;
			this.ckVisible.CheckedChanged += new System.EventHandler(this.ckVisible_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 25);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 17);
			this.label9.TabIndex = 9;
			this.label9.Text = "Opacity";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sbOpacity
			// 
			this.sbOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sbOpacity.Location = new System.Drawing.Point(72, 25);
			this.sbOpacity.Maximum = 1000;
			this.sbOpacity.Name = "sbOpacity";
			this.sbOpacity.Size = new System.Drawing.Size(198, 17);
			this.sbOpacity.TabIndex = 0;
			this.sbOpacity.Value = 100;
			this.sbOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbOpacity_Scroll);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btResetFit);
			this.groupBox4.Controls.Add(this.cbFit);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.btReset);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.cbClipper);
			this.groupBox4.Location = new System.Drawing.Point(11, 212);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(276, 88);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Relations";
			// 
			// btResetFit
			// 
			this.btResetFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btResetFit.Image = global::titler.Properties.Resources.delete;
			this.btResetFit.Location = new System.Drawing.Point(242, 43);
			this.btResetFit.Name = "btResetFit";
			this.btResetFit.Size = new System.Drawing.Size(28, 28);
			this.btResetFit.TabIndex = 15;
			this.btResetFit.UseVisualStyleBackColor = true;
			this.btResetFit.Click += new System.EventHandler(this.btResetFit_Click);
			// 
			// cbFit
			// 
			this.cbFit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFit.FormattingEnabled = true;
			this.cbFit.Location = new System.Drawing.Point(72, 48);
			this.cbFit.Name = "cbFit";
			this.cbFit.Size = new System.Drawing.Size(164, 21);
			this.cbFit.TabIndex = 14;
			this.cbFit.SelectedIndexChanged += new System.EventHandler(this.cbFit_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 49);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 17);
			this.label11.TabIndex = 13;
			this.label11.Text = "Fit";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btReset
			// 
			this.btReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btReset.Image = global::titler.Properties.Resources.delete;
			this.btReset.Location = new System.Drawing.Point(242, 14);
			this.btReset.Name = "btReset";
			this.btReset.Size = new System.Drawing.Size(28, 28);
			this.btReset.TabIndex = 12;
			this.btReset.UseVisualStyleBackColor = true;
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 17);
			this.label10.TabIndex = 11;
			this.label10.Text = "Clip";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbClipper
			// 
			this.cbClipper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbClipper.FormattingEnabled = true;
			this.cbClipper.Location = new System.Drawing.Point(72, 19);
			this.cbClipper.Name = "cbClipper";
			this.cbClipper.Size = new System.Drawing.Size(164, 21);
			this.cbClipper.TabIndex = 0;
			this.cbClipper.SelectedIndexChanged += new System.EventHandler(this.cbElements_SelectedIndexChanged);
			// 
			// ElementEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ElementEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(298, 311);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nuW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuY)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nuMT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuML)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nuW;
		private System.Windows.Forms.NumericUpDown nuH;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nuX;
		private System.Windows.Forms.NumericUpDown nuY;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nuMT;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nuMR;
		private System.Windows.Forms.NumericUpDown nuMB;
		private System.Windows.Forms.NumericUpDown nuML;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox ckVisible;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.HScrollBar sbOpacity;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbClipper;
		private System.Windows.Forms.Button btReset;
		private System.Windows.Forms.Button btResetFit;
		private System.Windows.Forms.ComboBox cbFit;
		private System.Windows.Forms.Label label11;
	}
}
