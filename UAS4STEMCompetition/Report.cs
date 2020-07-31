using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using MissionPlanner.GCSViews;

namespace MissionPlanner.UAS4STEMCompetition {
	public enum Battery : int {
		UNASSIGNED = -1,
		GRP110 = 0,
		GRP111 = 1,
		GRP112 = 2,
		GRP114 = 3
	}

	public class FlightReport {
		public LinkedList<Target> Targets = new LinkedList<Target>();
		public int FlightTime { get; set; }
		public LinkedList<double> BatteryVoltages = new LinkedList<double>();
		public Battery BatteryFlown { get; set; }
		public DateTime StartTime;

		private DateTime LastBatterySaveTime { get; set; }

		private EventHandler CSChangeHandler;

		public FlightReport() {
			StartTime = DateTime.Now;
			CSChangeHandler = new EventHandler(HandleCSChange);
			MainV2.comPort.MAV.cs.csCallBack += CSChangeHandler;
			LastBatterySaveTime = DateTime.Now;
			BatteryFlown = Battery.UNASSIGNED;
		}

		public void HandleCSChange(object o, EventArgs a) {
			if ((DateTime.Now - LastBatterySaveTime).Seconds > 20) {
				LastBatterySaveTime = DateTime.Now;
				BatteryVoltages.AddLast(MainV2.comPort.MAV.cs.battery_voltage);
			}
		}

		public void FinishFlight() {
			MainV2.comPort.MAV.cs.csCallBack -= CSChangeHandler;
			MissionState.Initialize();
		}

		public IEnumerable<DropTarget> GetDropTargets() {
			return (from target in this.Targets where target is DropTarget select target).Cast<DropTarget>();
		}

		public IEnumerable<GMapMarker> GetTargetMarkers(int reportID) {
			var markers = new List<GMapMarker>();
			for (int i = 0; i < Targets.Count(); i++) {
				var target = Targets.ElementAt(i);
				markers.Add(target.getMarker(reportID, i));
			}

			return markers;
		}
	}

	public class MissionReport {
		public LinkedList<FlightReport> FlightReports = new LinkedList<FlightReport>();
		public LinkedList<Target> MiscTargets = new LinkedList<Target>();
		public DateTime StartTime { get; set; }

		public MissionReport() {
			StartTime = DateTime.Now;
			if (FlightData.instance != null)
			{
				FlightData.instance.gMapControl1.OnMarkerClick += new MarkerClick(markerClick);
			}
		}

		private void markerClick(GMapMarker marker, object e) {
			for (int i = 0; i < FlightReports.Count(); i++) {
				var report = FlightReports.ElementAt(i);
				for (int j = 0; j < report.Targets.Count(); j++) {
					var target = report.Targets.ElementAt(j);
					if (target.getMarker(i, j).ToolTipText.Equals(marker.ToolTipText)) {
						report.Targets.Remove(target);
						AddTargetsToMap();
						return;
					}
				}
			}

			for (int i = 0; i < MiscTargets.Count(); i++) {
				var target = MiscTargets.ElementAt(i);
				if (target.getMarker(-1, i).ToolTipText.Equals(marker.ToolTipText)) {
					MiscTargets.Remove(target);
					AddTargetsToMap();
					return;
				}
			}
		}

		public int GetFlightTimeForBattery(Battery batt) {
			return (from report in this.FlightReports where report.BatteryFlown == batt select report.FlightTime).Sum();
		}

		public IEnumerable<DropTarget> GetDropTargets() {
			var miscTargets = (
				from target in MiscTargets
				where target is DropTarget
				select target
			).Cast<DropTarget>();
			return
				(
					from report in this.FlightReports
					from target in report.GetDropTargets()
					select target
				).Concat(miscTargets).OrderBy(t => t.TimeOfAcquisition);
		}

		public IEnumerable<Target> GetTargets() {
			return
				(
					from report in this.FlightReports
					from target in report.Targets
					select target
				).Concat(
					from target in MiscTargets
					select target
				).OrderBy(t => t.TimeOfAcquisition);
		}

		public IEnumerable<GMapMarker> GetTargetMarkers() {
			var markers = new List<GMapMarker>();

			for (int i = 0; i < FlightReports.Count(); i++) {
				var report = FlightReports.ElementAt(i);
				for (int j = 0; j < report.Targets.Count(); j++) {
					markers.Add(report.Targets.ElementAt(j).getMarker(i, j));
				}
			}	

			for (int i = 0; i < MiscTargets.Count(); i++) {
				markers.Add(MiscTargets.ElementAt(i).getMarker(-1, i));
			}

			return markers;
		}

