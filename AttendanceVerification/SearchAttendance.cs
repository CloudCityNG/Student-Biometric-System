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
    public partial class SearchAttendance : Form
    {
        TimeAttendanceData thisParent;
        public SearchAttendance(TimeAttendanceData thisParent)
        {
            InitializeComponent();
            this.Parent = Parent;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
