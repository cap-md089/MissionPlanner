using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Utilities;

namespace MissionPlanner.UAS4STEMCompetition {
	public partial class CompetitionEmbeddedMenu : UserControl {
		private TargetBuilder targetBuilder = null;

		private CurrentState cs {
			get {
				return MainV2.comPort.MAV.cs;
			}
		}

		private EventHandler handleChange = null;
		private EventHandler handleLand = null;
		private EventHandler handleTakeoff = null;

		private int? IdealBatteryTime {
			get {
				if (!int.TryParse(idealBatteryTimeInput.Text, out int result)) {
					return null;
				}
				return result;
			}
		}

		private int CurrentBatteryTime {
			get {
				int batteryTime = (int)MissionState.FlightTime.Value.TotalSeconds;
				var currentBattery = (Battery)(batteryComboBox.SelectedIndex - 1);
				if (currentBattery != Battery.UNASSIGNED) {
					batteryTime = (
						from report
						in MissionState.Mission.FlightReports
						where report.BatteryFlown == currentBattery
						select report.FlightTime
					).Sum() + (int)MissionState.FlightTime.Value.TotalSeconds;
				}

				return batteryTime;
			}
		}

		public CompetitionEmbeddedMenu() {
			InitializeComponent();
		}

		public void Initialize()
		{
			ThemeManager.ApplyThemeTo(this);

			handleChange = new EventHandler(this.HandleCSChange);
			cs.csCallBack += handleChange;
			MissionState.Initialize();

			handleLand = new EventHandler(this.HandleUAVLand);
			MissionState.OnLand += handleLand;

			handleTakeoff = new EventHandler(this.HandleUAVTakeoff);
			MissionState.OnTakeoff += handleTakeoff;

			armedLabel.ForeColor = Color.FromArgb(255, 0, 0);
			flyingLabel.ForeColor = Color.FromArgb(255, 0, 0);
		}

		private void CompetitionEmbeddedMenu_Load(object sender, EventArgs e) {
			targetType.SelectedIndex = 0;
			batteryComboBox.SelectedIndex = 0;

			armedLabel.ForeColor = Color.FromArgb(255, 0, 0);

			var s = letterInput.Size;
			s.Height = 20;

			idealBatteryTimeInput.Text = Settings.Instance["UAS4STEM_IdealBatteryTime", "480"];

			controllerSafetySwitchCheck.Checked = Settings.Instance["UAS4STEM_SafetySwitchCheck", "FALSE"].Equals("TRUE");
			if (controllerSafetySwitchCheck.Checked) {
				checkForStartStopOnController.Start();
			}

			getPossibleWordsCheckbox.Checked = Settings.Instance["UAS4STEM_GetPossibleWords", "FALSE"].Equals("TRUE");
			if (getPossibleWordsCheckbox.Checked) {
				MissionState.GetPossibleWords = true;
			}
		}

		private void startRecording() {
			targetBuilder = new TargetBuilder();
			targetBuilder.StartRecording();

			startStopRecording.Text = "Stop recording";
		}

		private void stopRecording() {
			var info = new BasicTargetInfo { };
			if (
				(targetType.SelectedIndex == (int)TargetType.UNASSIGNED) ||
				(targetType.SelectedIndex == (int)TargetType.LETTER && letterInput.Text.Length != 1) ||
				(targetType.SelectedIndex == (int)TargetType.UNKNOWN && unknownDescriptionInput.Text.Length == 0)
			) {
				info = InitializeTarget.GetInfo((TargetType)targetType.SelectedIndex, false);
			} else {
				switch ((TargetType)targetType.SelectedIndex) {
					case TargetType.DROP:
						info.type = TargetType.DROP;
						break;

					case TargetType.LETTER:
						info.letter = letterInput.Text[0];
						info.type = TargetType.LETTER;
						break;

					case TargetType.UNKNOWN:
						info.desc = unknownDescriptionInput.Text;
						info.type = TargetType.UNKNOWN;
						break;
				}
			}

			switch (info.type) {
				case TargetType.DROP:
					targetBuilder.SetDrop();
					break;

				case TargetType.LETTER:
					targetBuilder.SetLetter(info.letter);
					break;

				case TargetType.UNKNOWN:
					targetBuilder.SetUnknownDescription(info.desc);
					break;
			}

			MissionState.StopRecordingCoordinate(targetBuilder);

			targetBuilder = null;

			Action m = () => {
				letterInput.Text = "";
				unknownDescriptionInput.Text = "";
				targetType.SelectedIndex = 0;
				startStopRecording.Text = "Start Recording";
			};
			this.Invoke(m);
		}

