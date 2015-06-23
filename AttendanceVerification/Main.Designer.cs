namespace AttendanceVerification
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.grFingerXCtrl = new AxGrFingerXLib.AxGrFingerXCtrl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonalDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAttendanceRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStaffList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTimeAttendanceReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLayoutCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLayoutTile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStudentCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grFingerXCtrl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grFingerXCtrl
            // 
            this.grFingerXCtrl.Enabled = true;
            this.grFingerXCtrl.Location = new System.Drawing.Point(591, 129);
            this.grFingerXCtrl.Name = "grFingerXCtrl";
            this.grFingerXCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("grFingerXCtrl.OcxState")));
            this.grFingerXCtrl.Size = new System.Drawing.Size(32, 32);
            this.grFingerXCtrl.TabIndex = 1;
            this.grFingerXCtrl.SensorPlug += new AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEventHandler(this.grFingerXCtrl_SensorPlug);
            this.grFingerXCtrl.SensorUnplug += new AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEventHandler(this.grFingerXCtrl_SensorUnplug);
            this.grFingerXCtrl.ImageAcquired += new AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEventHandler(this.grFingerXCtrl_ImageAcquired);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.toolStripMenuItem8,
            this.ToolStripMenuItemWindow,
            this.toolStripMenuItem6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(633, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPersonalDetails});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 20);
            this.toolStripMenuItem1.Text = "Student Details";
            // 
            // mnuPersonalDetails
            // 
            this.mnuPersonalDetails.Name = "mnuPersonalDetails";
            this.mnuPersonalDetails.Size = new System.Drawing.Size(161, 22);
            this.mnuPersonalDetails.Text = "Personal Details";
            this.mnuPersonalDetails.Click += new System.EventHandler(this.mnuPersonalDetails_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAttendanceRecords});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShowShortcutKeys = false;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(77, 20);
            this.toolStripMenuItem2.Text = "Attendance";
            // 
            // mnuAttendanceRecords
            // 
            this.mnuAttendanceRecords.Name = "mnuAttendanceRecords";
            this.mnuAttendanceRecords.Size = new System.Drawing.Size(177, 22);
            this.mnuAttendanceRecords.Text = "Attendance Records";
            this.mnuAttendanceRecords.Click += new System.EventHandler(this.mnuAttendanceRecords_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStaffList,
            this.toolStripSeparator5,
            this.mnuTimeAttendanceReport,
            this.toolStripSeparator6});
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem4.Text = "Reports";
            // 
            // mnuStaffList
            // 
            this.mnuStaffList.Name = "mnuStaffList";
            this.mnuStaffList.Size = new System.Drawing.Size(201, 22);
            this.mnuStaffList.Text = "Staff List Report";
            this.mnuStaffList.Click += new System.EventHandler(this.mnuStaffList_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuTimeAttendanceReport
            // 
            this.mnuTimeAttendanceReport.Name = "mnuTimeAttendanceReport";
            this.mnuTimeAttendanceReport.Size = new System.Drawing.Size(201, 22);
            this.mnuTimeAttendanceReport.Text = "Time Attendance Report";
            this.mnuTimeAttendanceReport.Click += new System.EventHandler(this.mnuTimeAttendanceReport_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(198, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.toolStripMenuItem8.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem8.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem8.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // ToolStripMenuItemWindow
            // 
            this.ToolStripMenuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLayoutCascade,
            this.toolStripSeparator12,
            this.mnuLayoutTile,
            this.toolStripSeparator13});
            this.ToolStripMenuItemWindow.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenuItemWindow.ForeColor = System.Drawing.Color.Maroon;
            this.ToolStripMenuItemWindow.Name = "ToolStripMenuItemWindow";
            this.ToolStripMenuItemWindow.Size = new System.Drawing.Size(66, 20);
            this.ToolStripMenuItemWindow.Text = "Window";
            // 
            // mnuLayoutCascade
            // 
            this.mnuLayoutCascade.Name = "mnuLayoutCascade";
            this.mnuLayoutCascade.Size = new System.Drawing.Size(116, 22);
            this.mnuLayoutCascade.Text = "Cascade";
            this.mnuLayoutCascade.Click += new System.EventHandler(this.mnuLayoutCascade_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuLayoutTile
            // 
            this.mnuLayoutTile.Name = "mnuLayoutTile";
            this.mnuLayoutTile.Size = new System.Drawing.Size(116, 22);
            this.mnuLayoutTile.Text = "Tile";
            this.mnuLayoutTile.Click += new System.EventHandler(this.mnuLayoutTile_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.toolStripMenuItem6.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItem6.Text = "Exit";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(96, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStudentCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(633, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(77, 17);
            this.lblStudentCount.Text = "Student Count";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 429);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grFingerXCtrl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "STUDENT BIOMETRIC SYSTEM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grFingerXCtrl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxGrFingerXLib.AxGrFingerXCtrl grFingerXCtrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonalDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStudentCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuAttendanceRecords;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuStaffList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuTimeAttendanceReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuLayoutCascade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem mnuLayoutTile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

