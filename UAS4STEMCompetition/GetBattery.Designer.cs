namespace MissionPlanner.UAS4STEMCompetition {
	partial class GetBatteryForm {
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
			this.batteryConfirmButton = new MissionPlanner.Controls.MyButton();
			this.batterySelectionBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// batteryConfirmButton
			// 
			this.batteryConfirmButton.Location = new System.Drawing.Point(69, 39);
			this.batteryConfirmButton.Name = "batteryConfirmButton";
			this.batteryConfirmButton.Size = new System.Drawing.Size(75, 23);
			this.batteryConfirmButton.TabIndex = 0;
			this.batteryConfirmButton.Text = "Select";
			this.batteryConfirmButton.UseVisualStyleBackColor = true;
			this.batteryConfirmButton.Click += new System.EventHandler(this.batteryConfirmButton_Click);
			// 
			// batterySelectionBox
			// 
			this.batterySelectionBox.FormattingEnabled = true;
			this.batterySelectionBox.Items.AddRange(new object[] {
            "--Select a battery--",
            "GRP 110",
            "GRP 111",
            "GRP 112",
            "GRP 114"});
			this.batterySelectionBox.Location = new System.Drawing.Point(12, 12);
			this.batterySelectionBox.Name = "batterySelectionBox";
			this.batterySelectionBox.Size = new System.Drawing.Size(195, 21);
			this.batterySelectionBox.TabIndex = 1;
			this.batterySelectionBox.SelectedIndexChanged += new System.EventHandler(this.batterySelectionBox_SelectedIndexChanged);
			// 
			// GetBattery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 72);
			this.Controls.Add(this.batterySelectionBox);
			this.Controls.Add(this.batteryConfirmButton);
			this.Name = "GetBattery";
			this.Text = "GetBattery";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.MyButton batteryConfirmButton;
		private System.Windows.Forms.ComboBox batterySelectionBox;
	}
}