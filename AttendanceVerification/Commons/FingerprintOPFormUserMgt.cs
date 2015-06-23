using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrFingerXLib;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace AttendanceVerification
{
    class FingerprintOPFormUserMgt
    {
        AxGrFingerXLib.AxGrFingerXCtrl grfingerx;
        private TTemplate template1,template2,template3,templateSearch;
        private int templateCounter = 0;
        public  int function = -1;
        public  TRawImage rawImage;
        private DataSet ds;
        TextBox txtLog;
        string personId;
        SqlConnection connection;
        SqlCommand command;
        string title = "Fingerprint Management";
        private EnrollFingerprints frm;
       
        public FingerprintOPFormUserMgt(AxGrFingerXLib.AxGrFingerXCtrl grfingerxFormAuth, EnrollFingerprints f,TextBox txtLog,string personId)
        {
            grfingerx = grfingerxFormAuth;
            this.txtLog = txtLog;
            this.personId = personId;
            template1      = new TTemplate();
            template2      = new TTemplate();
            template3      = new TTemplate();
            templateSearch = new TTemplate();
            frm = f;
            connection = DBHelper.GetConnection();
        }

        public void newTemplate()
        {
            if (function == 0)
                insert();
            //else
            //    if (function == 1)
            //        //search();
        }

        private TTemplate extractTemplate(TTemplate template)
        {
            int result;
            template.size = (int)GRConstants.GR_MAX_SIZE_TEMPLATE;
            result = grfingerx.Extract(ref rawImage.img, rawImage.width, rawImage.height,
                              rawImage.Res, ref template.tpt, ref template.size,
                              (int)GRConstants.GR_DEFAULT_CONTEXT);

            if (result < 0)
            {
                template.size = 0;
                template = null;
            }

            return template;
        }

        private void insert()
        {
            switch (templateCounter)
            {
                case 0:
                    template1 = extractTemplate(template1);
                    txtLog.AppendText(  "   Template 1 Extracted \r\n");
                    break;
                case 1:
                    template2 = extractTemplate(template2);
                    txtLog.AppendText( "   Template 2 Extracted\r\n");
                    break;
                case 2:
                    template3 = extractTemplate(template3);
                    txtLog.AppendText( "   Template 3 Extracted\r\n");
                    break;
            }

            templateCounter++;

            if (templateCounter == 3)
            {
                templateCounter = 0;
                function = -1;

                System.Byte[] temp1 = new System.Byte[template1.size + 1];
                System.Byte[] temp2 = new System.Byte[template1.size + 1];
                System.Byte[] temp3 = new System.Byte[template1.size + 1];

                System.Byte[] temp = new System.Byte[template1.size + 1];
                System.Array.Copy(template1.tpt, 0, temp, 0, template1.size);
                temp1 = temp;

                temp = new System.Byte[template2.size + 1];
                System.Array.Copy(template2.tpt, 0, temp, 0, template2.size);
                temp2 = temp;

                temp = new System.Byte[template3.size + 1];
                System.Array.Copy(template3.tpt, 0, temp, 0, template3.size);
                temp3 = temp;

                saveTemplates(temp1, temp2, temp3);
                frm.Close();
                
            }
        }

        //private void search()
        //{
        //    function = -1;
        //    System.Byte[] temp;
        //    int score = 0;
        //    templateSearch = extractTemplate(templateSearch); //the variable templateSearch receives the image

        //    GRConstants result = (GRConstants) grfingerx.IdentifyPrepare(ref templateSearch.tpt,
        //                                                                (int)GRConstants.GR_DEFAULT_CONTEXT);
        //    if (result < 0)
        //        return;
       
        //    currentRow = null;

        //    //linear search in the database, trying to match at least one fingerprint
        //    foreach (DBGriauleDataSet.tabelaRow rowAux in ds.tabela.Rows)
        //    {
        //        //first fingerprint test
        //        temp = rowAux.Template1;
        //        System.Array.Copy(temp, 0, template1.tpt, 0, temp.Length);
        //        template1.size = temp.Length;

        //        result = (GRConstants)grfingerx.Identify(ref template1.tpt, ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);
        //        if (result == GRConstants.GR_MATCH)
        //        {
        //            currentRow = rowAux;
        //            break;
        //        }

        //        //second fingerprint test
        //        temp = rowAux.Template2;
        //        System.Array.Copy(temp, 0, template2.tpt, 0, temp.Length);
        //        template2.size = temp.Length;

        //        result = (GRConstants)grfingerx.Identify(ref template2.tpt, ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);
        //        if (result == GRConstants.GR_MATCH)
        //        {
        //            currentRow = rowAux;
        //            break;
        //        }

        //        //third fingerprint test
        //        temp = rowAux.Template3;
        //        System.Array.Copy(temp, 0, template3.tpt, 0, temp.Length);
        //        template3.size = temp.Length;

        //        result = (GRConstants)grfingerx.Identify(ref template3.tpt, ref score, (int)GRConstants.GR_DEFAULT_CONTEXT);
        //        if (result == GRConstants.GR_MATCH)
        //        {
        //            currentRow = rowAux;
        //            break;
        //        }
        //    }
               
        //    frm.handleSearch();//the form handles the result, considering if the fingerprint was found or not
        //}

        //public int removeUser()
        //{
        //    function = -1;
        //    if (currentRow == null)
        //        return 0;

        //    currentRow.Delete();
        //    return 1;
        //}

        private void saveTemplates(System.Byte[] temp1, System.Byte[] temp2, System.Byte[] temp3)
        {
            try
            {
                //create the command 
                command = connection.GetCommand("SELECT * FROM dbo.fingerprint F WHERE F.person_id=@person_id", CommandType.Text);
                // add the parameter
                command.AddParameter("@person_id", personId, SqlDbType.VarChar);
                command.AddParameter("@template1", temp1, SqlDbType.VarBinary);
                command.AddParameter("@template2", temp2, SqlDbType.VarBinary);
                command.AddParameter("@template3", temp3, SqlDbType.VarBinary);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    if (Messaging.confirmAction("You already enrolled fingerprint! Do you want to overwrite existing ones?"))
                    {
                        command.CommandText = "UPDATE dbo.fingerprint SET "
                        + "Template1=@template1, "
                        + "Template2=@template2, "
                        + "Template3=@template3 "
                        + "WHERE person_id = @person_id";

                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Updated Fingerprint successfully!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Update failed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    reader.Close();

                    command.CommandText = "INSERT INTO dbo.fingerprint (person_id, Template1, Template2, Template3) " +
                        "VALUES (@person_id, @template1, @template2, @template3)";

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Saved Fingerprint successfully!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Saving failed!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Messaging.error(ex.ToString(), title);
            }
        }


    }
}