		public void AddTargetsToMap() {
			MethodInvoker m = () => {
				string id = "targetoverlay";
				var gMapControl1 = FlightData.instance.gMapControl1;

				var existing = gMapControl1.Overlays.Where(a => a.Id == id).ToList();
				foreach (var b in existing) {
					gMapControl1.Overlays.Remove(b);
				}

				var targetoverlay = new GMapOverlay(id);

				foreach (var marker in this.GetTargetMarkers()) {
					targetoverlay.Markers.Add(marker);
				}

				gMapControl1.Overlays.Add(targetoverlay);

				targetoverlay.ForceUpdate();
			};
			FlightData.instance.BeginInvoke(m);
		}

		private static string[] batteries = new string[] {
			"GRP110",
			"GRP111",
			"GRP112",
			"GRP114"
		};

		private string GetReport(bool getPossibleWords) {
			string Report = "";

			Report += $"-=- Mission report {StartTime.ToString()} -=-\n\n-- Notes --\n\n\n";

			var targets = GetTargets();

			Report += $"-- Targets ({targets.Count()} found) --\n\n";
			foreach (var target in targets) {
				string name =
					target is DropTarget
					? "DROP"
					: target is LetterTarget
						? "LETTER"
						: "UNKNOWN";

				string desc =
					target is DropTarget
					? ""
					: target is LetterTarget
						? $": {((LetterTarget)target).letter}"
						: $": \"{((UnknownTarget)target).description}\"";

				Report += $"{name}{desc}; {target.Latitude.ToString("N5")}, {target.Longitude.ToString("N5")}\n";
			}


			Report += "\n\n";

			if (getPossibleWords) {

				Report += $"-- Possible words from targets --\n\n";

				var words = ScrabbleHandler.GetWordsForTargets(targets);

				foreach (var word in words) {
					Report += $"{word.ToUpper()}\n";
				}

				Report += "\n\n";
			}

			int[] batteryTimes = new int[batteries.Length];

			Report += $"-- Batteries used ({FlightReports.Count()} flight{(FlightReports.Count() == 1 ? "" : "s")}) --\n\n";
			for (int i = 0; i < FlightReports.Count(); i++) {
				var flight = FlightReports.ElementAt(i);

				if (flight.BatteryFlown == Battery.UNASSIGNED) {
					continue;
				}

				batteryTimes[(int)flight.BatteryFlown] += flight.FlightTime;

				Report += $"Flight {i + 1}: Battery {batteries[(int)flight.BatteryFlown]}, {flight.FlightTime} second flight ({flight.FlightTime / 60}:{(flight.FlightTime % 60).ToString("00")}) \n";
			}

			Report += "\n\n";

			Report += $"-- Battery flight times --\n\n";
			for (int i = 0; i < batteryTimes.Length; i++) {
				Report += $"Battery {batteries[i]}: {batteryTimes[i]} seconds ({batteryTimes[i] / 60}:{(batteryTimes[i] % 60).ToString("00")})\n";
			}

			Report += "\n\n";

			Report += $"-- Battery voltages ({FlightReports.Count()} flight{(FlightReports.Count() == 1 ? "" : "s")}) --\n\n";
			for (int i = 0; i < FlightReports.Count(); i++) {
				var flight = FlightReports.ElementAt(i);

				if (flight.BatteryFlown == Battery.UNASSIGNED) {
					continue;
				}

				Report += $"- Flight {i + 1}: battery {batteries[(int)flight.BatteryFlown]} -\n";

				for (int j = 0; j < flight.BatteryVoltages.Count(); j++) {
					Report += $"	{(j + 1) * 20}s. {flight.BatteryVoltages.ElementAt(i)}\n";
				}

				Report += "\n";
			}

			Report += "\n\n-- Report end --\n";

			return Report;
		}

		public void SaveReport(bool getPossibleWords) {
			string FileName = "MissionReport-" + StartTime.ToString("MM-dd-yyyy_HH-mm") + ".txt";

			string docsfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			string folderPath = Path.Combine(docsfolder, "uas4stem-logger");

			if (!Directory.Exists(folderPath)) {
				Directory.CreateDirectory(folderPath);
			}

			string filePath = Path.Combine(folderPath, FileName);

			File.WriteAllText(filePath, GetReport(getPossibleWords));
		}
	}
}
