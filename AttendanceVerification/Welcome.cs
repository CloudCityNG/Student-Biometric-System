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
    public partial class Welcome : Form
    {

        public Welcome(String name)
        {
            InitializeComponent();
            lblName.Text = name;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Refresh();
            System.Threading.Thread.Sleep(3000);
            this.Close();
        }
    }
}
