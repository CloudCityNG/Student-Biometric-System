using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AttendanceVerification.Commons
{
    public static class ListViewRowColors
    {
        /// <summary>
        /// Paints listview with alternating colors
        /// </summary>
        /// <param name="lv"></param>
        public static void recolorListItems(ListView lv)
        {
            for (int ix = 0; ix < lv.Items.Count; ++ix)
            {
                var item = lv.Items[ix];
                item.BackColor = (ix % 2 == 0) ? Color.AliceBlue : Color.AntiqueWhite;
                item.ForeColor = (ix % 2 == 0) ? Color.Black : Color.Black;
                item.Font = new System.Drawing.Font("Californian FB", 9, System.Drawing.FontStyle.Bold);
            }
        }

        public static void recolorselectedListItems(ListViewItem lvi)
        {
            lvi.BackColor = Color.Red;
            lvi.ForeColor = Color.White;
            lvi.Font = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
            
        }
    }
}
