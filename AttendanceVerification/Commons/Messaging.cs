using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
//using HR.Messaging;

namespace AttendanceVerification
{
    public static class Messaging
    {
     
        /// <summary>
        /// Displays confirm dialog
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool confirmAction(string message)
        {
            DialogResult dr = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool retValue = false;
            if (dr == DialogResult.Yes)
            {
                retValue = true;
            }

            return retValue;
        }

        /// <summary>
        /// Displays warning message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void warning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Displays error dialog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void error(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays information dialog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void information(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