		private void targetType_SelectedIndexChanged(object sender, EventArgs e) {
			if (
				targetType.SelectedIndex == (int)TargetType.UNASSIGNED ||
				targetType.SelectedIndex == (int)TargetType.DROP
			) {
				unknownDescriptionInput.Visible = false;
				unknownLabel.Visible = false;

				letterInput.Visible = false;
				letterLabel.Visible = false;

				if (targetBuilder != null) {
					if (targetType.SelectedIndex == (int)TargetType.UNASSIGNED) {
						targetBuilder.SetUnassigned();
					} else {
						targetBuilder.SetDrop();
					}
				}
			} else if (
				targetType.SelectedIndex == (int)TargetType.LETTER
			) {
				unknownDescriptionInput.Visible = false;
				unknownLabel.Visible = false;

				letterInput.Visible = true;
				letterLabel.Visible = true;

				if (targetBuilder != null) {
					targetBuilder.SetLetter('\0');
				}
			} else if (
				targetType.SelectedIndex == (int)TargetType.UNKNOWN
			) {
				unknownDescriptionInput.Visible = true;
				unknownLabel.Visible = true;

				letterInput.Visible = false;
				letterLabel.Visible = false;

				if (targetBuilder != null) {
					targetBuilder.SetUnknownDescription(null);
				}
			}
		}

		private void dropPlanGenerator_Click(object sender, EventArgs e) {
			new DropPlanGenerator(MissionState.Mission.GetDropTargets()).Show();
		}

		private void toggleArmButton_Click(object sender, EventArgs e) {
			MainV2.comPort.doARM(!cs.armed);
		}

		private void toggleServoButton_Click(object sender, EventArgs e) {
			MainV2.comPort.doCommand(MAVLink.MAV_CMD.DO_SET_SERVO, 6, cs.ch6out == 2400 ? 1400 : 2400, 0, 0, 0, 0, 0);
		}

		private void modeChangeRTLButton_Click(object sender, EventArgs e) {
			MainV2.comPort.setMode("RTL");
		}

		private void modeChangeAutoButton_Click(object sender, EventArgs e) {
			MainV2.comPort.setMode("AUTO");
		}

		private void modeChangePositionHold_Click(object sender, EventArgs e) {
			MainV2.comPort.setMode("PosHold");
		}

		private void modeChangeAltHold_Click(object sender, EventArgs e) {
			MainV2.comPort.setMode("AltHold");
		}

		private void HandleCSChange(object o, EventArgs e) {
			if (cs.armed) {
				SafeUpdateText(toggleArmButton, "Disarm");
				SafeUpdateText(armedLabel, "ARMED");
			} else {
				SafeUpdateText(toggleArmButton, "Arm");
				SafeUpdateText(armedLabel, "DISARMED");
			}

			if (MissionState.IsFlying) {
				// Flight time
				SafeUpdateText(flightTimeLabel, ConvertIntervalToMinuteSecondString((int)MissionState.FlightTime.Value.TotalSeconds));

				// Battery time
				SafeUpdateText(batteryTimeLabel, ConvertIntervalToMinuteSecondString(CurrentBatteryTime));

				// Remaining battery time
				UpdateRemainingBatteryTime();

				// Estimated time to land
				SafeUpdateText(timeToLandLabel, ConvertIntervalToMinuteSecondString((int)(MissionState.LandTime + MissionState.TimeToHome)));
			} else {
				SafeUpdateText(flightTimeLabel, "0:00");
				SafeUpdateText(batteryTimeLabel, "0:00");
				SafeUpdateText(remainingBatteryTimeLabel, "0:00");
				SafeUpdateText(timeToLandLabel, "0:00");
			}

			float rcoverridech3percent = Math.Max((cs.rcoverridech3 - 1100f) / (1900f - 1100f) * 100f, 0f);

			SafeUpdateText(altitudeDisplay, "" + cs.alt);
			SafeUpdateText(altitudeFeetLabel, "" + (cs.alt * 3.281));
			SafeUpdateText(ch3PercentDisplay, "" + cs.ch3percent);
			SafeUpdateText(rc3OverrideDisplay, "" + rcoverridech3percent);
			SafeUpdateText(modeDisplay, cs.mode.ToUpper());
			SafeUpdateText(groundSpeedDisplay, "" + cs.groundspeed);
		}

		private void triggerCameraButton_Click(object sender, EventArgs e) {
			MainV2.instance.Invoke((Action)(delegate() {
				MainV2.comPort.setDigicamControl(true);
			}));
		}

		private void joystickEnableButton_Click(object sender, EventArgs e) {
			try {
				if (MainV2.joystick != null) {
					MainV2.joystick.UnAcquireJoyStick();
				}
			} catch {}

			// all config is loaded from the xmls
			var joy = new Joystick.Joystick(() => MainV2.comPort);

			joy.loadconfig();

			//show error message if a joystick is not connected when Enable is clicked
			if (!joy.start("Controller (Xbox One For Windows)")) {
				CustomMessageBox.Show("Please Connect a Joystick", "No Joystick");
				joy.Dispose();
				return;
			}

			Settings.Instance["joystick_name"] = "Controller (Xbox One For Windows)";

			MainV2.joystick = joy;
			MainV2.joystick.enabled = true;
		}

		private void startStopRecording_Click(object sender, EventArgs e) {
			if (targetBuilder != null) {
				// We are recording

				stopRecording();
			} else {
				// We are not recording

				startRecording();
			}
		}

