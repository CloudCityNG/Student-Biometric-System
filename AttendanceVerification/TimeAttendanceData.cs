using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceVerification.Commons;
using System.Data.SqlClient;

namespace AttendanceVerification
{
    public partial class TimeAttendanceData : Form
    {
        Main system;
        SqlCommand command;
        string[] data;
        //string connectionString = "Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=10;server=.\\SQLEXPRESS;database=organization;Integrated Security=false;User Id=school;Password=school!;";
        SqlConnection connection;
        string title = "Time Attendance";
        private FingerprintOPFormAuth fingerprintOP;
        string dayDate;
        string person_id, attendance_id;
        DateTime timeIn, timeOut;
        TimeSpan timeDifference;
        public string findNationalID="";
        double diff;
        public int found = 0;
        public TimeAttendanceData(Main system, FingerprintOPFormAuth fingerprintOP)
        {
            InitializeComponent();
            connection = DBHelper.GetConnection();
            this.system = system;
            this.fingerprintOP = fingerprintOP;
            getAttendanceRecords();
            dayDate = DateTime.Now.ToShortDateString();
            //cmdsearch.Visible = false;
            //cmdBiometricTimeAttendance.Visible = false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            new OpenForms().openModalForm(new TimeAttendance(this));
        }

        private void cmdsearch_Click(object sender, EventArgs e)
        {
            new OpenForms().openModalForm(new SearchAttendance(this));
        }


        private void TimeAttendanceData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Messaging.confirmAction("Are you sure you want to exit?"))
            {
                e.Cancel = true;
            }
            else
            {
                system.Show();
            }                
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void biometricTimeAttendance_Click(object sender, EventArgs e)
        {
            lblbiometric.Visible = true;
            optIdentificationMode.Visible = true;
            optVerificationMode.Visible = true;
        }

        public void onImageAcquired(Image handle, object rawImage, int height, int width, int res)
        {
            //set the parameters in the FingerprintOPFormUSerMgt class
            fingerprintOP.rawImage.img = rawImage;
            fingerprintOP.rawImage.height = height;
            fingerprintOP.rawImage.width = width;
            fingerprintOP.rawImage.Res = res;

            //finally , we extract the template and try to validate de user
            fingerprintOP.extractTemplate();

            if (optIdentificationMode.Checked)
            {
                identify();
            }
            else if (optVerificationMode.Checked)
            {
                new OpenForms().openModalForm(new IDInputForm(this));
            }

        }

