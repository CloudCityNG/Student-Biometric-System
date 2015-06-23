using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AttendanceVerification.Commons;
using Microsoft.Reporting.WinForms;

namespace AttendanceVerification
{
    public partial class StudentListReport : Form
    {
        SqlCommand command;
        SqlConnection connection;
        string title = "Staff List";
        public StudentListReport()
        {
            InitializeComponent();
            connection = DBHelper.GetConnection();
        }

        private void StaffListReport_Load(object sender, EventArgs e)
        {
            fillReport();
        }

        private void fillReport()
        {
            string query = "SELECT p.national_id ID, p.surname Surname, " +
                "p.first_name FirstName,p.other_name OtherNames FROM dbo.person p order by p.surname asc";

            command = connection.GetCommand(query, CommandType.Text);
            DataTable staffDt = DatabaseManipulate.GetDataTable(command);

            command = connection.GetCommand(DatabaseManipulate.strOrganization, CommandType.Text);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("date", DatabaseManipulate.getDate()));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("person", staffDt));

            this.reportViewer1.RefreshReport();
        }

        private void cmdEXit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
