using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Utilities;

namespace MissionPlanner.UAS4STEMCompetition {
	public partial class GetBatteryForm : Form {
		public GetBatteryForm() {
			InitializeComponent();

			batterySelectionBox.SelectedIndex = 0;

			ThemeManager.ApplyThemeTo(this);
		}

		public Battery GetBattery() {
			this.ShowDialog();
			return (Battery)(batterySelectionBox.SelectedIndex - 1);
		}

		private void batteryConfirmButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void batterySelectionBox_SelectedIndexChanged(object sender, EventArgs e) {
			batteryConfirmButton.Enabled = batterySelectionBox.SelectedIndex != 0;
		}
	}
}