        public void getAttendanceRecords()
        {
            
            command = connection.GetCommand("Select p.national_id,p.surname,p.first_name, p.other_name, "+
                "t.time_in,t.time_out, t.minutes from dbo.person p, dbo.time_attendance t where " +
                "t.person_id=p.person_id and t.dayDate=@dayDate", CommandType.Text);
            DateTime dt=DateTime.Now;
            string strDate= dt.Date.ToString("yyyy - MM - dd");
            command.AddParameter("@dayDate",strDate, SqlDbType.VarChar);
            txtDate.Text =strDate;   
            using (command)
            {

                // initialize the reader and execute the command 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int i = 0;
                        lstvStaffDetails.Items.Clear();
                        while (reader.Read())
                        {
                            // Create a ListViewItem object for evey item that you wish to add the ListView.
                            string[] lv = new String[5];

                            //lv[0] = Convert.ToString(reader["staff_no"]);
                            lv[0] = Convert.ToString(reader["national_id"]);
                            lv[1] = Convert.ToString(reader["surname"]) + " " + Convert.ToString(reader["first_name"])
                                + " " + Convert.ToString(reader["other_name"]);
                            lv[2] = Convert.ToString(reader["time_in"]);
                            lv[3] = Convert.ToString(reader["time_out"]);
                            lv[4] = Convert.ToString(reader["minutes"]);

                            lstvStaffDetails.Items.Add(new ListViewItem(lv, i)); 
                            i++;
                        }
                        reader.Close();

                        ListViewRowColors.recolorListItems(lstvStaffDetails);
                    }
                    else
                    {
                        Messaging.information("No attendance details for this day is found found!", title);
                    }
                }
            }
        }

        private void identify()
        {
            bool isAuthentic = false;
            string personId = "";
            string nationalId = "";
            string name = "";
            try
            {
                //create the command    
                using (command = connection.GetCommand("SELECT * FROM dbo.fingerprint f, dbo.person e where f.person_id=e.person_id", CommandType.Text))
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                name = Convert.ToString(reader["surname"]) + " " + Convert.ToString(reader["first_name"]) + " " + Convert.ToString(reader["other_name"]);
                                personId = Convert.ToString(reader["person_id"]);
                                nationalId = Convert.ToString(reader["national_id"]);

                                if (fingerprintOP.authenticate((byte[])reader["Template1"], (byte[])reader["Template2"], (byte[])reader["Template3"]))
                                {
                                    isAuthentic = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Messaging.warning("No fingerprint data found!", title);
                        }
                        reader.Close();
                    }
                }

                if (isAuthentic)
                {
                    if (findPerson(personId).Equals("1"))
                    {
                        timeOut = Convert.ToDateTime(DateTime.Now);

                        timeDifference = timeOut - timeIn;
                        //MessageBox.Show(timeDifference.Minutes.ToString());

                        diff = Convert.ToDouble(timeDifference.Minutes);
                        saveSignOut(nationalId,name);
                    }
                    else
                    {
                        timeIn = Convert.ToDateTime(DateTime.Now);
                        saveSignIn(personId, nationalId, name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void verify()
        {
            bool isAuthentic = false;
            string personId = "";
            string name = "";
            try
            {
                //create the command    
                using (command = connection.GetCommand("SELECT * FROM dbo.fingerprint f, dbo.person e where f.person_id=e.person_id and e.national_id =@national_id", CommandType.Text))
                {
                    command.AddParameter("@national_id", findNationalID, SqlDbType.VarChar);
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                found = 1;
                                name = Convert.ToString(reader["surname"]) + " " + Convert.ToString(reader["first_name"]) + " " + Convert.ToString(reader["other_name"]);
                                personId = Convert.ToString(reader["person_id"]);

                                if (fingerprintOP.authenticate((byte[])reader["Template1"], (byte[])reader["Template2"], (byte[])reader["Template3"]))
                                {
                                    isAuthentic = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            found = 0;
                            Messaging.warning("The ID you have entered is not found! Try again!", title);
                        }
                        reader.Close();
                    }
                }

                if (isAuthentic)
                {
                    if (findPerson(personId).Equals("1"))
                    {
                        timeOut = Convert.ToDateTime(DateTime.Now);

                        timeDifference = timeOut - timeIn;
                        //MessageBox.Show(timeDifference.Minutes.ToString());

                        diff = Convert.ToDouble(timeDifference.Minutes);
                        saveSignOut(findNationalID, name);
                    }
                    else
                    {
                        timeIn = Convert.ToDateTime(DateTime.Now);
                        saveSignIn(personId, findNationalID, name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimeAttendanceData_Load(object sender, EventArgs e)
        {

        }

        private string findPerson(string personId)
        {
            string act = "";
            try
            {
                command = connection.GetCommand("select p.action action, p.attendance_id attendance, p.time_in timeIn " +
                    "from dbo.time_attendance p where p.person_id=@person_id " +
                    "and dayDate=@dayDate", CommandType.Text);
                //create the command
                command.AddParameter("@person_id", personId, SqlDbType.VarChar);
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
                Messaging.error(ex.ToString(), title);
            }

            return act;
        }


        private void saveSignOut(string nationalId, string name)
        {
            try
            {
                //create the command    
                using (command = connection.GetCommand("select * from dbo.time_attendance p where " +
                    "p.national_id=@national_id and p.action = 1 and dayDate=@dayDate", CommandType.Text))
                {
                    command.AddParameter("@national_id", nationalId, SqlDbType.VarChar);
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
                        new OpenForms().openModalForm(new GoodBye(name));
                        this.getAttendanceRecords();
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

        private void saveSignIn(string personId, string nationalId, string name)
        {
            diff = 0;
            attendance_id = nationalId + " " + dayDate + " " + timeIn;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.time_attendance (person_id, national_id, time_in, dayDate, action,attendance_id) " +
                                "VALUES (@person_id, @national_id, @time_in, @dayDate, @action,@attendance_id)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@national_id", nationalId, SqlDbType.VarChar);
                    command.AddParameter("@time_in", timeIn, SqlDbType.DateTime);
                    command.AddParameter("@dayDate", dayDate, SqlDbType.Date);
                    command.AddParameter("@action", 1, SqlDbType.Int);
                    command.AddParameter("@attendance_id", attendance_id, SqlDbType.VarChar);
                    command.AddParameter("@person_id", personId, SqlDbType.VarChar);



                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        new OpenForms().openModalForm(new Welcome(name));
                        this.getAttendanceRecords();
                    }
                    else
                    {
                        Messaging.information("Log in failed!", title);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
