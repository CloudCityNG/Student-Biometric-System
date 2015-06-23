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
    public partial class StudentList : Form
    {
        SqlCommand command;
        string[] data;
        //string connectionString = "Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=10;server=.\\SQLEXPRESS;database=organization;Integrated Security=false;User Id=school;Password=school!;";
        SqlConnection connection;
        public string action = "";
        EnrollFingerprints biometric;
        Dictionary<string, string[]> idDict = new Dictionary<string, string[]>();
        Dictionary<string, string> person_idDict = new Dictionary<string, string>();
        string title = "Staff Details";
        AxGrFingerXLib.AxGrFingerXCtrl grFingerXCtrl;
        Main parent;
        private FingerprintOPFormAuth fingerprintOP;
        public bool isOpen = false;
        public StudentList(Main parent, AxGrFingerXLib.AxGrFingerXCtrl grFingerXCtrl)
        {
            InitializeComponent();
            fingerprintOP = parent.fingerprintOP;
            connection = DBHelper.GetConnection();
            this.parent = parent;
            this.grFingerXCtrl = grFingerXCtrl;
            label1.Enabled = false;
            cmdViewStaffDetails.Enabled = false;
            cmdEnrollFingerprintBiometrics.Enabled = false;
        }


        private void StaffList_Load(object sender, EventArgs e)
        {
            searchPerson("");

            cmdViewStaffDetails.Enabled = false;
        }

        public void searchPerson(string id)
        {
            if ( !id.Equals(""))
            {
                if(optSearchIDname.Checked)
                {
                    command = connection.GetCommand("SELECT * FROM dbo.person WHERE national_id = @_id", CommandType.Text);
                    command.AddParameter("@_id", id, SqlDbType.VarChar);
                }else if(optSearchStaffNumber.Checked)
                {
                    command = connection.GetCommand("Select * from dbo.person p, dbo.person_job pj "+
                        "where p.person_id=pj.person_id and pj.staff_no = @_id", CommandType.Text);
                    command.AddParameter("@_id", id, SqlDbType.VarChar);
                }
            }
            else
            {
                //create the command
                command = connection.GetCommand("SELECT * FROM dbo.person order by surname asc", CommandType.Text);
            }

            
            using (command)
            {

                // initialize the reader and execute the command 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int i = 0;
                        lstvStaffDetails.Items.Clear();
                        idDict.Clear();
                        person_idDict.Clear();
                        while (reader.Read())
                        {
                            // Create a ListViewItem object for evey item that you wish to add the ListView.
                            string[] lv = new String[4];

                            lv[0] = Convert.ToString(i+1);//Convert.ToString(reader["designation"]);
                            lv[1] = Convert.ToString(reader["national_id"]);
                            lv[2] = Convert.ToString(reader["surname"]) + " " + Convert.ToString(reader["first_name"])
                                + " " + Convert.ToString(reader["other_name"]);
                            lv[3] = Convert.ToString(reader["person_id"]);
                            //lv[3] = Convert.ToString(reader["designation"]);

                            lstvStaffDetails.Items.Add(new ListViewItem(lv, i));;
                            idDict.Add(Convert.ToString(reader["national_id"]), lv);
                            person_idDict.Add(Convert.ToString(reader["national_id"]), Convert.ToString(reader["person_id"]));
                            i++;
                        }
                        reader.Close();

                        ListViewRowColors.recolorListItems(lstvStaffDetails);
                    }
                    else
                    {
                        Messaging.information("No staff details found!", title);
                    }
                }
            }
        }

        private void optSearchIDname_CheckedChanged(object sender, EventArgs e)
        {
            if(optSearchIDname.Checked){
                optSearchStaffNumber.Checked=false;
                label1.Enabled = true;
                txtSearch.Enabled = true;
                btnRefresh.Enabled = true;
            }
            else if (!optSearchIDname.Checked && !optSearchStaffNumber.Checked)
            {
                label1.Enabled = false;
                txtSearch.Enabled = false;
                btnRefresh.Enabled = false;
            }
        }

        private void optSearchStaffNumber_CheckedChanged(object sender, EventArgs e)
        {
            if(optSearchStaffNumber.Checked){
                optSearchIDname.Checked=false;
                label1.Enabled = true;
                txtSearch.Enabled = true;
                btnRefresh.Enabled = true;
            }
            else if (!optSearchIDname.Checked && !optSearchStaffNumber.Checked)
            {
                label1.Enabled = false;
                txtSearch.Enabled = false;
                btnRefresh.Enabled = false;
            }
        }

        private void lstvStaffDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int j = lstvStaffDetails.SelectedIndices.Count;
            if (j > 0)
            {
                string[] data = new string[2];
                ListViewItem lvi = lstvStaffDetails.Items[lstvStaffDetails.SelectedIndices[0]];
                
                data[0] = lvi.SubItems[1].Text;
                data[1] = lvi.SubItems[2].Text;

                PersonalDetails details = new PersonalDetails(parent, this);
                details.searchPerson(data[0]);
                new OpenForms(parent).openModalForm(details);
            }
            else
            {
                Messaging.warning("You must select person name in the list to proceed", title);
            }
        }

        private void cmdViewStaffDetails_Click(object sender, EventArgs e)
        {
            int j = lstvStaffDetails.SelectedIndices.Count;
            if (j > 0)
            {
                string[] data = new string[2];
                ListViewItem lvi = lstvStaffDetails.Items[lstvStaffDetails.SelectedIndices[0]];
                
                data[0] = lvi.SubItems[1].Text;
                data[1] = lvi.SubItems[2].Text;

                PersonalDetails details = new PersonalDetails(parent, this);
                details.searchPerson(data[0]);
                new OpenForms(parent).openModalForm(details);
            }
            else
            {
                Messaging.warning("You must select person name in the list to proceed", title);
            }
        }

        private void lstvStaffDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = lstvStaffDetails.SelectedIndices.Count;
            if (j > 0)
            {
                cmdViewStaffDetails.Enabled = true;
                cmdEnrollFingerprintBiometrics.Enabled = true;
                string[] data = new string[2];
                ListViewItem lvi = lstvStaffDetails.Items[lstvStaffDetails.SelectedIndices[0]];
                ListViewRowColors.recolorselectedListItems(lvi);
                data[0] = lvi.SubItems[1].Text;
                data[1] = lvi.SubItems[2].Text;
                string[] person = idDict[data[0]];
                
                
                this.data = person;
            }
            else
            {
                ListViewRowColors.recolorListItems(lstvStaffDetails);
                cmdViewStaffDetails.Enabled = false;
                cmdEnrollFingerprintBiometrics.Enabled = false;
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchPerson(txtSearch.Text);
        }

        private void mnuNewStaff_Click(object sender, EventArgs e)
        {
            new OpenForms(parent).openModalForm(new PersonalDetails(parent,this));
        }

       

        public void onImageAcquired(Image handle, object rawImage, int height, int width, int res)
        {
            if (action.Equals("ENROLL"))
            {
                biometric.onImageAcquired(handle, rawImage, height, width, res);
            }
            else
            {
                if (!this.isOpen)
                {
                    //set the parameters in the FingerprintOPFormUSerMgt class
                    fingerprintOP.rawImage.img = rawImage;
                    fingerprintOP.rawImage.height = height;
                    fingerprintOP.rawImage.width = width;
                    fingerprintOP.rawImage.Res = res;

                    //finally , we extract the template and try to validate de user
                    fingerprintOP.extractTemplate();

                    identify();
                }
            }
        }

        private void cmdEnrollFingerprintBiometrics_Click(object sender, EventArgs e)
        {
            int j = lstvStaffDetails.SelectedIndices.Count;
            if (j > 0)
            {
                action = "ENROLL";
                biometric = new EnrollFingerprints(grFingerXCtrl, data, this);
                new OpenForms().openModalForm(biometric);
            }
            else
            {
                Messaging.warning("You must select person name in the list to proceed", title);
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
                    isOpen = true;
                    PersonalDetails details = new PersonalDetails(parent, this);
                    details.searchPerson(nationalId);
                    new OpenForms(parent).openModalForm(details); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
