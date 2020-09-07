namespace titler.UI {
	partial class AnimationEditor {
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
			this.cbAnimations = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pgProps = new System.Windows.Forms.PropertyGrid();
			this.btPlayStop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbAnimations
			// 
			this.cbAnimations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAnimations.FormattingEnabled = true;
			this.cbAnimations.Items.AddRange(new object[] {
            "None",
            "Fade",
            "Reveal"});
			this.cbAnimations.Location = new System.Drawing.Point(120, 9);
			this.cbAnimations.Name = "cbAnimations";
			this.cbAnimations.Size = new System.Drawing.Size(164, 21);
			this.cbAnimations.TabIndex = 0;
			this.cbAnimations.SelectedIndexChanged += new System.EventHandler(this.cbAnimations_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Animation";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pgProps
			// 
			this.pgProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgProps.Location = new System.Drawing.Point(11, 36);
			this.pgProps.Name = "pgProps";
			this.pgProps.Size = new System.Drawing.Size(273, 293);
			this.pgProps.TabIndex = 5;
			// 
			// btPlayStop
			// 
			this.btPlayStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btPlayStop.Enabled = false;
			this.btPlayStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btPlayStop.Location = new System.Drawing.Point(195, 255);
			this.btPlayStop.Name = "btPlayStop";
			this.btPlayStop.Size = new System.Drawing.Size(75, 23);
			this.btPlayStop.TabIndex = 6;
			this.btPlayStop.Tag = "P";
			this.btPlayStop.Text = "Play";
			this.btPlayStop.UseVisualStyleBackColor = true;
			this.btPlayStop.Visible = false;
			this.btPlayStop.Click += new System.EventHandler(this.btPlayStop_Click);
			// 
			// AnimationEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btPlayStop);
			this.Controls.Add(this.pgProps);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbAnimations);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "AnimationEditor";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Size = new System.Drawing.Size(295, 340);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbAnimations;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PropertyGrid pgProps;
		private System.Windows.Forms.Button btPlayStop;
	}
}
