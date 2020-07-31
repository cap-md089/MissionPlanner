using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner;

namespace MissionPlanner.UAS4STEMCompetition {
	public enum TargetType : int {
		UNASSIGNED,
		DROP,
		LETTER,
		UNKNOWN
	}

	public class TargetBuilder {
		private readonly LinkedList<double> Latitudes = new LinkedList<double>();
		private readonly LinkedList<double> Longitudes = new LinkedList<double>();

		private TargetType Type = TargetType.UNASSIGNED;
		private string UnknownDescription = null;
		private char Letter = '\0';

		private Action<object, EventArgs> addCoordinateCallback;

		public TargetBuilder () { }

		public void StartRecording() {
			addCoordinateCallback = (obj, e) => {
				this.Latitudes.AddLast(MainV2.comPort.MAV.cs.lat);
				this.Longitudes.AddLast(MainV2.comPort.MAV.cs.lng);
			};

			MainV2.comPort.MAV.cs.csCallBack += new EventHandler(addCoordinateCallback);
		}

		public Target Stop() {
			MainV2.comPort.MAV.cs.csCallBack -= new EventHandler(addCoordinateCallback);

			return this.GetTarget();
		}

		public void SetUnknownDescription(string desc) {
			this.UnknownDescription = desc;
			this.Type = TargetType.UNKNOWN;
		} 

		public void SetLetter(char letter) {
			this.Letter = letter;
			this.Type = TargetType.LETTER;
		}

		public void SetDrop() {
			this.Type = TargetType.DROP;
		}

		public void SetUnassigned() {
			this.Type = TargetType.UNASSIGNED;
		}

		private Target GetTarget() {
			Target target;

			if (
				Type == TargetType.UNASSIGNED
			) {
				var info = InitializeTarget.GetInfo(Type, false);

				switch (info.type) {
					case TargetType.DROP:
						target = new DropTarget();
						break;

					case TargetType.LETTER:
						target = new LetterTarget(info.letter);
						break;

					case TargetType.UNKNOWN:
						target = new UnknownTarget(info.desc);
						break;

					// Shouldn't get here, as InitializeTarget.GetInfo() doesn't return TargetType.UNASSIGNED
					default:
						target = null;
						break;
				}
			} else if (Type == TargetType.DROP) {
				target = new DropTarget();
			} else if (Type == TargetType.LETTER) {
				target = new LetterTarget(Letter);
			} else if (Type == TargetType.UNKNOWN) {
				target = new UnknownTarget(UnknownDescription);
			} else {
				// Shouldn't get here, covers all cases of TargetType
				target = null;
			}

			target.Latitude = Latitudes.Sum() / Latitudes.Count;
			target.Longitude = Longitudes.Sum() / Longitudes.Count;

			return target;
		}
	}

	public abstract class Target {
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int TimeOfAcquisition { get; set; }

		public abstract GMapMarker getMarker(int reportID, int targetID);
	}

	public class DropTarget : Target {
		public override GMapMarker getMarker(int reportID, int targetID) {
			var point = new PointLatLng(this.Latitude, this.Longitude);
			GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green) {
				ToolTipText = "Drop target" + $" ({reportID}, {targetID})"
			};

			return marker;
		}
	}

	public class LetterTarget : Target {
		public char letter;

		public LetterTarget(char letter) {
			this.letter = letter;
		}

		public override GMapMarker getMarker(int reportID, int targetID) {
			var point = new PointLatLng(this.Latitude, this.Longitude);
			GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.yellow) {
				Tag = $"{this.letter}",
				ToolTipText = "Letter target: " + letter + $" ({reportID}, {targetID})"
			};

			return marker;
		}
	}

	public class UnknownTarget : Target {
		public string description;

		public UnknownTarget(string desc) {
			this.description = desc;
		}

		public override GMapMarker getMarker(int reportID, int targetID) {
			var point = new PointLatLng(this.Latitude, this.Longitude);
			GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue) {
				ToolTipText = "Unkonwn target: " + description + $" ({reportID}, {targetID})"
			};

			return marker;
		}
	}
}
