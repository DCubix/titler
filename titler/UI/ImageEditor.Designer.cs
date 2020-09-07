namespace titler.UI {
	partial class ImageEditor {
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
			this.btOpenImage = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuY)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nuW);
			this.groupBox1.Controls.Add(this.nuH);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nuX);
			this.groupBox1.Controls.Add(this.nuY);
			this.groupBox1.Location = new System.Drawing.Point(193, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(151, 133);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Source";
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
			this.nuW.Name = "nuW";
			this.nuW.Size = new System.Drawing.Size(84, 20);
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
			this.nuH.Name = "nuH";
			this.nuH.Size = new System.Drawing.Size(84, 20);
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
			this.nuX.Name = "nuX";
			this.nuX.Size = new System.Drawing.Size(84, 20);
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
			this.nuY.Name = "nuY";
			this.nuY.Size = new System.Drawing.Size(84, 20);
			this.nuY.TabIndex = 2;
			this.nuY.ValueChanged += new System.EventHandler(this.nuY_ValueChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btOpenImage);
			this.groupBox2.Location = new System.Drawing.Point(11, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 133);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Image";
			// 
			// btOpenImage
			// 
			this.btOpenImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btOpenImage.Dock = System.Windows.Forms.DockStyle.Top;
			this.btOpenImage.Location = new System.Drawing.Point(3, 16);
			this.btOpenImage.Name = "btOpenImage";
			this.btOpenImage.Size = new System.Drawing.Size(170, 111);
			this.btOpenImage.TabIndex = 0;
			this.btOpenImage.UseVisualStyleBackColor = true;
			this.btOpenImage.Click += new System.EventHandler(this.btOpenImage_Click);
			// 
			// ImageEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ImageEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(355, 152);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nuW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuY)).EndInit();
			this.groupBox2.ResumeLayout(false);
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
		private System.Windows.Forms.Button btOpenImage;
	}
}
