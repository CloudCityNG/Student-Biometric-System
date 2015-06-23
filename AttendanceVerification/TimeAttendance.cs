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

namespace AttendanceVerification
{
    public partial class TimeAttendance : Form
    {
        DateTime timeIn, timeOut;
        TimeSpan timeDifference;
        //string connectionString = "Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=10;server=.\\SQLEXPRESS;database=organization;Integrated Security=false;User Id=school;Password=school!;";
        SqlConnection connection;
        SqlCommand command;
        string dayDate;
        string title = "Time Attendance";
        string person_id, attendance_id,name;
        double diff;
        TimeAttendanceData data;
        public TimeAttendance(TimeAttendanceData data)
        {
            InitializeComponent();
            connection = DBHelper.GetConnection();
            dayDate = DateTime.Now.ToShortDateString();
            this.data = data;
            cmdSignIn.Enabled = false;
            cmdSignOut.Enabled = false;
        }

        private void cmdSignIn_Click(object sender, EventArgs e)
        {
            timeIn = Convert.ToDateTime(dtpTime.Text);
            saveSignIn();
        }

        private void cmdSignOut_Click(object sender, EventArgs e)
        {
            timeOut = Convert.ToDateTime(dtpTime.Text);

            timeDifference = timeOut - timeIn;
            //MessageBox.Show(timeDifference.Minutes.ToString());

            diff = Convert.ToDouble(timeDifference.Minutes);

            saveSignOut();
        }

        private void optstaffNumber_CheckedChanged(object sender, EventArgs e)
        {
            optNationalID.Checked = false;
        }

        private void clearConrols()
        {
            cmdSignIn.Enabled = false;
            cmdSignOut.Enabled = false;
            txtId.Enabled = true;
            txtName.Text = "";
            txtId.Text = "";
        }

        private void saveSignOut()
        {
            try
            {
                //create the command    
                using (command = connection.GetCommand("select * from dbo.time_attendance p where " +
                    "p.national_id=@national_id and p.action = 1 and dayDate=@dayDate", CommandType.Text))
                {
                    command.AddParameter("@national_id", txtId.Text, SqlDbType.VarChar);
                    command.AddParameter("@action", 2, SqlDbType.Int);
                    command.AddParameter("@time_out", timeOut, SqlDbType.DateTime);
                    command.AddParameter("@minutes", diff, SqlDbType.Float);
                    command.AddParameter("@attendance_id", attendance_id, SqlDbType.VarChar);
                    command.AddParameter("@dayDate", dayDate, SqlDbType.Date);

                    command.CommandText = "UPDATE dbo.time_attendance SET " +
                        "time_out = @time_out, " +
                        "minutes = @minutes, " +
                        "action =  @action " +
                        "WHERE attendance_id = @attendance_id";

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        new OpenForms().openModalForm(new GoodBye(txtName.Text));
                        data.getAttendanceRecords();
                        clearConrols();
                    }
                    else
                    {
                        Messaging.information("Log out failed!", title);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveSignIn()
        {
            diff = 0;
            attendance_id = txtId.Text+" "+dayDate + " " + timeIn;
            try
            {
                //create the command    
                using (command = connection.GetCommand("select p.person_id pid, p.national_id nid " +
                        "from dbo.person p where p.national_id=@national_id", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@national_id", txtId.Text, SqlDbType.VarChar);
                    command.AddParameter("@time_in", timeIn, SqlDbType.DateTime);
                    command.AddParameter("@dayDate", dayDate, SqlDbType.Date);
                    command.AddParameter("@action", 1, SqlDbType.Int);
                    command.AddParameter("@attendance_id", attendance_id, SqlDbType.VarChar);

                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                person_id = Convert.ToString(reader["pid"]);
                                //national_id = Convert.ToString(reader["nid"]);
                            }
                            command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                            reader.Close();
                            command.CommandText = "INSERT INTO dbo.time_attendance (person_id, national_id, time_in, dayDate, action,attendance_id) " +
                                "VALUES (@person_id, @national_id, @time_in, @dayDate, @action,@attendance_id)";

                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                new OpenForms().openModalForm(new Welcome(txtName.Text));
                                data.getAttendanceRecords();
                                clearConrols();
                            }
                            else
                            {
                                Messaging.information("Log in failed!", title);
                            }
                        }
                        else
                        {
                            Messaging.warning("Person not found!", title);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string findPerson()
        {
            string act = "";
            if (txtId.Text.Equals(""))
            {
                Messaging.warning("Enter student national ID to proceed", title);
            }
            else
            {
                try
                {
                    command = connection.GetCommand("select p.action action, p.attendance_id attendance, p.time_in timeIn " +
                        "from dbo.time_attendance p where p.national_id=@national_id "+
                        "and dayDate=@dayDate", CommandType.Text);
                    //create the command
                    command.AddParameter("@national_id", txtId.Text, SqlDbType.VarChar);
                    command.AddParameter("@dayDate", dayDate, SqlDbType.Date);

                    using (command)
                    {
                        // initialize the reader and execute the command 
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                act = Convert.ToString(reader["action"]);
                                attendance_id = Convert.ToString(reader["attendance"]);
                                timeIn = Convert.ToDateTime(reader["timeIn"]);
                            }
                            
                        }
                        else
                        {
                            act = "2";
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Messaging.error( ex.ToString(), title);
                }
            }
            return act;
        }

        private bool isStaff()
        {
            bool isFound = false;
            if (txtId.Text.Equals(""))
            {
                Messaging.warning("Enter staff national ID to proceed", title);
            }
            else
            {
                try
                {
                    command = connection.GetCommand("select * from dbo.person p where p.national_id=@national_id ", CommandType.Text);
                    //create the command
                    command.AddParameter("@national_id", txtId.Text, SqlDbType.VarChar);

                    using (command)
                    {
                        // initialize the reader and execute the command 
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            isFound = true;
                            while (reader.Read())
                            {
                                name = Convert.ToString(reader["surname"]) + " " + Convert.ToString(reader["first_name"]) + " "
                                    + Convert.ToString(reader["other_name"]);
                                txtName.Text = name;
                            }
                        }
                        else
                        {
                            Messaging.warning("Invalid ID number! Please re-enter ID number.", title);
                            txtId.Focus();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Messaging.error( ex.ToString(), title);
                }
            }
            return isFound;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (isStaff())
            {
                txtId.Enabled = false;
                if (findPerson().Equals("1"))
                {
                    cmdSignOut.Enabled = true;
                }
                else
                {
                    cmdSignIn.Enabled = true;
                }
            }
        }
    }
}
