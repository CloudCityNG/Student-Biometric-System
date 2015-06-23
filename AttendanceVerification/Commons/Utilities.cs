using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace AttendanceVerification
{
    class Utilities
    {
        SqlConnection connection;
        SqlCommand command;
        const string title = "System Utilities";
        public DataTable total ;
        public Utilities()
        {
            connection = DBHelper.GetConnection();
        }

        public int empCount()
        {
            int count = 0;
            try
            {
                command = connection.GetCommand("SELECT COUNT(*) EMP FROM dbo.person P", CommandType.Text);
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                count = Convert.ToInt32(reader["EMP"]);
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }

        public void fillReportMonthCombo(string tax_year, ComboBox cmb)
        {
            
            try
            {
                command = connection.GetCommand("SELECT M.month FROM dbo.pay_period P,dbo.pay_months M WHERE "+
                    "P.month_no=M.month_no AND P.tax_year=@tax_year", CommandType.Text);
                command.AddParameter("@tax_year", tax_year, SqlDbType.Int);
                using (command)
                {
                    cmb.Items.Clear();
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                cmb.Items.Add(Convert.ToString(reader["month"]));
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("No months found", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fillTaxYearCombo(ComboBox cmb)
        {

            try
            {
                command = connection.GetCommand("select p.tax_year from dbo.pay_parameter p", CommandType.Text);

                using (command)
                {
                    cmb.Items.Clear();
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                cmb.Items.Add(Convert.ToString(reader["tax_year"]));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
