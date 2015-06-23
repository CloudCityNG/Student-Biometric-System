namespace AttendanceVerification
{
    partial class TimeAttendanceData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeAttendanceData));
            this.lstvStaffDetails = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_in = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_out = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_elapsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdsearch = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblbiometric = new System.Windows.Forms.Label();
            this.optIdentificationMode = new System.Windows.Forms.RadioButton();
            this.optVerificationMode = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lstvStaffDetails
            // 
            this.lstvStaffDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.time_in,
            this.time_out,
            this.time_elapsed});
            this.lstvStaffDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvStaffDetails.FullRowSelect = true;
            this.lstvStaffDetails.Location = new System.Drawing.Point(8, 77);
            this.lstvStaffDetails.MultiSelect = false;
            this.lstvStaffDetails.Name = "lstvStaffDetails";
            this.lstvStaffDetails.ShowItemToolTips = true;
            this.lstvStaffDetails.Size = new System.Drawing.Size(854, 400);
            this.lstvStaffDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstvStaffDetails.TabIndex = 45;
            this.lstvStaffDetails.UseCompatibleStateImageBehavior = false;
            this.lstvStaffDetails.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Student ID";
            this.id.Width = 100;
            // 
            // name
            // 
            this.name.Text = "Staff Names";
            this.name.Width = 250;
            // 
            // time_in
            // 
            this.time_in.Text = "Time In";
            this.time_in.Width = 200;
            // 
            // time_out
            // 
            this.time_out.Text = "Time Out";
            this.time_out.Width = 200;
            // 
            // time_elapsed
            // 
            this.time_elapsed.Text = "Time Elapsed";
            this.time_elapsed.Width = 99;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdExit.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = global::AttendanceVerification.Properties.Resources.Exit;
            this.cmdExit.Location = new System.Drawing.Point(868, 225);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 65);
            this.cmdExit.TabIndex = 49;
            this.cmdExit.Text = "Exit";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdsearch
            // 
            this.cmdsearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdsearch.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsearch.Image = global::AttendanceVerification.Properties.Resources.Search;
            this.cmdsearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdsearch.Location = new System.Drawing.Point(868, 77);
            this.cmdsearch.Name = "cmdsearch";
            this.cmdsearch.Size = new System.Drawing.Size(74, 68);
            this.cmdsearch.TabIndex = 47;
            this.cmdsearch.Text = "Search";
            this.cmdsearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdsearch.UseVisualStyleBackColor = false;
            this.cmdsearch.Click += new System.EventHandler(this.cmdsearch_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdAdd.BackgroundImage = global::AttendanceVerification.Properties.Resources.Manual_attendance;
            this.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdAdd.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAdd.Location = new System.Drawing.Point(868, 151);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(74, 68);
            this.cmdAdd.TabIndex = 46;
            this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(481, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "***Attendance Records for Date :";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.Lavender;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.Maroon;
            this.txtDate.Location = new System.Drawing.Point(675, 43);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(187, 23);
            this.txtDate.TabIndex = 48;
            // 
            // lblbiometric
            // 
            this.lblbiometric.AutoSize = true;
            this.lblbiometric.Font = new System.Drawing.Font("Californian FB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbiometric.ForeColor = System.Drawing.Color.Red;
            this.lblbiometric.Location = new System.Drawing.Point(9, 14);
            this.lblbiometric.Name = "lblbiometric";
            this.lblbiometric.Size = new System.Drawing.Size(208, 14);
            this.lblbiometric.TabIndex = 49;
            this.lblbiometric.Text = "Biometric Time Attendance Activated";
            // 
            // optIdentificationMode
            // 
            this.optIdentificationMode.AutoSize = true;
            this.optIdentificationMode.Checked = true;
            this.optIdentificationMode.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optIdentificationMode.ForeColor = System.Drawing.Color.Red;
            this.optIdentificationMode.Location = new System.Drawing.Point(12, 43);
            this.optIdentificationMode.Name = "optIdentificationMode";
            this.optIdentificationMode.Size = new System.Drawing.Size(137, 19);
            this.optIdentificationMode.TabIndex = 50;
            this.optIdentificationMode.TabStop = true;
            this.optIdentificationMode.Text = "Identification Mode";
            this.optIdentificationMode.UseVisualStyleBackColor = true;
            // 
            // optVerificationMode
            // 
            this.optVerificationMode.AutoSize = true;
            this.optVerificationMode.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVerificationMode.ForeColor = System.Drawing.Color.Red;
            this.optVerificationMode.Location = new System.Drawing.Point(168, 43);
            this.optVerificationMode.Name = "optVerificationMode";
            this.optVerificationMode.Size = new System.Drawing.Size(126, 19);
            this.optVerificationMode.TabIndex = 51;
            this.optVerificationMode.Text = "Verification Mode";
            this.optVerificationMode.UseVisualStyleBackColor = true;
            // 
            // TimeAttendanceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(950, 485);
            this.Controls.Add(this.optVerificationMode);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.optIdentificationMode);
            this.Controls.Add(this.cmdsearch);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblbiometric);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstvStaffDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeAttendanceData";
            this.Text = "Time Attendance Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeAttendanceData_FormClosing);
            this.Load += new System.EventHandler(this.TimeAttendanceData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstvStaffDetails;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader time_in;
        private System.Windows.Forms.ColumnHeader time_out;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblbiometric;
        private System.Windows.Forms.RadioButton optIdentificationMode;
        private System.Windows.Forms.RadioButton optVerificationMode;
        private System.Windows.Forms.ColumnHeader time_elapsed;
    }
}