using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AttendanceVerification
{
    static class ReportHeader
    {
        static string title = "Report Header";
        public static string getReportHeader()
        {
            SqlConnection connection=DBHelper.GetConnection();
            SqlCommand command=connection.GetCommand(DatabaseManipulate.strOrganization, CommandType.Text);
            string header = "";
            try
            {
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {                           
                            while (reader.Read())
                            {
                                header = Convert.ToString(reader["Name"]);
                                header += "\nP.O. Box" + Convert.ToString(reader["Addres"]);
                                header += "\n"+Convert.ToString(reader["City"]) +", "+Convert.ToString(reader["Country"]);
                                if (!Convert.ToString(reader["Mobile"]).Equals(""))
                                {
                                    header += "\nMobile: " + Convert.ToString(reader["Mobile"]);
                                }
                                if (!Convert.ToString(reader["Landline"]).Equals(""))
                                {
                                    header += "\nLandline: " + Convert.ToString(reader["Landline"]);
                                }
                                if (!Convert.ToString(reader["Email"]).Equals(""))
                                {
                                    header += "\nEmail: " + Convert.ToString(reader["Email"]);
                                }
                                if (!Convert.ToString(reader["Website"]).Equals(""))
                                {
                                    header += "\nWebsite: " + Convert.ToString(reader["Website"]);
                                }
                                
                            }
                            reader.Close();
                        }
                        else
                        {
                            Messaging.information("No header details found!", title);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return header;
        }
    }
}
