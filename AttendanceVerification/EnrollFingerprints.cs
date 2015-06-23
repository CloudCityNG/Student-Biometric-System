using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceVerification
{
    public partial class EnrollFingerprints : Form
    {
        private FingerprintOPFormUserMgt fingerprintOP;
        string[] person;
        string action;
        StudentList studentList;
        public EnrollFingerprints(AxGrFingerXLib.AxGrFingerXCtrl grfingerxFormAuth, string[] person, StudentList studentList)
        {
            InitializeComponent();
            this.person = person;
            this.action = studentList.action;
            this.studentList = studentList;
            fingerprintOP = new FingerprintOPFormUserMgt(grfingerxFormAuth, this, txtLog, person[3]);
            displayDetails();
            fingerprintOP.function = 0;
        }

        public void onImageAcquired(Image handle, object rawImage, int height, int width, int res)
        {
            pbFingerprint.Image = handle;
            pbFingerprint.Update();

            fingerprintOP.rawImage.img = rawImage;
            fingerprintOP.rawImage.height = height;
            fingerprintOP.rawImage.width = width;
            fingerprintOP.rawImage.Res = res;

            fingerprintOP.newTemplate();
        }

        private void displayDetails()
        {
            txtLog.Text = "\r\n";
            txtLog.AppendText("   *********************************************\r\n");
            txtLog.AppendText("   Name :" + person[1] + "\r\n");
            //txtLog.AppendText("   Staff Number :" + person[1] + "\r\n");
            txtLog.AppendText("   National ID Number :" + person[0] + "\r\n");
            txtLog.AppendText("   *********************************************\r\n");
        }

        private void EnrollFingerprints_Load(object sender, EventArgs e)
        {

        }

        private void EnrollFingerprints_FormClosing(object sender, FormClosingEventArgs e)
        {
            studentList.action = "";
        }
    }
}