		private void letterInput_TextChanged(object sender, EventArgs e) {
			if (letterInput.Text.Length > 1) {
				letterInput.Text = new string(new char[] { letterInput.Text[0] });
			}

			char letter = letterInput.Text.Length == 0 ? '\0' : letterInput.Text[0];

			if (letter == '\0') {
				letterInput.Text = "";
			}

			if (letter > 64 && letter < 91) {
				return;
			}

			if (letter > 96 && letter < 123) {
				letterInput.Text = new string(new char[] { (char)(letter - 32) });
				return;
			}

			letterInput.Text = "";
		}

		private void unknownDescriptionInput_TextChanged(object sender, EventArgs e) {

		}

		private void HandleUAVLand(object sender, EventArgs e) {
			flyingLabel.BeginInvoke((MethodInvoker)delegate () {
				flyingLabel.Text = "NO";
			});

			batteryComboBox.BeginInvoke((MethodInvoker)delegate () {
				batteryComboBox.SelectedIndex = 0;
			});
		}

		private void HandleUAVTakeoff(object sender, EventArgs e) {
			flyingLabel.BeginInvoke((MethodInvoker)delegate () {
				flyingLabel.Text = "YES";
			});
		}

		private void SafeUpdateText(Control label, string text) {
			if (!label.Text.Equals(text)) {
				label.BeginInvoke((MethodInvoker)delegate () {
					label.Text = text;
				});
			}
		}

		private string ConvertIntervalToMinuteSecondString(int seconds) {
			return $"{seconds / 60}:{(seconds % 60).ToString("00")}";
		}

		private void batteryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			if (MissionState.CurrentFlightReport != null) {
				MissionState.CurrentFlightReport.BatteryFlown = (Battery)(batteryComboBox.SelectedIndex - 1);
			} else {
				MissionState.NextMissionBattery = (Battery)(batteryComboBox.SelectedIndex - 1);
			}
		}

		private void UpdateRemainingBatteryTime() {
			int? idealTime = IdealBatteryTime;
			int currentTime = CurrentBatteryTime;

			if (!idealTime.HasValue) {
				SafeUpdateText(remainingBatteryTimeLabel, "0:00");
			} else {
				SafeUpdateText(remainingBatteryTimeLabel, ConvertIntervalToMinuteSecondString(IdealBatteryTime.Value - CurrentBatteryTime));
			}
		}

		private void updateMissionTimeLabel_Tick(object sender, EventArgs e) {
			if (MissionState.MissionStart != null) {
				SafeUpdateText(missionTimeLabel, ConvertIntervalToMinuteSecondString((int)(DateTime.Now - MissionState.MissionStart.Value).TotalSeconds));
			}
		}

		private void controllerSafetySwitchCheck_CheckedChanged(object sender, EventArgs e) {
			if (controllerSafetySwitchCheck.Checked) {
				safetySwitchTimer.Start();
			} else {
				safetySwitchTimer.Stop();
			}

			Settings.Instance["UAS4STEM_SafetySwitchCheck"] = controllerSafetySwitchCheck.Checked ? "TRUE" : "FALSE";
		}

		private void safetySwitchTimer_Tick(object sender, EventArgs e) {
			if (cs.ch7in < 1500 && MainV2.joystick != null) {
				MainV2.joystick.enabled = false;
				MainV2.joystick.clearRCOverride();
				MainV2.joystick = null;
			}
		}

		private bool isPressed = false;
		private void checkForStartStopOnController_Tick(object sender, EventArgs e) {
			var joy = MainV2.joystick;

			if (joy == null) {
				return;
			}

			var buttonFound = false;

			for (int i = 0; i < joy.JoyButtons.Length; i++) {
				var button = joy.JoyButtons[i];
				try {
					if (button.function == Joystick.Joystick.buttonfunction.Do_Set_Relay && joy.isButtonPressed(i)) {
						buttonFound = true;
						if (!isPressed) {
							isPressed = true;
							if (targetBuilder == null) {
								startRecording();
							} else {
								stopRecording();
							}
							break;
						}
					}
				} catch (NullReferenceException) {
					// ignore, joystick isn't fully set up
				}
			}

			if (!buttonFound) {
				isPressed = false;
			}
		}

		private void idealBatteryTimeInput_TextChanged(object sender, EventArgs e) {
			UpdateRemainingBatteryTime();

			Settings.Instance["UAS4STEM_IdealBatteryTime"] = idealBatteryTimeInput.Text;
		}

		private void getPossibleWordsCheckbox_CheckedChanged(object sender, EventArgs e) {
			MissionState.GetPossibleWords = getPossibleWordsCheckbox.Checked;

			Settings.Instance["UAS4STEM_GetPossibleWords"] = getPossibleWordsCheckbox.Checked ? "TRUE" : "FALSE";
		}

		private void setLabelsToRedColor_tick(object sender, EventArgs e)
		{
			armedLabel.BeginInvoke((MethodInvoker)delegate () {
				armedLabel.ForeColor = Color.FromArgb(255, 0, 0);
				flyingLabel.ForeColor = Color.FromArgb(255, 0, 0);
			});
		}
	}
}
