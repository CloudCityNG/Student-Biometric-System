using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceVerification.Commons
{
    class OpenForms
    {
        Main parent;

        public OpenForms(Main parent)
        {
            this.parent=parent;
        }
        public OpenForms()
        {
           
        }

        public void openModalForm(Form f)
        {
            //f.ShowIcon = false;
            f.ShowInTaskbar = false;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            //f.ControlBox = false;
            //f.Text = string.Empty;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        public void openMaximisedForms(Form f)
        {
            foreach (Form childForm in parent.MdiChildren)
            {
                if (childForm == f)
                {
                    childForm.Close();
                    return;
                }
            }
            f.ShowIcon = false;
            f.ShowInTaskbar = false;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            f.ControlBox = false;
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = parent;
            f.Show();
        }

        public void openForm(Form f)
        {
            foreach (Form childForm in parent.MdiChildren)
            {
                if (childForm == f)
                {
                    childForm.Close();
                    return;
                }
            }
            //f.ShowIcon = false;
            f.ShowInTaskbar = false;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            //f.ControlBox = false;
            //f.Text = string.Empty;
            f.MdiParent = parent;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }
    }
}
