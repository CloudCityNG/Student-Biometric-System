namespace AttendanceVerification
{
    partial class StudentListReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentListReport));
            this.PersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmdEXit = new System.Windows.Forms.Button();
            this.Data = new AttendanceVerification.Data();
            ((System.ComponentModel.ISupportInitialize)(this.PersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // PersonBindingSource
            // 
            this.PersonBindingSource.DataMember = "Person";
            // 
            // DateBindingSource
            // 
            this.DateBindingSource.DataMember = "Date";
            // 
            // OrgBindingSource
            // 
            this.OrgBindingSource.DataMember = "Org";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "person";
            reportDataSource1.Value = this.PersonBindingSource;
            reportDataSource2.Name = "date";
            reportDataSource2.Value = this.DateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AttendanceVerification.StaffListReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(410, 473);
            this.reportViewer1.TabIndex = 0;
            // 
            // cmdEXit
            // 
            this.cmdEXit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdEXit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEXit.Location = new System.Drawing.Point(347, 491);
            this.cmdEXit.Name = "cmdEXit";
            this.cmdEXit.Size = new System.Drawing.Size(75, 23);
            this.cmdEXit.TabIndex = 1;
            this.cmdEXit.Text = "Exit";
            this.cmdEXit.UseVisualStyleBackColor = false;
            this.cmdEXit.Click += new System.EventHandler(this.cmdEXit_Click);
            // 
            // Data
            // 
            this.Data.DataSetName = "Data";
            this.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentListReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(434, 517);
            this.Controls.Add(this.cmdEXit);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentListReport";
            this.Text = "Student List Report";
            this.Load += new System.EventHandler(this.StaffListReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PersonBindingSource;
        private System.Windows.Forms.BindingSource OrgBindingSource;
        private System.Windows.Forms.BindingSource DateBindingSource;
        private System.Windows.Forms.Button cmdEXit;
        private Data Data;
    }
}