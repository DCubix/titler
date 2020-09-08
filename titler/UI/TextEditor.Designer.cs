namespace titler.UI {
	partial class TextEditor {
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
			this.ckAutoSize = new System.Windows.Forms.CheckBox();
			this.cbHAlign = new System.Windows.Forms.ComboBox();
			this.cbVAlign = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btSelectFont = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btFill = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckAutoSize);
			this.groupBox1.Controls.Add(this.cbHAlign);
			this.groupBox1.Controls.Add(this.cbVAlign);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.btSelectFont);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txText);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btFill);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(332, 281);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text";
			// 
			// ckAutoSize
			// 
			this.ckAutoSize.AutoSize = true;
			this.ckAutoSize.Location = new System.Drawing.Point(131, 240);
			this.ckAutoSize.Name = "ckAutoSize";
			this.ckAutoSize.Size = new System.Drawing.Size(71, 17);
			this.ckAutoSize.TabIndex = 28;
			this.ckAutoSize.Text = "Auto Size";
			this.ckAutoSize.UseVisualStyleBackColor = true;
			this.ckAutoSize.CheckedChanged += new System.EventHandler(this.ckAutoSize_CheckedChanged);
			// 
			// cbHAlign
			// 
			this.cbHAlign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbHAlign.FormattingEnabled = true;
			this.cbHAlign.Items.AddRange(new object[] {
            "Near",
            "Center",
            "Far"});
			this.cbHAlign.Location = new System.Drawing.Point(131, 186);
			this.cbHAlign.Name = "cbHAlign";
			this.cbHAlign.Size = new System.Drawing.Size(192, 21);
			this.cbHAlign.TabIndex = 26;
			this.cbHAlign.SelectedIndexChanged += new System.EventHandler(this.cbHAlign_SelectedIndexChanged);
			// 
			// cbVAlign
			// 
			this.cbVAlign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbVAlign.FormattingEnabled = true;
			this.cbVAlign.Items.AddRange(new object[] {
            "Near",
            "Center",
            "Far"});
			this.cbVAlign.Location = new System.Drawing.Point(131, 213);
			this.cbVAlign.Name = "cbVAlign";
			this.cbVAlign.Size = new System.Drawing.Size(192, 21);
			this.cbVAlign.TabIndex = 25;
			this.cbVAlign.SelectedIndexChanged += new System.EventHandler(this.cbVAlign_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 212);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 20);
			this.label5.TabIndex = 24;
			this.label5.Text = "Vertical Alignment";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 20);
			this.label4.TabIndex = 23;
			this.label4.Text = "Horizontal Alignment";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btSelectFont
			// 
			this.btSelectFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btSelectFont.Location = new System.Drawing.Point(131, 157);
			this.btSelectFont.Name = "btSelectFont";
			this.btSelectFont.Size = new System.Drawing.Size(192, 23);
			this.btSelectFont.TabIndex = 22;
			this.btSelectFont.Text = "Select Font";
			this.btSelectFont.UseVisualStyleBackColor = true;
			this.btSelectFont.Click += new System.EventHandler(this.btSelectFont_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 158);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 20);
			this.label3.TabIndex = 21;
			this.label3.Text = "Font";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txText
			// 
			this.txText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txText.Location = new System.Drawing.Point(131, 56);
			this.txText.Multiline = true;
			this.txText.Name = "txText";
			this.txText.Size = new System.Drawing.Size(192, 95);
			this.txText.TabIndex = 20;
			this.txText.TextChanged += new System.EventHandler(this.txText_TextChanged);
			this.txText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txText_KeyDown);
			this.txText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txText_KeyPress);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 20);
			this.label2.TabIndex = 19;
			this.label2.Text = "Text";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.btFill.Size = new System.Drawing.Size(192, 23);
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
			// TextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.groupBox1);
			this.Name = "TextEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(348, 297);
			this.Load += new System.EventHandler(this.TextEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btFill;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btSelectFont;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbHAlign;
		private System.Windows.Forms.ComboBox cbVAlign;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox ckAutoSize;
	}
}
