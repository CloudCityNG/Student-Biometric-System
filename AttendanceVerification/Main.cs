using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrFingerXLib;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using AttendanceVerification.Commons;
namespace AttendanceVerification
{
    public partial class Main : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string action = "authenticate";
        string title = "Human Resource System";
        StudentList studentList;
        TimeAttendanceData timeAttendanceData;
        public FingerprintOPFormAuth fingerprintOP;

        public Main()
        {
            InitializeComponent();
            connection = DBHelper.GetConnection();
            lblStudentCount.Text = "Number of Registered People: " + new Utilities().empCount();
        }

        //Importing necessary HDC functions
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        private void mnuPersonalDetails_Click(object sender, EventArgs e)
        {
            action = "";
            studentList = new StudentList(this, grFingerXCtrl);
            new OpenForms(this).openForm(studentList);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            grFingerXCtrl.Finalize();
            grFingerXCtrl.CapFinalize();
            this.Dispose();
            Application.Exit();
        }

        private void grFingerXCtrl_SensorPlug(object sender, AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent e)
        {
            grFingerXCtrl.CapStartCapture(e.idSensor); //start the capture on this sensor
        }

        private void grFingerXCtrl_SensorUnplug(object sender, AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent e)
        {
            grFingerXCtrl.CapStopCapture(e.idSensor);
        }

        private void grFingerXCtrl_ImageAcquired(object sender, AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent e)
        {
            System.Drawing.Image handle = null;
            IntPtr hdc = GetDC(System.IntPtr.Zero);
            grFingerXCtrl.CapRawImageToHandle(ref e.rawImage, e.width, e.height,
                                              hdc.ToInt32(), ref handle);
            //pbFingerprint.Image = handle; //put the just added image in our picture box
            //pbFingerprint.Update();

            //set the parameters in the FingerprintOPFormUSerMgt class
            fingerprintOP.rawImage.img = e.rawImage;
            fingerprintOP.rawImage.height = (int)e.height;
            fingerprintOP.rawImage.width = (int)e.width;
            fingerprintOP.rawImage.Res = e.res;

            //finally , we extract the template and try to validate de user
            fingerprintOP.extractTemplate();
            //bool matched = fingerprintOP.authenticate(comboNames.SelectedItem.ToString(), ds);
            //authenticate();

            if (action.Equals("timeAttendance"))
            {
                timeAttendanceData.onImageAcquired(handle, e.rawImage, (int)e.height, (int)e.width, e.res);//do the action related to the FormUserMgt
            }
            else
            {
                studentList.onImageAcquired(handle, e.rawImage, (int)e.height, (int)e.width, e.res);//do the action related to the FormUserMgt
            }
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            fingerprintOP = new FingerprintOPFormAuth();
            fingerprintOP.InitializeGrFinger(grFingerXCtrl);
        }

        private void mnuAttendanceRecords_Click(object sender, System.EventArgs e)
        {
            action = "timeAttendance";
            this.Hide();
            timeAttendanceData = new TimeAttendanceData(this, fingerprintOP);
            timeAttendanceData.Show();
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLayoutCascade_Click(object sender, System.EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuLayoutTile_Click(object sender, System.EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuAbout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Project Name: Student Biometric System.\nCreated By: John Mbacia", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuStaffList_Click(object sender, System.EventArgs e)
        {
            new OpenForms(this).openForm(new StudentListReport());
        }

        private void mnuTimeAttendanceReport_Click(object sender, System.EventArgs e)
        {
            new OpenForms(this).openForm(new TimeAttendanceReport());
        }
    }
}
