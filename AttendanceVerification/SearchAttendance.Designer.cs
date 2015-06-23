namespace AttendanceVerification
{
    partial class SearchAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAttendance));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.optDate = new System.Windows.Forms.CheckBox();
            this.optTime = new System.Windows.Forms.CheckBox();
            this.optID = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.optDate);
            this.groupBox1.Controls.Add(this.optTime);
            this.groupBox1.Controls.Add(this.optID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Bodoni MT Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Lavender;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(14, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 35);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "*** Select the following applicable options to proceed";
            // 
            // optDate
            // 
            this.optDate.AutoSize = true;
            this.optDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDate.Location = new System.Drawing.Point(22, 114);
            this.optDate.Name = "optDate";
            this.optDate.Size = new System.Drawing.Size(107, 19);
            this.optDate.TabIndex = 1;
            this.optDate.Text = "Search by Date";
            this.optDate.UseVisualStyleBackColor = true;
            // 
            // optTime
            // 
            this.optTime.AutoSize = true;
            this.optTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTime.Location = new System.Drawing.Point(22, 87);
            this.optTime.Name = "optTime";
            this.optTime.Size = new System.Drawing.Size(108, 19);
            this.optTime.TabIndex = 2;
            this.optTime.Text = "Search by Time";
            this.optTime.UseVisualStyleBackColor = true;
            // 
            // optID
            // 
            this.optID.AutoSize = true;
            this.optID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optID.Location = new System.Drawing.Point(22, 60);
            this.optID.Name = "optID";
            this.optID.Size = new System.Drawing.Size(92, 19);
            this.optID.TabIndex = 3;
            this.optID.Text = "Search By ID";
            this.optID.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdCancel.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = global::AttendanceVerification.Properties.Resources.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(151, 156);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 51);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdContinue
            // 
            this.cmdContinue.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdContinue.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdContinue.Image = global::AttendanceVerification.Properties.Resources.Ok;
            this.cmdContinue.Location = new System.Drawing.Point(70, 156);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(75, 51);
            this.cmdContinue.TabIndex = 2;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdContinue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdContinue.UseVisualStyleBackColor = false;
            // 
            // SearchAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(227, 210);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchAttendance";
            this.Text = "Search Attendance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox optDate;
        private System.Windows.Forms.CheckBox optTime;
        private System.Windows.Forms.CheckBox optID;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.TextBox textBox1;
    }
}