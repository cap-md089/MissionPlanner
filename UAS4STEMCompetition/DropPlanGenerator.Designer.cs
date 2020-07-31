namespace MissionPlanner.UAS4STEMCompetition {
	partial class DropPlanGenerator {
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
			this.generatePlan = new MissionPlanner.Controls.MyButton();
			this.cancelButton = new MissionPlanner.Controls.MyButton();
			this.SuspendLayout();
			// 
			// generatePlan
			// 
			this.generatePlan.Location = new System.Drawing.Point(12, 12);
			this.generatePlan.Name = "generatePlan";
			this.generatePlan.Size = new System.Drawing.Size(121, 23);
			this.generatePlan.TabIndex = 0;
			this.generatePlan.Text = "Generate plan";
			this.generatePlan.UseVisualStyleBackColor = true;
			this.generatePlan.Click += new System.EventHandler(this.generatePlan_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(155, 12);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(122, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// DropPlanGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 45);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.generatePlan);
			this.Name = "DropPlanGenerator";
			this.Text = "DropPlanGenerator";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.MyButton generatePlan;
		private Controls.MyButton cancelButton;
	}
}