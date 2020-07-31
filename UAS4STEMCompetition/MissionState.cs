using System;

namespace MissionPlanner.UAS4STEMCompetition {
	public class MissionState {
		public static MissionReport Mission = new MissionReport();

		public static CurrentState cs {
			get {
				return MainV2.comPort.MAV.cs;
			}
		}

		public static bool IsFlying = false;
		public static bool GetPossibleWords = false;

		public static EventHandler OnTakeoff;
		public static EventHandler OnLand;

		public static DateTime? TakeoffTimestamp = null;

		public static Battery? NextMissionBattery = null;

		public static TimeSpan? FlightTime {
			get {
				return DateTime.Now - TakeoffTimestamp;
			}
		}

		public static DateTime? MissionStart = null;

		public static float LandTime {
			get {
				float highDescentCMs = GetParam("LAND_SPEED_HIGH");
				if (highDescentCMs == 0) {
					highDescentCMs = GetParam("WPNAV_SPEED_DN");
				}
				float lowDescentCMs = GetParam("LAND_SPEED");

				highDescentCMs /= 100;
				lowDescentCMs /= 100;

				float highLandDist = Math.Max(cs.alt - (GetParam("LAND_ALT_LOW") / 100), 0);
				float lowLandDist = Math.Min(cs.alt, 10);

				return lowDescentCMs * lowLandDist + highDescentCMs * highLandDist;
			}
		}

		public static float TimeToHome {
			get {
				// 1.23 is a magic number
				return (cs.DistToHome / (GetParam("WPNAV_SPEED") / 100)) * 1.23f;
			}
		}

		public static FlightReport CurrentFlightReport = null;

		private static int PreviousWaypointNo = 0;

		public static void Initialize() {
			cs.csCallBack += new EventHandler(HandleCSChange);
		}

		private static void HandleCSChange(object o, EventArgs e) {
			float rcoverridech3percent = Math.Max((cs.rcoverridech3 - 1100f) / (1900f - 1100f) * 100f, 0f);

			if (
				(cs.ch3percent > 12 || rcoverridech3percent > 30 || cs.groundspeed > 3 || cs.mode.ToUpper().Equals("AUTO") || cs.alt > 9.0) &&
				cs.armed &&
				!IsFlying
			) {
				IsFlying = true;
				HandleTakeoff();

				if (MissionStart == null) {
					MissionStart = DateTime.Now;
				}
			}

			if (PreviousWaypointNo != (int)cs.wpno) {
				System.Media.SystemSounds.Beep.Play();
			}
			PreviousWaypointNo = (int)cs.wpno;

			if (
				IsFlying &&
				(
					!cs.armed ||
					(cs.ch3percent < 12 && rcoverridech3percent < 30 && cs.groundspeed < 3 && !cs.mode.ToUpper().Equals("AUTO") && cs.alt < 9.0)
				)
			) {
				IsFlying = false;
				HandleLand();
			}
		}

		private static void HandleTakeoff() {
			CurrentFlightReport = new FlightReport();

			Mission.FlightReports.AddLast(CurrentFlightReport);

			if (NextMissionBattery.HasValue)
			{
				CurrentFlightReport.BatteryFlown = NextMissionBattery.Value;
			}

			TakeoffTimestamp = DateTime.Now;
			OnTakeoff?.Invoke(null, null);
		}

		private static void HandleLand() {
			int landingTime = (int)FlightTime.Value.TotalSeconds;

			if (CurrentFlightReport.BatteryFlown == Battery.UNASSIGNED) {
				CurrentFlightReport.BatteryFlown = new GetBatteryForm().GetBattery();
			}
			CurrentFlightReport.FlightTime = landingTime;
			CurrentFlightReport.FinishFlight();

			OnLand?.Invoke(null, null);

			CurrentFlightReport = null;

			Mission.SaveReport(GetPossibleWords);
		}

		public static void StopRecordingCoordinate(TargetBuilder targetBuilder) {
			var target = targetBuilder.Stop();

			if (CurrentFlightReport != null) {
				CurrentFlightReport.Targets.AddLast(target);
			} else {
				Mission.MiscTargets.AddLast(target);
			}

			Mission.AddTargetsToMap();

			Mission.SaveReport(GetPossibleWords);
		}

		public static void SetBatteryFlown(Battery batt) {
			if (CurrentFlightReport != null) {
				CurrentFlightReport.BatteryFlown = batt;
			}
		}

		private static float GetParam(string param) {
			if (MissionPlanner.MainV2.comPort.MAV.param[param] != null)
				try {
					return (float)MissionPlanner.MainV2.comPort.MAV.param[param];
				} catch (System.NullReferenceException ignore) {
					return 0.0f;
				}

			return 0.0f;
		}
	}
}
