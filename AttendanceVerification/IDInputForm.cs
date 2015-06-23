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
    public partial class IDInputForm : Form
    {
        TimeAttendanceData tad;
        public IDInputForm(TimeAttendanceData tad)
        {
            InitializeComponent();
            this.tad = tad;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            tad.findNationalID = txtNationalID.Text;
            tad.verify();
            if (tad.found ==1)
            {
                this.Close();
            }
        }
    }
}
