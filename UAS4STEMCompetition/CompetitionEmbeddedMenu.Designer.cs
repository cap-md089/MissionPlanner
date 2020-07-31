namespace MissionPlanner.UAS4STEMCompetition {
	partial class CompetitionEmbeddedMenu {
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
			this.components = new System.ComponentModel.Container();
			this.dropperManagementPanel = new System.Windows.Forms.Panel();
			this.toggleServoButton = new MissionPlanner.Controls.MyButton();
			this.toggleArmButton = new MissionPlanner.Controls.MyButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.alignToWindButton = new MissionPlanner.Controls.MyButton();
			this.triggerCameraButton = new MissionPlanner.Controls.MyButton();
			this.armedLabelLabel = new System.Windows.Forms.Label();
			this.armedLabel = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.startStopRecording = new MissionPlanner.Controls.MyButton();
			this.unknownDescriptionInput = new System.Windows.Forms.TextBox();
			this.letterInput = new System.Windows.Forms.TextBox();
			this.unknownLabel = new System.Windows.Forms.Label();
			this.letterLabel = new System.Windows.Forms.Label();
			this.targetType = new System.Windows.Forms.ComboBox();
			this.batteryComboBox = new System.Windows.Forms.ComboBox();
			this.batteryLabel = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.joystickEnableButton = new MissionPlanner.Controls.MyButton();
			this.dropPlanGenerator = new MissionPlanner.Controls.MyButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.modeChangeAltHold = new MissionPlanner.Controls.MyButton();
			this.modeChangePositionHold = new MissionPlanner.Controls.MyButton();
			this.modeChangeAutoButton = new MissionPlanner.Controls.MyButton();
			this.modeChangeRTLButton = new MissionPlanner.Controls.MyButton();
			this.flyingLabelLabel = new System.Windows.Forms.Label();
			this.flyingLabel = new System.Windows.Forms.Label();
			this.flightTimeLabelLabel = new System.Windows.Forms.Label();
			this.flightTimeLabel = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.missionTimeLabel = new System.Windows.Forms.Label();
			this.missionTimeLabelLabel = new System.Windows.Forms.Label();
			this.timeToLandLabel = new System.Windows.Forms.Label();
			this.timeToLandLabelLabel = new System.Windows.Forms.Label();
			this.remainingBatteryTimeLabel = new System.Windows.Forms.Label();
			this.remainingBatteryTimeLabelLabel = new System.Windows.Forms.Label();
			this.batteryTimeLabel = new System.Windows.Forms.Label();
			this.batteryTimeLabelLabel = new System.Windows.Forms.Label();
			this.idealBatteryTimeInput = new System.Windows.Forms.TextBox();
			this.idealBatteryTimeLabel = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.updateMissionTimeLabel = new System.Windows.Forms.Timer(this.components);
			this.safetySwitchTimer = new System.Windows.Forms.Timer(this.components);
			this.checkForStartStopOnController = new System.Windows.Forms.Timer(this.components);
			this.panel8 = new System.Windows.Forms.Panel();
			this.getPossibleWordsCheckbox = new System.Windows.Forms.CheckBox();
			this.getWordsLabel = new System.Windows.Forms.Label();
			this.controllerSafetySwitchCheck = new System.Windows.Forms.CheckBox();
			this.controllerSafetySwitchCheckLabel = new System.Windows.Forms.Label();
			this.setColorToRedTimer = new System.Windows.Forms.Timer(this.components);
			this.panel9 = new System.Windows.Forms.Panel();
			this.altitudeDisplay = new System.Windows.Forms.Label();
			this.groundSpeedDisplay = new System.Windows.Forms.Label();
			this.modeDisplay = new System.Windows.Forms.Label();
			this.rc3OverrideDisplay = new System.Windows.Forms.Label();
			this.ch3PercentDisplay = new System.Windows.Forms.Label();
			this.altitudeLabel = new System.Windows.Forms.Label();
			this.groundSpeedLabel = new System.Windows.Forms.Label();
			this.modeLabel = new System.Windows.Forms.Label();
			this.rcOverride3Label = new System.Windows.Forms.Label();
			this.ch3PercentLabel = new System.Windows.Forms.Label();
			this.altitudeFeetLabelLabel = new System.Windows.Forms.Label();
			this.altitudeFeetLabel = new System.Windows.Forms.Label();
			this.dropperManagementPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// dropperManagementPanel
			// 
			this.dropperManagementPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dropperManagementPanel.Controls.Add(this.toggleServoButton);
			this.dropperManagementPanel.Controls.Add(this.toggleArmButton);
			this.dropperManagementPanel.Location = new System.Drawing.Point(12, 12);
			this.dropperManagementPanel.Name = "dropperManagementPanel";
			this.dropperManagementPanel.Size = new System.Drawing.Size(228, 32);
			this.dropperManagementPanel.TabIndex = 1;
			// 
			// toggleServoButton
			// 
			this.toggleServoButton.Location = new System.Drawing.Point(115, 3);
			this.toggleServoButton.Name = "toggleServoButton";
			this.toggleServoButton.Size = new System.Drawing.Size(106, 24);
			this.toggleServoButton.TabIndex = 8;
			this.toggleServoButton.Text = "Toggle Dropper";
			this.toggleServoButton.UseVisualStyleBackColor = true;
			this.toggleServoButton.Click += new System.EventHandler(this.toggleServoButton_Click);
			// 
			// toggleArmButton
			// 
			this.toggleArmButton.Location = new System.Drawing.Point(3, 3);
			this.toggleArmButton.Name = "toggleArmButton";
			this.toggleArmButton.Size = new System.Drawing.Size(107, 24);
			this.toggleArmButton.TabIndex = 9;
			this.toggleArmButton.Text = "Arm";
			this.toggleArmButton.UseVisualStyleBackColor = true;
			this.toggleArmButton.Click += new System.EventHandler(this.toggleArmButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.alignToWindButton);
			this.panel1.Controls.Add(this.triggerCameraButton);
			this.panel1.Location = new System.Drawing.Point(12, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(228, 31);
			this.panel1.TabIndex = 2;
			// 
			// alignToWindButton
			// 
			this.alignToWindButton.Location = new System.Drawing.Point(116, 3);
			this.alignToWindButton.Name = "alignToWindButton";
			this.alignToWindButton.Size = new System.Drawing.Size(106, 25);
			this.alignToWindButton.TabIndex = 9;
			this.alignToWindButton.Text = "Align to Wind";
			this.alignToWindButton.UseVisualStyleBackColor = true;
			// 
			// triggerCameraButton
			// 
			this.triggerCameraButton.Location = new System.Drawing.Point(4, 3);
			this.triggerCameraButton.Name = "triggerCameraButton";
			this.triggerCameraButton.Size = new System.Drawing.Size(107, 25);
			this.triggerCameraButton.TabIndex = 0;
			this.triggerCameraButton.Text = "Trigger Camera";
			this.triggerCameraButton.UseVisualStyleBackColor = true;
			this.triggerCameraButton.Click += new System.EventHandler(this.triggerCameraButton_Click);
			// 
			// armedLabelLabel
			// 
			this.armedLabelLabel.AutoSize = true;
			this.armedLabelLabel.Location = new System.Drawing.Point(8, 10);
			this.armedLabelLabel.Name = "armedLabelLabel";
			this.armedLabelLabel.Size = new System.Drawing.Size(40, 13);
			this.armedLabelLabel.TabIndex = 3;
			this.armedLabelLabel.Text = "Armed:";
			// 
			// armedLabel
			// 
			this.armedLabel.AutoSize = true;
			this.armedLabel.ForeColor = System.Drawing.Color.Red;
			this.armedLabel.Location = new System.Drawing.Point(54, 10);
			this.armedLabel.Name = "armedLabel";
			this.armedLabel.Size = new System.Drawing.Size(64, 13);
			this.armedLabel.TabIndex = 4;
			this.armedLabel.Text = "DISARMED";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.startStopRecording);
			this.panel2.Controls.Add(this.unknownDescriptionInput);
			this.panel2.Controls.Add(this.letterInput);
			this.panel2.Controls.Add(this.unknownLabel);
			this.panel2.Controls.Add(this.letterLabel);
			this.panel2.Controls.Add(this.targetType);
			this.panel2.Location = new System.Drawing.Point(12, 190);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(228, 152);
			this.panel2.TabIndex = 5;
			// 
			// startStopRecording
			// 
			this.startStopRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startStopRecording.Location = new System.Drawing.Point(3, 54);
			this.startStopRecording.Name = "startStopRecording";
			this.startStopRecording.Size = new System.Drawing.Size(218, 93);
			this.startStopRecording.TabIndex = 5;
			this.startStopRecording.Text = "Start Recording";
			this.startStopRecording.UseVisualStyleBackColor = true;
			this.startStopRecording.Click += new System.EventHandler(this.startStopRecording_Click);
			// 
			// unknownDescriptionInput
			// 
			this.unknownDescriptionInput.Location = new System.Drawing.Point(69, 28);
			this.unknownDescriptionInput.Name = "unknownDescriptionInput";
			this.unknownDescriptionInput.Size = new System.Drawing.Size(152, 20);
			this.unknownDescriptionInput.TabIndex = 4;
			this.unknownDescriptionInput.TextChanged += new System.EventHandler(this.unknownDescriptionInput_TextChanged);
			// 
			// letterInput
			// 
			this.letterInput.Location = new System.Drawing.Point(43, 28);
			this.letterInput.Name = "letterInput";
			this.letterInput.Size = new System.Drawing.Size(178, 20);
			this.letterInput.TabIndex = 3;
			this.letterInput.TextChanged += new System.EventHandler(this.letterInput_TextChanged);
			// 
			// unknownLabel
			// 
			this.unknownLabel.AutoSize = true;
			this.unknownLabel.Location = new System.Drawing.Point(3, 31);
			this.unknownLabel.Name = "unknownLabel";
			this.unknownLabel.Size = new System.Drawing.Size(60, 13);
			this.unknownLabel.TabIndex = 2;
			this.unknownLabel.Text = "Description";
			// 
			// letterLabel
			// 
			this.letterLabel.AutoSize = true;
			this.letterLabel.Location = new System.Drawing.Point(3, 31);
			this.letterLabel.Name = "letterLabel";
			this.letterLabel.Size = new System.Drawing.Size(34, 13);
			this.letterLabel.TabIndex = 1;
			this.letterLabel.Text = "Letter";
			// 
			// targetType
			// 
			this.targetType.FormattingEnabled = true;
			this.targetType.Items.AddRange(new object[] {
            "--Select Target Type--",
            "Drop Target",
            "Letter Target",
            "Other"});
			this.targetType.Location = new System.Drawing.Point(3, 3);
			this.targetType.Name = "targetType";
			this.targetType.Size = new System.Drawing.Size(218, 21);
			this.targetType.TabIndex = 0;
			this.targetType.SelectedIndexChanged += new System.EventHandler(this.targetType_SelectedIndexChanged);
			// 
			// batteryComboBox
			// 
			this.batteryComboBox.FormattingEnabled = true;
			this.batteryComboBox.Items.AddRange(new object[] {
            "--Select Battery--",
            "GRP 110",
            "GRP 111",
            "GRP 112",
            "GRP 114"});
			this.batteryComboBox.Location = new System.Drawing.Point(54, 8);
			this.batteryComboBox.Name = "batteryComboBox";
			this.batteryComboBox.Size = new System.Drawing.Size(167, 21);
			this.batteryComboBox.TabIndex = 6;
			this.batteryComboBox.SelectedIndexChanged += new System.EventHandler(this.batteryComboBox_SelectedIndexChanged);
			// 
			// batteryLabel
			// 
			this.batteryLabel.AutoSize = true;
			this.batteryLabel.Location = new System.Drawing.Point(8, 11);
			this.batteryLabel.Name = "batteryLabel";
			this.batteryLabel.Size = new System.Drawing.Size(40, 13);
			this.batteryLabel.TabIndex = 7;
			this.batteryLabel.Text = "Battery";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.joystickEnableButton);
			this.panel3.Controls.Add(this.dropPlanGenerator);
			this.panel3.Location = new System.Drawing.Point(12, 87);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(228, 30);
			this.panel3.TabIndex = 8;
			// 
			// joystickEnableButton
			// 
			this.joystickEnableButton.Location = new System.Drawing.Point(116, 3);
			this.joystickEnableButton.Name = "joystickEnableButton";
			this.joystickEnableButton.Size = new System.Drawing.Size(105, 23);
			this.joystickEnableButton.TabIndex = 10;
			this.joystickEnableButton.Text = "Enable Joystick";
			this.joystickEnableButton.UseVisualStyleBackColor = true;
			this.joystickEnableButton.Click += new System.EventHandler(this.joystickEnableButton_Click);
			// 
			// dropPlanGenerator
			// 
			this.dropPlanGenerator.Location = new System.Drawing.Point(3, 3);
			this.dropPlanGenerator.Name = "dropPlanGenerator";
			this.dropPlanGenerator.Size = new System.Drawing.Size(108, 23);
			this.dropPlanGenerator.TabIndex = 9;
			this.dropPlanGenerator.Text = "Gen. drop plan";
			this.dropPlanGenerator.UseVisualStyleBackColor = true;
			this.dropPlanGenerator.Click += new System.EventHandler(this.dropPlanGenerator_Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.modeChangeAltHold);
			this.panel4.Controls.Add(this.modeChangePositionHold);
			this.panel4.Controls.Add(this.modeChangeAutoButton);
			this.panel4.Controls.Add(this.modeChangeRTLButton);
			this.panel4.Location = new System.Drawing.Point(12, 123);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(228, 61);
			this.panel4.TabIndex = 9;
			// 
			// modeChangeAltHold
			// 
			this.modeChangeAltHold.Location = new System.Drawing.Point(115, 32);
			this.modeChangeAltHold.Name = "modeChangeAltHold";
			this.modeChangeAltHold.Size = new System.Drawing.Size(106, 23);
			this.modeChangeAltHold.TabIndex = 3;
			this.modeChangeAltHold.Text = "AltHold";
			this.modeChangeAltHold.UseVisualStyleBackColor = true;
			this.modeChangeAltHold.Click += new System.EventHandler(this.modeChangeAltHold_Click);
			// 
			// modeChangePositionHold
			// 
			this.modeChangePositionHold.Location = new System.Drawing.Point(3, 32);
			this.modeChangePositionHold.Name = "modeChangePositionHold";
			this.modeChangePositionHold.Size = new System.Drawing.Size(106, 23);
			this.modeChangePositionHold.TabIndex = 2;
			this.modeChangePositionHold.Text = "PosHold";
			this.modeChangePositionHold.UseVisualStyleBackColor = true;
			this.modeChangePositionHold.Click += new System.EventHandler(this.modeChangePositionHold_Click);
			// 
			// modeChangeAutoButton
			// 
			this.modeChangeAutoButton.Location = new System.Drawing.Point(115, 3);
			this.modeChangeAutoButton.Name = "modeChangeAutoButton";
			this.modeChangeAutoButton.Size = new System.Drawing.Size(106, 23);
			this.modeChangeAutoButton.TabIndex = 1;
			this.modeChangeAutoButton.Text = "Auto";
			this.modeChangeAutoButton.UseVisualStyleBackColor = true;
			this.modeChangeAutoButton.Click += new System.EventHandler(this.modeChangeAutoButton_Click);
			// 
			// modeChangeRTLButton
			// 
			this.modeChangeRTLButton.Location = new System.Drawing.Point(3, 3);
			this.modeChangeRTLButton.Name = "modeChangeRTLButton";
			this.modeChangeRTLButton.Size = new System.Drawing.Size(106, 23);
			this.modeChangeRTLButton.TabIndex = 0;
			this.modeChangeRTLButton.Text = "RTL";
			this.modeChangeRTLButton.UseVisualStyleBackColor = true;
			this.modeChangeRTLButton.Click += new System.EventHandler(this.modeChangeRTLButton_Click);
			// 
			// flyingLabelLabel
			// 
			this.flyingLabelLabel.AutoSize = true;
			this.flyingLabelLabel.Location = new System.Drawing.Point(154, 10);
			this.flyingLabelLabel.Name = "flyingLabelLabel";
			this.flyingLabelLabel.Size = new System.Drawing.Size(37, 13);
			this.flyingLabelLabel.TabIndex = 10;
			this.flyingLabelLabel.Text = "Flying:";
			// 
			// flyingLabel
			// 
			this.flyingLabel.AutoSize = true;
			this.flyingLabel.ForeColor = System.Drawing.Color.Red;
			this.flyingLabel.Location = new System.Drawing.Point(197, 10);
			this.flyingLabel.Name = "flyingLabel";
			this.flyingLabel.Size = new System.Drawing.Size(23, 13);
			this.flyingLabel.TabIndex = 11;
			this.flyingLabel.Text = "NO";
			// 
			// flightTimeLabelLabel
			// 
			this.flightTimeLabelLabel.AutoSize = true;
			this.flightTimeLabelLabel.Location = new System.Drawing.Point(8, 9);
			this.flightTimeLabelLabel.Name = "flightTimeLabelLabel";
			this.flightTimeLabelLabel.Size = new System.Drawing.Size(57, 13);
			this.flightTimeLabelLabel.TabIndex = 12;
			this.flightTimeLabelLabel.Text = "Flight time:";
			// 
			// flightTimeLabel
			// 
			this.flightTimeLabel.AutoSize = true;
			this.flightTimeLabel.Location = new System.Drawing.Point(71, 9);
			this.flightTimeLabel.Name = "flightTimeLabel";
			this.flightTimeLabel.Size = new System.Drawing.Size(28, 13);
			this.flightTimeLabel.TabIndex = 13;
			this.flightTimeLabel.Text = "0:00";
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.missionTimeLabel);
			this.panel5.Controls.Add(this.missionTimeLabelLabel);
			this.panel5.Controls.Add(this.timeToLandLabel);
			this.panel5.Controls.Add(this.timeToLandLabelLabel);
			this.panel5.Controls.Add(this.remainingBatteryTimeLabel);
			this.panel5.Controls.Add(this.remainingBatteryTimeLabelLabel);
			this.panel5.Controls.Add(this.batteryTimeLabel);
			this.panel5.Controls.Add(this.batteryTimeLabelLabel);
			this.panel5.Controls.Add(this.flightTimeLabelLabel);
			this.panel5.Controls.Add(this.flightTimeLabel);
			this.panel5.Location = new System.Drawing.Point(12, 388);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(228, 133);
			this.panel5.TabIndex = 14;
			// 
			// missionTimeLabel
			// 
			this.missionTimeLabel.AutoSize = true;
			this.missionTimeLabel.Location = new System.Drawing.Point(81, 110);
			this.missionTimeLabel.Name = "missionTimeLabel";
			this.missionTimeLabel.Size = new System.Drawing.Size(28, 13);
			this.missionTimeLabel.TabIndex = 23;
			this.missionTimeLabel.Text = "0:00";
			// 
			// missionTimeLabelLabel
			// 
			this.missionTimeLabelLabel.AutoSize = true;
			this.missionTimeLabelLabel.Location = new System.Drawing.Point(8, 110);
			this.missionTimeLabelLabel.Name = "missionTimeLabelLabel";
			this.missionTimeLabelLabel.Size = new System.Drawing.Size(67, 13);
			this.missionTimeLabelLabel.TabIndex = 22;
			this.missionTimeLabelLabel.Text = "Mission time:";
			// 
			// timeToLandLabel
			// 
			this.timeToLandLabel.AutoSize = true;
			this.timeToLandLabel.Location = new System.Drawing.Point(147, 83);
			this.timeToLandLabel.Name = "timeToLandLabel";
			this.timeToLandLabel.Size = new System.Drawing.Size(28, 13);
			this.timeToLandLabel.TabIndex = 19;
			this.timeToLandLabel.Text = "0:00";
			// 
			// timeToLandLabelLabel
			// 
			this.timeToLandLabelLabel.AutoSize = true;
			this.timeToLandLabelLabel.Location = new System.Drawing.Point(8, 83);
			this.timeToLandLabelLabel.Name = "timeToLandLabelLabel";
			this.timeToLandLabelLabel.Size = new System.Drawing.Size(133, 13);
			this.timeToLandLabelLabel.TabIndex = 18;
			this.timeToLandLabelLabel.Text = "(Est) Time required to land:";
			// 
			// remainingBatteryTimeLabel
			// 
			this.remainingBatteryTimeLabel.AutoSize = true;
			this.remainingBatteryTimeLabel.Location = new System.Drawing.Point(131, 58);
			this.remainingBatteryTimeLabel.Name = "remainingBatteryTimeLabel";
			this.remainingBatteryTimeLabel.Size = new System.Drawing.Size(28, 13);
			this.remainingBatteryTimeLabel.TabIndex = 17;
			this.remainingBatteryTimeLabel.Text = "0:00";
			// 
			// remainingBatteryTimeLabelLabel
			// 
			this.remainingBatteryTimeLabelLabel.AutoSize = true;
			this.remainingBatteryTimeLabelLabel.Location = new System.Drawing.Point(8, 58);
			this.remainingBatteryTimeLabelLabel.Name = "remainingBatteryTimeLabelLabel";
			this.remainingBatteryTimeLabelLabel.Size = new System.Drawing.Size(117, 13);
			this.remainingBatteryTimeLabelLabel.TabIndex = 16;
			this.remainingBatteryTimeLabelLabel.Text = "Remaining battery time:";
			// 
			// batteryTimeLabel
			// 
			this.batteryTimeLabel.AutoSize = true;
			this.batteryTimeLabel.Location = new System.Drawing.Point(79, 34);
			this.batteryTimeLabel.Name = "batteryTimeLabel";
			this.batteryTimeLabel.Size = new System.Drawing.Size(28, 13);
			this.batteryTimeLabel.TabIndex = 15;
			this.batteryTimeLabel.Text = "0:00";
			// 
			// batteryTimeLabelLabel
			// 
			this.batteryTimeLabelLabel.AutoSize = true;
			this.batteryTimeLabelLabel.Location = new System.Drawing.Point(8, 34);
			this.batteryTimeLabelLabel.Name = "batteryTimeLabelLabel";
			this.batteryTimeLabelLabel.Size = new System.Drawing.Size(65, 13);
			this.batteryTimeLabelLabel.TabIndex = 14;
			this.batteryTimeLabelLabel.Text = "Battery time:";
			// 
			// idealBatteryTimeInput
			// 
			this.idealBatteryTimeInput.Location = new System.Drawing.Point(130, 8);
			this.idealBatteryTimeInput.Name = "idealBatteryTimeInput";
			this.idealBatteryTimeInput.Size = new System.Drawing.Size(90, 20);
			this.idealBatteryTimeInput.TabIndex = 21;
			this.idealBatteryTimeInput.Text = "480";
			this.idealBatteryTimeInput.TextChanged += new System.EventHandler(this.idealBatteryTimeInput_TextChanged);
			// 
			// idealBatteryTimeLabel
			// 
			this.idealBatteryTimeLabel.AutoSize = true;
			this.idealBatteryTimeLabel.Location = new System.Drawing.Point(8, 11);
			this.idealBatteryTimeLabel.Name = "idealBatteryTimeLabel";
			this.idealBatteryTimeLabel.Size = new System.Drawing.Size(116, 13);
			this.idealBatteryTimeLabel.TabIndex = 20;
			this.idealBatteryTimeLabel.Text = "Ideal battery time (sec):";
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.batteryLabel);
			this.panel6.Controls.Add(this.batteryComboBox);
			this.panel6.Location = new System.Drawing.Point(12, 527);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(228, 38);
			this.panel6.TabIndex = 15;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.armedLabel);
			this.panel7.Controls.Add(this.armedLabelLabel);
			this.panel7.Controls.Add(this.flyingLabelLabel);
			this.panel7.Controls.Add(this.flyingLabel);
			this.panel7.Location = new System.Drawing.Point(12, 348);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(228, 34);
			this.panel7.TabIndex = 16;
			// 
			// updateMissionTimeLabel
			// 
			this.updateMissionTimeLabel.Enabled = true;
			this.updateMissionTimeLabel.Tick += new System.EventHandler(this.updateMissionTimeLabel_Tick);
			// 
			// safetySwitchTimer
			// 
			this.safetySwitchTimer.Interval = 10;
			this.safetySwitchTimer.Tick += new System.EventHandler(this.safetySwitchTimer_Tick);
			// 
			// checkForStartStopOnController
			// 
			this.checkForStartStopOnController.Enabled = true;
			this.checkForStartStopOnController.Interval = 50;
			this.checkForStartStopOnController.Tick += new System.EventHandler(this.checkForStartStopOnController_Tick);
			// 
			// panel8
			// 
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.getPossibleWordsCheckbox);
			this.panel8.Controls.Add(this.getWordsLabel);
			this.panel8.Controls.Add(this.controllerSafetySwitchCheck);
			this.panel8.Controls.Add(this.controllerSafetySwitchCheckLabel);
			this.panel8.Controls.Add(this.idealBatteryTimeLabel);
			this.panel8.Controls.Add(this.idealBatteryTimeInput);
			this.panel8.Location = new System.Drawing.Point(12, 571);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(228, 89);
			this.panel8.TabIndex = 17;
			// 
			// getPossibleWordsCheckbox
			// 
			this.getPossibleWordsCheckbox.AutoSize = true;
			this.getPossibleWordsCheckbox.Location = new System.Drawing.Point(157, 60);
			this.getPossibleWordsCheckbox.Name = "getPossibleWordsCheckbox";
			this.getPossibleWordsCheckbox.Size = new System.Drawing.Size(15, 14);
			this.getPossibleWordsCheckbox.TabIndex = 25;
			this.getPossibleWordsCheckbox.UseVisualStyleBackColor = true;
			this.getPossibleWordsCheckbox.CheckedChanged += new System.EventHandler(this.getPossibleWordsCheckbox_CheckedChanged);
			// 
			// getWordsLabel
			// 
			this.getWordsLabel.AutoSize = true;
			this.getWordsLabel.Location = new System.Drawing.Point(8, 61);
			this.getWordsLabel.Name = "getWordsLabel";
			this.getWordsLabel.Size = new System.Drawing.Size(143, 13);
			this.getWordsLabel.TabIndex = 24;
			this.getWordsLabel.Text = "Get possible words in report?";
			// 
			// controllerSafetySwitchCheck
			// 
			this.controllerSafetySwitchCheck.AutoSize = true;
			this.controllerSafetySwitchCheck.Location = new System.Drawing.Point(157, 36);
			this.controllerSafetySwitchCheck.Name = "controllerSafetySwitchCheck";
			this.controllerSafetySwitchCheck.Size = new System.Drawing.Size(15, 14);
			this.controllerSafetySwitchCheck.TabIndex = 23;
			this.controllerSafetySwitchCheck.UseVisualStyleBackColor = true;
			this.controllerSafetySwitchCheck.CheckedChanged += new System.EventHandler(this.controllerSafetySwitchCheck_CheckedChanged);
			// 
			// controllerSafetySwitchCheckLabel
			// 
			this.controllerSafetySwitchCheckLabel.AutoSize = true;
			this.controllerSafetySwitchCheckLabel.Location = new System.Drawing.Point(8, 36);
			this.controllerSafetySwitchCheckLabel.Name = "controllerSafetySwitchCheckLabel";
			this.controllerSafetySwitchCheckLabel.Size = new System.Drawing.Size(142, 13);
			this.controllerSafetySwitchCheckLabel.TabIndex = 22;
			this.controllerSafetySwitchCheckLabel.Text = "Use controller safety switch?";
			// 
			// setColorToRedTimer
			// 
			this.setColorToRedTimer.Tick += new System.EventHandler(this.setLabelsToRedColor_tick);
			// 
			// panel9
			// 
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Controls.Add(this.altitudeFeetLabel);
			this.panel9.Controls.Add(this.altitudeFeetLabelLabel);
			this.panel9.Controls.Add(this.altitudeDisplay);
			this.panel9.Controls.Add(this.groundSpeedDisplay);
			this.panel9.Controls.Add(this.modeDisplay);
			this.panel9.Controls.Add(this.rc3OverrideDisplay);
			this.panel9.Controls.Add(this.ch3PercentDisplay);
			this.panel9.Controls.Add(this.altitudeLabel);
			this.panel9.Controls.Add(this.groundSpeedLabel);
			this.panel9.Controls.Add(this.modeLabel);
			this.panel9.Controls.Add(this.rcOverride3Label);
			this.panel9.Controls.Add(this.ch3PercentLabel);
			this.panel9.Location = new System.Drawing.Point(12, 666);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(228, 146);
			this.panel9.TabIndex = 18;
			// 
			// altitudeDisplay
			// 
			this.altitudeDisplay.AutoSize = true;
			this.altitudeDisplay.Location = new System.Drawing.Point(62, 97);
			this.altitudeDisplay.Name = "altitudeDisplay";
			this.altitudeDisplay.Size = new System.Drawing.Size(0, 13);
			this.altitudeDisplay.TabIndex = 9;
			// 
			// groundSpeedDisplay
			// 
			this.groundSpeedDisplay.AutoSize = true;
			this.groundSpeedDisplay.Location = new System.Drawing.Point(94, 75);
			this.groundSpeedDisplay.Name = "groundSpeedDisplay";
			this.groundSpeedDisplay.Size = new System.Drawing.Size(0, 13);
			this.groundSpeedDisplay.TabIndex = 8;
			// 
			// modeDisplay
			// 
			this.modeDisplay.AutoSize = true;
			this.modeDisplay.Location = new System.Drawing.Point(54, 53);
			this.modeDisplay.Name = "modeDisplay";
			this.modeDisplay.Size = new System.Drawing.Size(0, 13);
			this.modeDisplay.TabIndex = 7;
			// 
			// rc3OverrideDisplay
			// 
			this.rc3OverrideDisplay.AutoSize = true;
			this.rc3OverrideDisplay.Location = new System.Drawing.Point(94, 31);
			this.rc3OverrideDisplay.Name = "rc3OverrideDisplay";
			this.rc3OverrideDisplay.Size = new System.Drawing.Size(0, 13);
			this.rc3OverrideDisplay.TabIndex = 6;
			// 
			// ch3PercentDisplay
			// 
			this.ch3PercentDisplay.AutoSize = true;
			this.ch3PercentDisplay.Location = new System.Drawing.Point(85, 9);
			this.ch3PercentDisplay.Name = "ch3PercentDisplay";
			this.ch3PercentDisplay.Size = new System.Drawing.Size(0, 13);
			this.ch3PercentDisplay.TabIndex = 5;
			// 
			// altitudeLabel
			// 
			this.altitudeLabel.AutoSize = true;
			this.altitudeLabel.Location = new System.Drawing.Point(8, 97);
			this.altitudeLabel.Name = "altitudeLabel";
			this.altitudeLabel.Size = new System.Drawing.Size(48, 13);
			this.altitudeLabel.TabIndex = 4;
			this.altitudeLabel.Text = "Altitude: ";
			// 
			// groundSpeedLabel
			// 
			this.groundSpeedLabel.AutoSize = true;
			this.groundSpeedLabel.Location = new System.Drawing.Point(8, 75);
			this.groundSpeedLabel.Name = "groundSpeedLabel";
			this.groundSpeedLabel.Size = new System.Drawing.Size(80, 13);
			this.groundSpeedLabel.TabIndex = 3;
			this.groundSpeedLabel.Text = "Ground speed: ";
			// 
			// modeLabel
			// 
			this.modeLabel.AutoSize = true;
			this.modeLabel.Location = new System.Drawing.Point(8, 53);
			this.modeLabel.Name = "modeLabel";
			this.modeLabel.Size = new System.Drawing.Size(40, 13);
			this.modeLabel.TabIndex = 2;
			this.modeLabel.Text = "Mode: ";
			// 
			// rcOverride3Label
			// 
			this.rcOverride3Label.AutoSize = true;
			this.rcOverride3Label.Location = new System.Drawing.Point(8, 31);
			this.rcOverride3Label.Name = "rcOverride3Label";
			this.rcOverride3Label.Size = new System.Drawing.Size(80, 13);
			this.rcOverride3Label.TabIndex = 1;
			this.rcOverride3Label.Text = "RC Override 3: ";
			// 
			// ch3PercentLabel
			// 
			this.ch3PercentLabel.AutoSize = true;
			this.ch3PercentLabel.Location = new System.Drawing.Point(8, 9);
			this.ch3PercentLabel.Name = "ch3PercentLabel";
			this.ch3PercentLabel.Size = new System.Drawing.Size(71, 13);
			this.ch3PercentLabel.TabIndex = 0;
			this.ch3PercentLabel.Text = "CH3 Percent:";
			// 
			// altitudeFeetLabelLabel
			// 
			this.altitudeFeetLabelLabel.AutoSize = true;
			this.altitudeFeetLabelLabel.Location = new System.Drawing.Point(8, 119);
			this.altitudeFeetLabelLabel.Name = "altitudeFeetLabelLabel";
			this.altitudeFeetLabelLabel.Size = new System.Drawing.Size(63, 13);
			this.altitudeFeetLabelLabel.TabIndex = 10;
			this.altitudeFeetLabelLabel.Text = "Altitude (ft): ";
			// 
			// altitudeFeetLabel
			// 
			this.altitudeFeetLabel.AutoSize = true;
			this.altitudeFeetLabel.Location = new System.Drawing.Point(77, 119);
			this.altitudeFeetLabel.Name = "altitudeFeetLabel";
			this.altitudeFeetLabel.Size = new System.Drawing.Size(0, 13);
			this.altitudeFeetLabel.TabIndex = 11;
			// 
			// CompetitionEmbeddedMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dropperManagementPanel);
			this.Name = "CompetitionEmbeddedMenu";
			this.Size = new System.Drawing.Size(251, 826);
			this.Load += new System.EventHandler(this.CompetitionEmbeddedMenu_Load);
			this.dropperManagementPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel dropperManagementPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label armedLabelLabel;
		private System.Windows.Forms.Label armedLabel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox batteryComboBox;
		private System.Windows.Forms.Label batteryLabel;
		private System.Windows.Forms.ComboBox targetType;
		private System.Windows.Forms.Label letterLabel;
		private System.Windows.Forms.TextBox unknownDescriptionInput;
		private System.Windows.Forms.TextBox letterInput;
		private System.Windows.Forms.Label unknownLabel;
		private Controls.MyButton toggleServoButton;
		private Controls.MyButton toggleArmButton;
		private System.Windows.Forms.Panel panel3;
		private Controls.MyButton alignToWindButton;
		private Controls.MyButton dropPlanGenerator;
		private System.Windows.Forms.Panel panel4;
		private Controls.MyButton modeChangeAltHold;
		private Controls.MyButton modeChangePositionHold;
		private Controls.MyButton modeChangeAutoButton;
		private Controls.MyButton modeChangeRTLButton;
		private Controls.MyButton startStopRecording;
		private Controls.MyButton triggerCameraButton;
		private Controls.MyButton joystickEnableButton;
		private System.Windows.Forms.Label flyingLabelLabel;
		private System.Windows.Forms.Label flyingLabel;
		private System.Windows.Forms.Label flightTimeLabelLabel;
		private System.Windows.Forms.Label flightTimeLabel;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label timeToLandLabel;
		private System.Windows.Forms.Label timeToLandLabelLabel;
		private System.Windows.Forms.Label remainingBatteryTimeLabel;
		private System.Windows.Forms.Label remainingBatteryTimeLabelLabel;
		private System.Windows.Forms.Label batteryTimeLabel;
		private System.Windows.Forms.Label batteryTimeLabelLabel;
		private System.Windows.Forms.TextBox idealBatteryTimeInput;
		private System.Windows.Forms.Label idealBatteryTimeLabel;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label missionTimeLabel;
		private System.Windows.Forms.Label missionTimeLabelLabel;
		private System.Windows.Forms.Timer updateMissionTimeLabel;
		private System.Windows.Forms.Timer safetySwitchTimer;
		private System.Windows.Forms.Timer checkForStartStopOnController;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.CheckBox controllerSafetySwitchCheck;
		private System.Windows.Forms.Label controllerSafetySwitchCheckLabel;
		private System.Windows.Forms.CheckBox getPossibleWordsCheckbox;
		private System.Windows.Forms.Label getWordsLabel;
		private System.Windows.Forms.Timer setColorToRedTimer;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label ch3PercentLabel;
		private System.Windows.Forms.Label rcOverride3Label;
		private System.Windows.Forms.Label modeLabel;
		private System.Windows.Forms.Label groundSpeedLabel;
		private System.Windows.Forms.Label altitudeLabel;
		private System.Windows.Forms.Label ch3PercentDisplay;
		private System.Windows.Forms.Label altitudeDisplay;
		private System.Windows.Forms.Label groundSpeedDisplay;
		private System.Windows.Forms.Label modeDisplay;
		private System.Windows.Forms.Label rc3OverrideDisplay;
		private System.Windows.Forms.Label altitudeFeetLabel;
		private System.Windows.Forms.Label altitudeFeetLabelLabel;
	}
}