using System;
using System.Windows.Forms;

namespace MissionPlanner.UAS4STEMCompetition {
	public struct BasicTargetInfo {
		public TargetType type;

		public char letter;
		public string desc;
	}

	public partial class InitializeTarget : Form {
		public InitializeTarget() {
			InitializeComponent();

			this.typeSelector.SelectedIndex = 0;

			this.FormClosing += new FormClosingEventHandler(this.InitializeTarget_Closing);

            Utilities.ThemeManager.ApplyThemeTo(this);
		}

		public BasicTargetInfo getInfo(TargetType type, bool lockInput) {
			this.typeSelector.SelectedIndex = (int)type;
			this.typeSelector.Enabled = !lockInput;

			this.ShowDialog();

			var info = new BasicTargetInfo { };
			info.type = (TargetType)this.typeSelector.SelectedIndex;

			if (info.type == TargetType.LETTER) {
				info.letter = letter.Text[0];
			}

			if (info.type == TargetType.UNKNOWN) {
				info.desc = unknownTargetDesc.Text;
			}

			return info;
		}

		public static BasicTargetInfo GetInfo(TargetType type, bool lockInput) {
			return (new InitializeTarget()).getInfo(type, lockInput);
		}

		private void typeSelector_SelectedIndexChanged(object sender, EventArgs e) {
			switch ((TargetType)this.typeSelector.SelectedIndex) {
				case TargetType.UNASSIGNED:
					this.confirmButton.Enabled = false;

					this.descriptionLabel.Visible = false;
					this.unknownTargetDesc.Visible = false;

					this.letter.Visible = false;
					this.letterLabel.Visible = false;

					this.unknownTargetDesc.Text = "";
					this.letter.Text = "";
					break;

				case TargetType.LETTER:
					this.confirmButton.Enabled = false;

					this.descriptionLabel.Visible = false;
					this.unknownTargetDesc.Visible = false;

					this.letter.Visible = true;
					this.letterLabel.Visible = true;

					this.unknownTargetDesc.Text = "";
					this.letter.Text = "";
					break;

				case TargetType.DROP:
					this.confirmButton.Enabled = true;

					this.descriptionLabel.Visible = false;
					this.unknownTargetDesc.Visible = false;

					this.letter.Visible = false;
					this.letterLabel.Visible = false;

					this.unknownTargetDesc.Text = "";
					this.letter.Text = "";
					break;

				case TargetType.UNKNOWN:
					this.confirmButton.Enabled = false;

					this.descriptionLabel.Visible = true;
					this.unknownTargetDesc.Visible = true;

					this.letter.Visible = false;
					this.letterLabel.Visible = false;

					this.unknownTargetDesc.Text = "";
					this.letter.Text = "";
					break;
			}
		}

		/**
		 * Perform input validation on text change
		 */
		private void letter_TextChanged(object sender, EventArgs e) {
			if (letter.Text.Length > 1) {
				letter.Text = new string(new char[] { letter.Text[0] });
			}

			confirmButton.Enabled = false;

			if (letter.Text.Length == 0 || letter.Text[0] == '\0') {
				return;
			}

			if (letter.Text[0] > 64 && letter.Text[0] < 91) {
				confirmButton.Enabled = true;
				return;
			}

			if (letter.Text[0] > 96 && letter.Text[0] < 123) {
				letter.Text = new string(new char[] { (char)(letter.Text[0] - 32) });
				confirmButton.Enabled = true;
				return;
			}

			letter.Text = "";
		}

		private void confirmButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void unknownTargetDesc_TextChanged(object sender, EventArgs e) {
			confirmButton.Enabled = !unknownTargetDesc.Text.Equals("");
		}

		private void InitializeTarget_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel = !this.confirmButton.Enabled;
		}
	}
}
