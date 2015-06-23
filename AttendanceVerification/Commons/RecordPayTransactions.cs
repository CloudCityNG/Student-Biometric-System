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
    class RecordPayTransactions
    {
        SqlConnection connection;
        SqlCommand command;
        const string title = "Payroll";

        public RecordPayTransactions()
        {
            connection = DBHelper.GetConnection();
        }

        public bool saveBenefitTransanction(string pay_id, string benefit_id, string benefit_name, string benefit_amount)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.salaried_pay_benefit (pay_id, benefit_id,benefit_name, benefit_amount) " +
                "values(@pay_id, @benefit_id, @benefit_name, @benefit_amount)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@benefit_id", benefit_id, SqlDbType.VarChar);
                    command.AddParameter("@benefit_name", benefit_name, SqlDbType.VarChar);
                    command.AddParameter("@benefit_amount", benefit_amount, SqlDbType.Money);

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        public bool saveTaxTransaction(string pay_id, double tax)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.pay_tax (pay_id, amount) " +
                "values(@pay_id, @tax)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@tax", tax, SqlDbType.VarChar);

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        public bool saveDeductionTransanction(string pay_id, string deduction_id, string deduction_name, string deduction_amount)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.salaried_pay_deductions(pay_id, deduction_id,deduction_name, deduction_amount) " +
                "values(@pay_id, @deduction_id, @deduction_name, @deduction_amount)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@deduction_id", deduction_id, SqlDbType.VarChar);
                    command.AddParameter("@deduction_name", deduction_name, SqlDbType.VarChar);
                    command.AddParameter("@deduction_amount", deduction_amount, SqlDbType.Money);

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        public bool saveLoanTransanction(string pay_id, string loan_id, string repayment_id, string amount_paid, string balance,
        string total_amount_paid, string installment_no, string repay_date)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.staff_loan_repayment(pay_id, loan_id, repayment_id,amount_paid, balance, " +
                "total_amount_paid,installment_no,repay_date) values(@pay_id, @loan_id, @repayment_id, @amount_paid, @balance, @total_amount_paid, " +
                "@installment_no, @repay_date)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@loan_id", loan_id, SqlDbType.VarChar);
                    command.AddParameter("@repayment_id", repayment_id, SqlDbType.VarChar);
                    command.AddParameter("@amount_paid", amount_paid, SqlDbType.Money);
                    command.AddParameter("@balance", balance, SqlDbType.Money);
                    command.AddParameter("@total_amount_paid", total_amount_paid, SqlDbType.Money);
                    command.AddParameter("@installment_no", installment_no, SqlDbType.Int);
                    command.AddParameter("@repay_date", repay_date, SqlDbType.Date);

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        public bool saveAffilliationTransanction(string pay_id, string staff_affilliation_id, string contribution_amount)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("insert into dbo.affilliation_payment (staff_affilliation_id, pay_id, " +
                "contribution_amount) values (@staff_affilliation_id, @pay_id, @contribution_amount)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@staff_affilliation_id", staff_affilliation_id, SqlDbType.VarChar);
                    command.AddParameter("@contribution_amount", contribution_amount, SqlDbType.Money);
                    
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        public bool savePayTransanction(string pay_id, string tax_year, string month, string pay_date, string person_id,
        string basic_salary, string gross_salary, string net_salary)
        {
            bool flag = false;
            try
            {
                //create the command    
                using (command = connection.GetCommand("INSERT INTO dbo.salaried_pay_person(pay_id, tax_year, month, pay_date, person_id, " +
                "basic_salary,gross_salary,net_salary) values(@pay_id, @tax_year, @month, @pay_date, @person_id, @basic_salary, " +
                "@gross_salary, @net_salary)", CommandType.Text))
                {
                    // add the parameter
                    command.AddParameter("@pay_id", pay_id, SqlDbType.VarChar);
                    command.AddParameter("@tax_year", tax_year, SqlDbType.VarChar);
                    command.AddParameter("@month", month, SqlDbType.VarChar);
                    command.AddParameter("@pay_date", pay_date, SqlDbType.Date);
                    command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                    command.AddParameter("@basic_salary", basic_salary, SqlDbType.Money);
                    command.AddParameter("@gross_salary", gross_salary, SqlDbType.Money);
                    command.AddParameter("@net_salary", net_salary, SqlDbType.Money);

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }
    }
}
