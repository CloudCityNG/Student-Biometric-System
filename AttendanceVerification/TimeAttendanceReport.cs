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
    public partial class TimeAttendanceReport : Form
    {
        string title="Time Attendance Report";
        SqlCommand command;
        SqlConnection connection;
        string query;
        public TimeAttendanceReport()
        {
            InitializeComponent();
            connection = DBHelper.GetConnection();
            fillSearchByCombo();
        }

        private void fillSearchByCombo()
        {
            this.cmbSearchBy.Items.Add("   Select Search By");
            this.cmbSearchBy.Items.Add("All");
            this.cmbSearchBy.Items.Add("National ID Number");
            this.cmbSearchBy.Items.Add("Date");
            this.cmbSearchBy.Items.Add("Date and National ID Number");

            this.cmbSearchBy.Text = "   Select Search By";
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbFilterBy.Items.Clear();
            this.cmbFilterBy.Items.Add("- Select filter by -");
            this.cmbFilterBy.Text ="- Select filter by -";
            if (!cmbSearchBy.Text.Equals("   Select Search By"))
            {
                if (cmbSearchBy.Text.Equals("National ID Number"))
                {
                    this.cmbFilterBy.Items.Clear();
                    this.cmbFilterBy.Items.Add("Equals");
                    this.cmbFilterBy.Items.Add("Not Equals");
                }
                else if (cmbSearchBy.Text.Equals("Date"))
                {
                    this.cmbFilterBy.Items.Clear();
                    this.cmbFilterBy.Items.Add("Equals");
                    this.cmbFilterBy.Items.Add("Not Equals");
                    this.cmbFilterBy.Items.Add("Between");
                    this.cmbFilterBy.Items.Add("Less Than");
                    this.cmbFilterBy.Items.Add("Greater Than");
                }
                else if (cmbSearchBy.Text.Equals("Date and National ID Number"))
                {
                    this.cmbFilterBy.Items.Clear();
                    this.cmbFilterBy.Items.Add("Equals");
                    this.cmbFilterBy.Items.Add("Not Equals");
                }
            }
            else
            {
                Messaging.warning("Please select search criteria", title);
                cmbSearchBy.Focus();
            }
        }

        private void fillReport()
        {
            if (cmbSearchBy.Text.Equals("All"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "order by t.dayDate asc";
                command = connection.GetCommand(query, CommandType.Text);
            }
            else if (cmbFilterBy.Text.Equals("- Select filter by -")){
                MessageBox.Show(this, "Select 'filter by'", "Missing Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFilterBy.Focus();

                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and p.national_id=@national_id order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                command.AddParameter("@national_id", "", SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("National ID Number") && cmbFilterBy.Text.Equals("Equals"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and p.national_id=@national_id order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                command.AddParameter("@national_id", txtSearch.Text, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("National ID Number") && cmbFilterBy.Text.Equals("Not Equals"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and p.national_id <> @national_id order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                command.AddParameter("@national_id", txtSearch.Text, SqlDbType.VarChar);
            }
            
            else if (cmbSearchBy.Text.Equals("Date") && cmbFilterBy.Text.Equals("Equals"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and t.dayDate = @dayDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string strDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@dayDate", strDate, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("Date") && cmbFilterBy.Text.Equals("Not Equals"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and t.dayDate <> @dayDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string strDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@dayDate", strDate, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("Date") && cmbFilterBy.Text.Equals("Between"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and t.dayDate between @startDate and @endDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string startDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@startDate", startDate, SqlDbType.VarChar);
                dt = dtpEndDate.Value;
                string endDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@endDate", endDate, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("Date") && cmbFilterBy.Text.Equals("Less Than"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and t.dayDate < @dayDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string strDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@dayDate", strDate, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("Date") && cmbFilterBy.Text.Equals("Greater Than"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and t.dayDate > @dayDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string strDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@dayDate", strDate, SqlDbType.VarChar);
            }
            else if (cmbSearchBy.Text.Equals("Date and National ID Number") && cmbFilterBy.Text.Equals("Equals"))
            {
                query = "select p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
                "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
                "from dbo.person p, dbo.time_attendance t where p.person_id=t.person_id " +
                "and p.national_id=@national_id and t.dayDate = @dayDate order by t.dayDate asc";

                command = connection.GetCommand(query, CommandType.Text);
                DateTime dt = dtpStartDate.Value;
                string strDate = dt.Date.ToString("yyyy - MM - dd");
                command.AddParameter("@dayDate", strDate, SqlDbType.VarChar);
                command.AddParameter("@national_id", txtSearch.Text, SqlDbType.VarChar);
            }

            //query = "select pj.staff_no StaffId, p.national_id NationalID,p.surname Surname, p.first_name FirstName, " +
            //    "p.other_name Middlename, t.dayDate Date, t.time_in TimeIn, t.time_out TimeOut, t.minutes TimeStayed " +
            //    "from dbo.person p, dbo.time_attendance t, dbo.person_job pj where p.person_id=t.person_id and pj.person_id=p.person_id " +
            //    "order by t.dayDate asc";
            
            DataTable staffDt = DatabaseManipulate.GetDataTable(command);

            //command = connection.GetCommand(DatabaseManipulate.strOrganization, CommandType.Text);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("date", DatabaseManipulate.getDate()));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("attendance", staffDt));

            this.reportViewer1.RefreshReport();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
        }

        
        private void TimeAttendanceReport_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillReport();
        }

        
    }
}
