namespace MissionPlanner.UAS4STEMCompetition {
	partial class InitializeTarget {
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
			this.typeLabel = new System.Windows.Forms.Label();
			this.typeSelector = new System.Windows.Forms.ComboBox();
			this.unknownTargetDesc = new System.Windows.Forms.TextBox();
			this.letter = new System.Windows.Forms.TextBox();
			this.letterLabel = new System.Windows.Forms.Label();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.confirmButton = new MissionPlanner.Controls.MyButton();
			this.SuspendLayout();
			// 
			// typeLabel
			// 
			this.typeLabel.AutoSize = true;
			this.typeLabel.Location = new System.Drawing.Point(22, 16);
			this.typeLabel.Name = "typeLabel";
			this.typeLabel.Size = new System.Drawing.Size(31, 13);
			this.typeLabel.TabIndex = 0;
			this.typeLabel.Text = "Type";
			// 
			// typeSelector
			// 
			this.typeSelector.FormattingEnabled = true;
			this.typeSelector.Items.AddRange(new object[] {
            "--Select Type--",
            "Drop Target",
            "Letter Target",
            "Unknown Target"});
			this.typeSelector.Location = new System.Drawing.Point(59, 13);
			this.typeSelector.Name = "typeSelector";
			this.typeSelector.Size = new System.Drawing.Size(121, 21);
			this.typeSelector.TabIndex = 1;
			this.typeSelector.SelectedIndexChanged += new System.EventHandler(this.typeSelector_SelectedIndexChanged);
			// 
			// unknownTargetDesc
			// 
			this.unknownTargetDesc.Location = new System.Drawing.Point(59, 49);
			this.unknownTargetDesc.Name = "unknownTargetDesc";
			this.unknownTargetDesc.Size = new System.Drawing.Size(100, 20);
			this.unknownTargetDesc.TabIndex = 2;
			this.unknownTargetDesc.Visible = false;
			this.unknownTargetDesc.TextChanged += new System.EventHandler(this.unknownTargetDesc_TextChanged);
			// 
			// letter
			// 
			this.letter.Location = new System.Drawing.Point(59, 49);
			this.letter.Name = "letter";
			this.letter.Size = new System.Drawing.Size(100, 20);
			this.letter.TabIndex = 3;
			this.letter.Visible = false;
			this.letter.TextChanged += new System.EventHandler(this.letter_TextChanged);
			// 
			// letterLabel
			// 
			this.letterLabel.AutoSize = true;
			this.letterLabel.Location = new System.Drawing.Point(18, 52);
			this.letterLabel.Name = "letterLabel";
			this.letterLabel.Size = new System.Drawing.Size(34, 13);
			this.letterLabel.TabIndex = 5;
			this.letterLabel.Text = "Letter";
			this.letterLabel.Visible = false;
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new System.Drawing.Point(21, 52);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(32, 13);
			this.descriptionLabel.TabIndex = 6;
			this.descriptionLabel.Text = "Desc";
			this.descriptionLabel.Visible = false;
			// 
			// confirmButton
			// 
			this.confirmButton.Location = new System.Drawing.Point(59, 91);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(75, 23);
			this.confirmButton.TabIndex = 7;
			this.confirmButton.Text = "Confirm";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// InitializeTarget
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(185, 126);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.descriptionLabel);
			this.Controls.Add(this.letterLabel);
			this.Controls.Add(this.letter);
			this.Controls.Add(this.unknownTargetDesc);
			this.Controls.Add(this.typeSelector);
			this.Controls.Add(this.typeLabel);
			this.Name = "InitializeTarget";
			this.Text = "InitializeTarget";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label typeLabel;
		private System.Windows.Forms.ComboBox typeSelector;
		private System.Windows.Forms.TextBox unknownTargetDesc;
		private System.Windows.Forms.TextBox letter;
		private System.Windows.Forms.Label letterLabel;
		private System.Windows.Forms.Label descriptionLabel;
		private Controls.MyButton confirmButton;
	}
}