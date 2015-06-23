namespace AttendanceVerification
{
    partial class StudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentList));
            this.optSearchIDname = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstvStaffDetails = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.names = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdViewStaffDetails = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mnuNewStudent = new System.Windows.Forms.Button();
            this.cmdEnrollFingerprintBiometrics = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optSearchStaffNumber = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optSearchIDname
            // 
            this.optSearchIDname.AutoSize = true;
            this.optSearchIDname.Font = new System.Drawing.Font("Calisto MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSearchIDname.Location = new System.Drawing.Point(7, 7);
            this.optSearchIDname.Name = "optSearchIDname";
            this.optSearchIDname.Size = new System.Drawing.Size(146, 21);
            this.optSearchIDname.TabIndex = 11;
            this.optSearchIDname.TabStop = true;
            this.optSearchIDname.Text = "Search by Student ID";
            this.optSearchIDname.UseVisualStyleBackColor = true;
            this.optSearchIDname.CheckedChanged += new System.EventHandler(this.optSearchIDname_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(4, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(326, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "N/B double click on the name row you want to edit details";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(77, 44);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 20);
            this.txtSearch.TabIndex = 10;
            // 
            // lstvStaffDetails
            // 
            this.lstvStaffDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvStaffDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstvStaffDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.id,
            this.names});
            this.lstvStaffDetails.Font = new System.Drawing.Font("Calisto MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvStaffDetails.FullRowSelect = true;
            this.lstvStaffDetails.Location = new System.Drawing.Point(3, 100);
            this.lstvStaffDetails.MultiSelect = false;
            this.lstvStaffDetails.Name = "lstvStaffDetails";
            this.lstvStaffDetails.ShowItemToolTips = true;
            this.lstvStaffDetails.Size = new System.Drawing.Size(572, 423);
            this.lstvStaffDetails.TabIndex = 0;
            this.lstvStaffDetails.UseCompatibleStateImageBehavior = false;
            this.lstvStaffDetails.View = System.Windows.Forms.View.Details;
            this.lstvStaffDetails.SelectedIndexChanged += new System.EventHandler(this.lstvStaffDetails_SelectedIndexChanged);
            this.lstvStaffDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvStaffDetails_MouseDoubleClick);
            // 
            // no
            // 
            this.no.Text = "No#";
            // 
            // id
            // 
            this.id.Text = "Student ID";
            this.id.Width = 160;
            // 
            // names
            // 
            this.names.Text = "Staff Name";
            this.names.Width = 350;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::AttendanceVerification.Properties.Resources.Search;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(258, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 25);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Find    ";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calisto MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdExit.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.Color.Black;
            this.cmdExit.Location = new System.Drawing.Point(585, 279);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(195, 36);
            this.cmdExit.TabIndex = 11;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdViewStaffDetails
            // 
            this.cmdViewStaffDetails.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdViewStaffDetails.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewStaffDetails.ForeColor = System.Drawing.Color.Black;
            this.cmdViewStaffDetails.Location = new System.Drawing.Point(585, 195);
            this.cmdViewStaffDetails.Name = "cmdViewStaffDetails";
            this.cmdViewStaffDetails.Size = new System.Drawing.Size(195, 36);
            this.cmdViewStaffDetails.TabIndex = 0;
            this.cmdViewStaffDetails.Text = "Student Personal details";
            this.cmdViewStaffDetails.UseVisualStyleBackColor = false;
            this.cmdViewStaffDetails.Click += new System.EventHandler(this.cmdViewStaffDetails_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(588, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 49);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "N/B Select the name row you want then click on the option you want below";
            // 
            // mnuNewStudent
            // 
            this.mnuNewStudent.BackColor = System.Drawing.Color.AliceBlue;
            this.mnuNewStudent.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuNewStudent.Location = new System.Drawing.Point(585, 158);
            this.mnuNewStudent.Name = "mnuNewStudent";
            this.mnuNewStudent.Size = new System.Drawing.Size(195, 36);
            this.mnuNewStudent.TabIndex = 14;
            this.mnuNewStudent.Text = "New Student Details";
            this.mnuNewStudent.UseVisualStyleBackColor = false;
            this.mnuNewStudent.Click += new System.EventHandler(this.mnuNewStaff_Click);
            // 
            // cmdEnrollFingerprintBiometrics
            // 
            this.cmdEnrollFingerprintBiometrics.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdEnrollFingerprintBiometrics.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnrollFingerprintBiometrics.Location = new System.Drawing.Point(585, 237);
            this.cmdEnrollFingerprintBiometrics.Name = "cmdEnrollFingerprintBiometrics";
            this.cmdEnrollFingerprintBiometrics.Size = new System.Drawing.Size(195, 36);
            this.cmdEnrollFingerprintBiometrics.TabIndex = 16;
            this.cmdEnrollFingerprintBiometrics.Text = "Enroll Fingerprint Biometrics";
            this.cmdEnrollFingerprintBiometrics.UseVisualStyleBackColor = false;
            this.cmdEnrollFingerprintBiometrics.Click += new System.EventHandler(this.cmdEnrollFingerprintBiometrics_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Snow;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.optSearchStaffNumber);
            this.panel1.Controls.Add(this.lstvStaffDetails);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.optSearchIDname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 526);
            this.panel1.TabIndex = 21;
            // 
            // optSearchStaffNumber
            // 
            this.optSearchStaffNumber.AutoSize = true;
            this.optSearchStaffNumber.Font = new System.Drawing.Font("Calisto MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSearchStaffNumber.Location = new System.Drawing.Point(224, 7);
            this.optSearchStaffNumber.Name = "optSearchStaffNumber";
            this.optSearchStaffNumber.Size = new System.Drawing.Size(14, 13);
            this.optSearchStaffNumber.TabIndex = 12;
            this.optSearchStaffNumber.TabStop = true;
            this.optSearchStaffNumber.UseVisualStyleBackColor = true;
            this.optSearchStaffNumber.Visible = false;
            this.optSearchStaffNumber.CheckedChanged += new System.EventHandler(this.optSearchStaffNumber_CheckedChanged);
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(784, 528);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdEnrollFingerprintBiometrics);
            this.Controls.Add(this.mnuNewStudent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdViewStaffDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "StaffList";
            this.Load += new System.EventHandler(this.StaffList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lstvStaffDetails;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader names;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optSearchIDname;
        private System.Windows.Forms.Button cmdViewStaffDetails;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button mnuNewStudent;
        private System.Windows.Forms.Button cmdEnrollFingerprintBiometrics;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.RadioButton optSearchStaffNumber;
    }
}