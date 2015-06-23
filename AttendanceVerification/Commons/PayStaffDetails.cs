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
    class PayStaffDetails
    {
        const string title = "User Accounts";
        ProcessSalary processSalary;
        SqlConnection connection;
        SqlCommand command;
        double basicSalary;
        double taxRelief,loanBalance, totalAmountPaid;
        int loanInstallmentNo;
        ArrayList nameList = new ArrayList();
        public Dictionary<string, string[]> benefitDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> deductionDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> loanDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> affilliationDict = new Dictionary<string, string[]>();

        public PayStaffDetails(double taxRelief)
        {
            connection = DBHelper.GetConnection();
            this.taxRelief = taxRelief;
        }

        private void loadBasicSalary(string person_id)
        {
            nameList.Clear();
            try
            {
                command = connection.GetCommand("SELECT P.basic_salary FROM dbo.person_job P WHERE P.person_id=@person_id", CommandType.Text);
                command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                basicSalary = Convert.ToDouble(reader["basic_salary"]);
                            }
                            
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        private void loadPayBenefits(string person_id)
        {
            nameList.Clear();
            try
            {
                command = connection.GetCommand("SELECT b.benefit_id, b.benefit_name, sb.benefit_amount, sb.benefit_period,sb.benefit_status "+
                    "FROM dbo._benefit b, dbo.staff_benefit sb WHERE sb.benefit_id=b.benefit_id and sb.benefit_status='Active' and sb.person_id=@person_id", CommandType.Text);
                command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string[] data = new string[5];
                                nameList.Add(Convert.ToString(reader["benefit_name"]));

                                data[0] = Convert.ToString(reader["benefit_id"]);
                                data[1] = Convert.ToString(reader["benefit_name"]);
                                data[2] = Convert.ToString(reader["benefit_amount"]);
                                data[3] = Convert.ToString(reader["benefit_period"]);
                                data[4] = Convert.ToString(reader["benefit_status"]);

                                benefitDict.Add(Convert.ToString(reader["benefit_name"]),data);
                            }
                           
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        private void loadPayDeductions(string person_id)
        {
            nameList.Clear();
            try
            {
                command = connection.GetCommand("SELECT D.deduction_id,D.deduction_name, D.deduction_amount, D.deduction_period, D.period_count "+
                    "FROM dbo.other_deduction D WHERE D.deduction_status='Active' AND D.person_id=@person_id", CommandType.Text);
                command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string[] data = new string[5];
                                nameList.Add(Convert.ToString(reader["deduction_name"]));

                                data[0] = Convert.ToString(reader["deduction_id"]);
                                data[1] = Convert.ToString(reader["deduction_name"]);
                                data[2] = Convert.ToString(reader["deduction_amount"]);
                                data[3] = Convert.ToString(reader["deduction_period"]);
                                data[4] = Convert.ToString(reader["period_count"]);

                                deductionDict.Add(Convert.ToString(reader["deduction_name"]), data);
                            }
                            
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        private void loadPayLoan(string person_id)
        {
            nameList.Clear();
            try
            {
                command = connection.GetCommand("SELECT L.loan_id, F.institution_name, L.loan_name, L.loan_amount, L.repayment_amount, L.repayment_period FROM "+
                    "dbo.fainancial_institution F,DBO.staff_loan L WHERE L.institution_id=F.institution_id AND L.loan_status='Active' AND L.person_id=@person_id", CommandType.Text);
                command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string[] data = new string[6];
                                nameList.Add(String.Format("{0}({1})", Convert.ToString(reader["institution_name"]), Convert.ToString(reader["loan_name"])));

                                data[0] = Convert.ToString(reader["loan_id"]);
                                data[1] = Convert.ToString(reader["institution_name"]);
                                data[2] = Convert.ToString(reader["loan_name"]);
                                data[3] = Convert.ToString(reader["loan_amount"]);
                                data[4] = Convert.ToString(reader["repayment_amount"]);
                                data[5] = Convert.ToString(reader["repayment_period"]);

                                loanDict.Add(String.Format("{0}({1})", Convert.ToString(reader["institution_name"]), Convert.ToString(reader["loan_name"])), data);
                            }
                            
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        private void processLoan(string loan_id, double repayAmount)
        {
            try
            {
                command = connection.GetCommand("SELECT * FROM dbo.staff_loan_repayment R WHERE R.installment_no= "+
                    "(SELECT MAX(installment_no) FROM dbo.staff_loan_repayment) AND R.loan_id=@loan_id", CommandType.Text);
                command.AddParameter("@loan_id", loan_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                loanBalance = Convert.ToDouble(reader["balance"]) - repayAmount;
                                totalAmountPaid = Convert.ToDouble(reader["total_amount_paid"]) + repayAmount;
                                loanInstallmentNo = Convert.ToInt32(reader["installment_no"]) + 1;
                            }
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        private void loadPayAffilliations(string person_id)
        {
            nameList.Clear();
            try
            {
                command = connection.GetCommand("SELECT SA.affilliation_id, A.affilliation_name, SA.contribution_name, SA.contribution_amount, SA.staff_affilliation_id FROM " +
                    "dbo.affilliation A, dbo.staff_affilliation SA WHERE SA.affilliation_id=A.affilliation_id AND SA.status='Active' AND SA.person_id=@person_id", CommandType.Text);
                command.AddParameter("@person_id", person_id, SqlDbType.VarChar);
                //create the command
                using (command)
                {
                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string[] data = new string[5];
                                nameList.Add(Convert.ToString(reader["affilliation_name"]));

                                data[0] = Convert.ToString(reader["affilliation_id"]);
                                data[1] = Convert.ToString(reader["affilliation_name"]);
                                data[2] = Convert.ToString(reader["contribution_name"]);
                                data[3] = Convert.ToString(reader["contribution_amount"]);
                                data[4] = Convert.ToString(reader["staff_affilliation_id"]);

                                affilliationDict.Add(Convert.ToString(reader["affilliation_name"]), data);
                            }
                            
                        }
                        else
                        {
                            //Messaging.information("", title);
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

        public void getStaffPay(string person,string taxYear,string month)
        {
            RecordPayTransactions record = new RecordPayTransactions();
            string payId = String.Format("payid{0}{1}{2}", person, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            ArrayList benefitList = new ArrayList();
            ArrayList deductionList = new ArrayList();

            loadPayBenefits(person);
            foreach (string  name in nameList)
            {
                string[] benefits= benefitDict[name];
                benefitList.Add(benefits[2]);
                record.saveBenefitTransanction(payId, benefits[0], benefits[1], benefits[2]);
            }

            loadPayDeductions(person);
            foreach (string name in nameList)
            {
                string[] deduction = deductionDict[name];
                deductionList.Add(deduction[2]);
                record.saveDeductionTransanction(payId, deduction[0], deduction[1], deduction[2]);
            }

            loadPayAffilliations(person);
            foreach (string name in nameList)
            {
                string[] affilliation = affilliationDict[name];
                deductionList.Add(affilliation[3]);
                record. saveAffilliationTransanction(payId, affilliation[4], affilliation[3]);
            }

            loadPayLoan(person);
            foreach (string name in nameList)
            {
                string repayId =String.Format("RepayId {0}{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                string[] loans = loanDict[name];
                processLoan(loans[0],Convert.ToDouble(loans[4]));
                deductionList.Add(loans[4]);
                record.saveLoanTransanction(payId, loans[0], repayId, loans[4], Convert.ToString(loanBalance), Convert.ToString(totalAmountPaid),
                    Convert.ToString(loanInstallmentNo), DateTime.Now.ToShortDateString());
            }

            loadBasicSalary(person);
            processSalary = new ProcessSalary(benefitList, deductionList, basicSalary);

            double taxableIncome = processSalary.getTaxableIncome();
            double deductionOnIncome = processSalary.getDeductionOnIncome();
            double tax = processSalary.getTax(taxableIncome,taxRelief);
            double netSalary =taxableIncome-(deductionOnIncome+tax);

            record.saveTaxTransaction(payId, tax);
            bool flag = record.savePayTransanction(payId,taxYear,month,DateTime.Now.ToShortDateString(),person,
                Convert.ToString(basicSalary),Convert.ToString(taxableIncome),Convert.ToString(netSalary));
        }
    }
}
