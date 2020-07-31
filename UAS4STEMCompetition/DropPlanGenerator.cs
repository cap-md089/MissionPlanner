using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MissionPlanner.UAS4STEMCompetition {
	public partial class DropPlanGenerator : Form {
		public static CurrentState cs {
			get {
				return MainV2.comPort.MAV.cs;
			}
		}

		public static string GenerateWaypointFile(IEnumerable<DropTarget> targets) {
			int waypointNumber = 0;
			string WaypointFileText = $"QGC WPL 110\r\n{waypointNumber++} 1 0 16 0 0 0 0 {cs.lat.ToString("N8")} {cs.lng.ToString("N8")} 16.440001 1\r\n";

			foreach (var target in targets) {
				// Takeoff command
				WaypointFileText += $"{waypointNumber++} 0 3 22 0 0 0 0 0 0 15.0 1\r\n";

				// Hover at takeoff
				WaypointFileText += $"{waypointNumber++} 0 3 16 0 0 0 0 {cs.lat.ToString("N8")} {cs.lng.ToString("N8")} 15.0 1\r\n";

				// Go to target
				WaypointFileText += $"{waypointNumber++} 0 3 16 0 0 0 0 {target.Latitude.ToString("N8")} {target.Longitude.ToString("N8")} 15 1\r\n";

				// Open servo
				WaypointFileText += $"{waypointNumber++} 0 3 183 6 1400 0 0 0 0 1\r\n";

				// Hover for 2 seconds
				WaypointFileText += $"{waypointNumber++} 0 3 16 2 0 0 0 {target.Latitude.ToString("N8")} {target.Longitude.ToString("N8")} 15 1\r\n";

				// Return to launch
				WaypointFileText += $"{waypointNumber++} 0 3 20 0 0 0 0 0 0 0 1\r\n";
			}

			string FileName = $"Plan {DateTime.Now.ToString("yyyy-MM-dd hh-mm")}.waypoints";

			string docsfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			string folderPath = Path.Combine(docsfolder, "uas4stem-logger");

			if (!Directory.Exists(folderPath)) {
				Directory.CreateDirectory(folderPath);
			}

			string filePath = Path.Combine(folderPath, FileName);

			File.WriteAllText(filePath, WaypointFileText);

			return filePath;
		}

		private IEnumerable<DropTarget> targets;

		private List<Controls.MyButton> addButtons = new List<Controls.MyButton>();
		private List<Controls.MyButton> removeButtons = new List<Controls.MyButton>();

		private List<bool> selected = new List<bool>();

		public DropPlanGenerator(IEnumerable<DropTarget> targets) {
			InitializeComponent();

			this.targets = targets;

			for (int i = 0; i < targets.Count(); i++) {
				this.addRow(targets.ElementAt(i), i);
			}

			Height = GetHeight(targets);
		}

		private int GetHeight(IEnumerable<DropTarget> targets) {
			return 45 * (2 + targets.Count());
		}

		private void addRow(DropTarget target, int index) {
			// The index above is the index in the array of targets
			// The index will be used as a display index, and row 0 is used by the 'generate' and 'cancel' buttons
			index++;

			this.selected.Add(false);

			var addButton = new Controls.MyButton {
				Location = new Point(12, 12 + 45 * index),
				Name = $"addButton_{index}",
				Size = new Size(60, 21),
				TabIndex = index * 2,
				Text = "Add",
				UseVisualStyleBackColor = true
			};
			// Convert between display index and data index
			addButton.Click += GetAddClickHandler(index - 1);

			this.addButtons.Add(addButton);
			this.Controls.Add(addButton);

			var removeButton = new Controls.MyButton {
				Location = new Point(84, 12 + 45 * index),
				Name = $"removeButton_{index}",
				Size = new Size(60, 21),
				TabIndex = index * 2 + 1,
				Text = "Remove",
				Enabled = false,
				UseVisualStyleBackColor = true
			};
			// Convert between display index and data index
			removeButton.Click += GetRemoveClickHandler(index - 1);

			this.Controls.Add(removeButton);
			this.removeButtons.Add(removeButton);

			var dropTargetIndexLabel = new Label {
				Location = new Point(156, 12 + 45 * index),
				Size = new Size(20, 21),
				Name = $"indexLabel_{index}",
				Text = $"{index}",
				TextAlign = ContentAlignment.MiddleLeft
			};

			this.Controls.Add(dropTargetIndexLabel);
		}

		private EventHandler GetAddClickHandler(int index) {
			return (object o, EventArgs a) => {
				addButtons.ElementAt(index).Enabled = false;
				{
					var selectedArray = selected.ToArray();
					selectedArray[index] = true;
					selected = new List<bool>(selectedArray);
				}
				removeButtons.ElementAt(index).Enabled = true;
			};
		}

		private EventHandler GetRemoveClickHandler(int index) {
			return (object o, EventArgs a) => {
				addButtons.ElementAt(index).Enabled = true;
				{
					var selectedArray = selected.ToArray();
					selectedArray[index] = false;
					selected = new List<bool>(selectedArray);
				}
				removeButtons.ElementAt(index).Enabled = false;
			};
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void generatePlan_Click(object sender, EventArgs e) {
			this.Close();
			MainV2.instance.BeginInvoke((Action)delegate () {
				var dropTargets = new List<DropTarget>();
				for (int i = 0; i < targets.Count(); i++) {
					if (selected.ElementAt(i)) {
						dropTargets.Add(targets.ElementAt(i));
					}
				}

				var filePath = GenerateWaypointFile(dropTargets);

				MainV2.instance.MenuFlightPlanner_Click(null, null);
				MainV2.instance.FlightPlanner.readQGC110wpfile(filePath, false);
			});
		}
	}
}
