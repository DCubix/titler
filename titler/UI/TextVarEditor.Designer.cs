namespace titler.UI {
	partial class TextVarEditor {
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
			this.txValue = new System.Windows.Forms.TextBox();
			this.btApply = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txValue
			// 
			this.txValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txValue.Location = new System.Drawing.Point(11, 11);
			this.txValue.Multiline = true;
			this.txValue.Name = "txValue";
			this.txValue.Size = new System.Drawing.Size(268, 78);
			this.txValue.TabIndex = 0;
			// 
			// btApply
			// 
			this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btApply.Image = global::titler.Properties.Resources.accept;
			this.btApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btApply.Location = new System.Drawing.Point(204, 95);
			this.btApply.Name = "btApply";
			this.btApply.Size = new System.Drawing.Size(75, 23);
			this.btApply.TabIndex = 1;
			this.btApply.Text = "Apply";
			this.btApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btApply.UseVisualStyleBackColor = true;
			this.btApply.Click += new System.EventHandler(this.btApply_Click);
			// 
			// TextVarEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.btApply);
			this.Controls.Add(this.txValue);
			this.Name = "TextVarEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(290, 128);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txValue;
		private System.Windows.Forms.Button btApply;
	}
}
