namespace AttendanceVerification
{
    partial class TimeAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeAttendance));
            this.cmdSignIn = new System.Windows.Forms.Button();
            this.cmdSignOut = new System.Windows.Forms.Button();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optNationalID = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSignIn
            // 
            this.cmdSignIn.BackColor = System.Drawing.Color.Lavender;
            this.cmdSignIn.Font = new System.Drawing.Font("Californian FB", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSignIn.Image = ((System.Drawing.Image)(resources.GetObject("cmdSignIn.Image")));
            this.cmdSignIn.Location = new System.Drawing.Point(72, 182);
            this.cmdSignIn.Name = "cmdSignIn";
            this.cmdSignIn.Size = new System.Drawing.Size(76, 66);
            this.cmdSignIn.TabIndex = 16;
            this.cmdSignIn.Text = "Sign In";
            this.cmdSignIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdSignIn.UseVisualStyleBackColor = false;
            this.cmdSignIn.Click += new System.EventHandler(this.cmdSignIn_Click);
            // 
            // cmdSignOut
            // 
            this.cmdSignOut.BackColor = System.Drawing.Color.Lavender;
            this.cmdSignOut.Font = new System.Drawing.Font("Californian FB", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSignOut.Image = ((System.Drawing.Image)(resources.GetObject("cmdSignOut.Image")));
            this.cmdSignOut.Location = new System.Drawing.Point(151, 182);
            this.cmdSignOut.Name = "cmdSignOut";
            this.cmdSignOut.Size = new System.Drawing.Size(76, 66);
            this.cmdSignOut.TabIndex = 15;
            this.cmdSignOut.Text = "Sign Out";
            this.cmdSignOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdSignOut.UseVisualStyleBackColor = false;
            this.cmdSignOut.Click += new System.EventHandler(this.cmdSignOut_Click);
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(127, 138);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(93, 21);
            this.dtpTime.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.optNationalID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 45);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // optNationalID
            // 
            this.optNationalID.AutoSize = true;
            this.optNationalID.Checked = true;
            this.optNationalID.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNationalID.Location = new System.Drawing.Point(16, 18);
            this.optNationalID.Name = "optNationalID";
            this.optNationalID.Size = new System.Drawing.Size(166, 21);
            this.optNationalID.TabIndex = 0;
            this.optNationalID.TabStop = true;
            this.optNationalID.Text = "Search by national ID";
            this.optNationalID.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.Maroon;
            this.txtId.Location = new System.Drawing.Point(127, 68);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(124, 21);
            this.txtId.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "National ID :";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.Lavender;
            this.cmdExit.Font = new System.Drawing.Font("Californian FB", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = global::AttendanceVerification.Properties.Resources.Exit;
            this.cmdExit.Location = new System.Drawing.Point(230, 182);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(76, 66);
            this.cmdExit.TabIndex = 17;
            this.cmdExit.Text = "Exit";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.BackColor = System.Drawing.Color.Lavender;
            this.cmdFind.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Image = global::AttendanceVerification.Properties.Resources.Search;
            this.cmdFind.Location = new System.Drawing.Point(266, 60);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 35);
            this.cmdFind.TabIndex = 18;
            this.cmdFind.Text = "Find";
            this.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdFind.UseVisualStyleBackColor = false;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Maroon;
            this.txtName.Location = new System.Drawing.Point(40, 105);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(301, 19);
            this.txtName.TabIndex = 19;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(379, 263);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSignIn);
            this.Controls.Add(this.cmdSignOut);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeAttendance";
            this.Text = "Time Attendance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSignIn;
        private System.Windows.Forms.Button cmdSignOut;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optNationalID;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.TextBox txtName;
    }
}