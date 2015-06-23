using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttendanceVerification
{
    static class DatabaseManipulate
    {
        public static string strOrganization = "Select o.org_name Name, o.org_address Addres, "
        + "o.org_city City, o.org_country Country, o.org_email Email, "
        + "o.org_landline Landline, o.org_mobile Mobile, o.org_website Website "
        + "from _org o";

        /// <summary>
        /// Returns a DataTable, based on the command passed
        /// </summary>
        /// <param name="cmd">
        /// the SqlCommand object we wish to execute
        /// </param>
        /// <returns>
        /// a DataTable populated with the data
        /// specified in the SqlCommand object
        /// </returns>
        /// <remarks></remarks>
        public static DataTable GetDataTable(SqlCommand cmd)
        {
            // create a new DataTable
            DataTable dtGet = new DataTable();
            try
            {
                // create a new data adapter based on the specified query.
                SqlDataAdapter da = new SqlDataAdapter();
                //set the SelectCommand of the adapter
                da.SelectCommand = cmd;

                //fill the DataTable
                da.Fill(dtGet);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //return the DataTable
            return dtGet;

        }

        public static DataTable getDate()
        {
            DataTable date = new DataTable();
            date.Columns.Add("Now");
            date.Rows.Add(String.Format("Date: {0}  Time: {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));

            return date;
        }
    }
}
