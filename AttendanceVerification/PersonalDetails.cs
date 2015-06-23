using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using AttendanceVerification.Commons;
using System.IO;

namespace AttendanceVerification
{
    public partial class PersonalDetails : Form
    {
        Main parent;
        bool isNew;
        SqlCommand command;
        string imagePath = "";
        string firstName, surname, otherName, gender, nationalId, maritalStatus, nationality,
            country, city, address, email, mobile, landline, personId;
        DateTime dob;
        Image photo;
        StudentList studentList;
        //string connectionString = "Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=10;server=.\\SQLEXPRESS;database=organization;Integrated Security=false;User Id=school;Password=school!;";
        SqlConnection connection;

        string title = "Staff Details";

        public PersonalDetails(Main parent, StudentList staffList)
        {
            InitializeComponent();
            this.parent = parent;
            connection = DBHelper.GetConnection();
            this.isNew = true;
            staffList.isOpen = true;
            this.studentList = staffList;
            cmdDelete.Enabled = false;
            cmdUpdate.Enabled = false;
            //searchPerson("");

            //fillSearchByCombo();
            fillGenderCombo();
            fillMaritalStatusCombo();
        }

        private void cmdClearControls_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            save();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            delete(txtNationalId.Text);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void fillFields(string[] person)
        {
            getImage(person[1]);
            personId = person[0];
            txtNationalId.Text = person[1];
            txtSurname.Text = person[2];
            txtFirstName.Text = person[3];
            txtOtherNames.Text = person[4];
            txtAddress.Text = person[5];
            txtCity.Text = person[6];
            txtCountry.Text = person[7];
            txtEmail.Text = person[8];
            txtLandline.Text = person[9];
            txtMobile.Text = person[10];
            txtNationality.Text = person[11];
            //txtPostalCode.Text = Convert.ToString(reader["postal_code"]);
            cmbGender.Text = person[12];
            cmbMaritalStatus.Text = person[13];

            cmdUpdate.Enabled = true;
            cmdDelete.Enabled = true;
            cmdSave.Enabled = false;
            isNew = false;
        }

        private void fillGenderCombo()
        {
            this.cmbGender.Items.Add("   - Gender -");
            this.cmbGender.Items.Add("Female");
            this.cmbGender.Items.Add("Male");
        }

        private void fillMaritalStatusCombo()
        {
            this.cmbMaritalStatus.Items.Add("   - Marital Status -");
            this.cmbMaritalStatus.Items.Add("Single");
            this.cmbMaritalStatus.Items.Add("Married");
            this.cmbMaritalStatus.Items.Add("Widowed");
            this.cmbMaritalStatus.Items.Add("In a relationship");
            this.cmbMaritalStatus.Items.Add("Other");
        }

        private void clearControls()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLandline.Text = "";
            txtMobile.Text = "";
            txtNationalId.Text = "";
            txtNationality.Text = "";
            txtOtherNames.Text = "";
            //txtPostalCode.Text = "";
            txtSurname.Text = "";
            cmbGender.SelectedIndex = 0;
            cmbMaritalStatus.SelectedIndex = 0;
            // dtpDob.Text = DataFormat.DateToDisp(new DateTime().ToShortDateString());
            //lstvStaffDetails.=-1;

            cmdSave.Enabled = true;
            cmdUpdate.Enabled = false;
            cmdDelete.Enabled = false;
            isNew = true;
        }


        private bool getTextFieldValues()
        {
            bool flag = true;

            if (txtSurname.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your surname!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
            }
            else if (txtFirstName.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your first name!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
            }
            else if (txtNationalId.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your national ID number!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalId.Focus();
            }
            else if (cmbGender.Text.Equals("   - Gender -"))
            {
                flag = false;
                MessageBox.Show("Pliz select your gender!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }
            else if (cmbMaritalStatus.Text.Equals("   - Marital Status -"))
            {
                flag = false;
                MessageBox.Show("Pliz select your marital Status!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaritalStatus.Focus();
            }
            else if (txtNationality.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your nationality!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationality.Focus();
            }
            else if (txtCountry.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your residence country!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
            }
            else if (txtCity.Text.Equals(""))
            {
                flag = false;
                MessageBox.Show("Pliz enter your residence city!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
            }
            else
            {
                surname = txtSurname.Text;
                firstName = txtFirstName.Text;
                otherName = txtOtherNames.Text;
                nationalId = txtNationalId.Text;
                gender = cmbGender.Text;
                dob = Convert.ToDateTime(dtpDob.Value.ToShortDateString());
                maritalStatus = cmbMaritalStatus.Text;
                nationality = txtNationality.Text;
                country = txtCountry.Text;
                city = txtCity.Text;
                address = txtAddress.Text;
                //postalCode = txtPostalCode.Text;
                email = txtEmail.Text;
                mobile = txtMobile.Text;
                landline = txtLandline.Text;
                imagePath = txtPath.Text;
                photo = pbImage.Image;

                if (isNew)
                {
                    personId = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + "/" + nationalId;
                }

            }

            return flag;
        }


        public void searchPerson(string id)
        {
            command = connection.GetCommand("SELECT * FROM dbo.person WHERE national_id = @_id", CommandType.Text);
            command.AddParameter("@_id", id, SqlDbType.VarChar);
            using (command)
            {

                // initialize the reader and execute the command 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        string[] person = new string[14];
                        while (reader.Read())
                        {
                            person[0] = Convert.ToString(reader["person_id"]);
                            person[1] = Convert.ToString(reader["national_id"]);
                            person[2] = Convert.ToString(reader["surname"]);
                            person[3] = Convert.ToString(reader["first_name"]);
                            person[4] = Convert.ToString(reader["other_name"]);
                            person[5] = Convert.ToString(reader["address"]);
                            person[6] = Convert.ToString(reader["city"]);
                            person[7] = Convert.ToString(reader["country"]);
                            person[8] = Convert.ToString(reader["email"]);
                            person[9] = Convert.ToString(reader["landline"]);
                            person[10] = Convert.ToString(reader["mobile"]);
                            person[11] = Convert.ToString(reader["nationality"]);
                            //txtPostalCode.Text = Convert.ToString(reader["postal_code"]);
                            person[12] = Convert.ToString(reader["gender"]);
                            person[13] = Convert.ToString(reader["marital_status"]);
                        }
                        reader.Close();
                        fillFields(person);
                        //ListViewRowColors.recolorListItems(lstvStaffDetails);
                    }
                    else
                    {
                        Messaging.information("No staff details found!", title);
                    }
                }
            }
        }

        private void savePhoto()
        {
            try
            {

                if (!txtPath.Text.Equals(""))
                {
                    //Read Image Bytes into a byte array
                    byte[] imageData = imageData = ReadFile(txtPath.Text);

                    command = connection.GetCommand("SELECT person_id = @personId FROM dbo.person_photo WHERE person_id = @personId", CommandType.Text);
                    // add the parameter
                    command.AddParameter("@personId", personId, SqlDbType.VarChar);
                    command.AddParameter("@photo", imageData, SqlDbType.Image);

                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        command.CommandText = "INSERT INTO dbo.person_photo (person_id,photo) " +
                            "VALUES (@personId, @photo)";
                        int i = command.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        command.CommandText = "UPDATE dbo.person_photo SET " +
                            "photo=@photo " +
                            "WHERE person_id=@personId";
                        int i = command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Messaging.error("Error! Failed to save photo!\n" + ex.ToString(), title);
            }
        }


        private void save()
        {
            string msg = "";
            try
            {
                if (getTextFieldValues() == true)
                {
                    //create the command    
                    using (command = connection.GetCommand("SELECT national_id = @national_id FROM dbo.person WHERE national_id = @national_id", CommandType.Text))
                    {
                        // add the parameter
                        command.AddParameter("@personId", personId, SqlDbType.VarChar);
                        command.AddParameter("@surname", surname, SqlDbType.VarChar);
                        command.AddParameter("@first_name", firstName, SqlDbType.VarChar);
                        command.AddParameter("@other_name", otherName, SqlDbType.VarChar);
                        command.AddParameter("@national_id", nationalId, SqlDbType.VarChar);
                        command.AddParameter("@gender", gender, SqlDbType.VarChar);
                        command.AddParameter("@dob", dob, SqlDbType.Date);
                        command.AddParameter("@marital_status", maritalStatus, SqlDbType.VarChar);
                        command.AddParameter("@nationality", nationality, SqlDbType.VarChar);
                        command.AddParameter("@country", country, SqlDbType.VarChar);
                        command.AddParameter("@city", city, SqlDbType.VarChar);
                        command.AddParameter("@address", address, SqlDbType.VarChar);
                        command.AddParameter("@path", imagePath, SqlDbType.VarChar);
                        command.AddParameter("@email", email, SqlDbType.VarChar);
                        command.AddParameter("@mobile", mobile, SqlDbType.VarChar);
                        command.AddParameter("@landline", landline, SqlDbType.VarChar);


                        // initialize the reader and execute the command 
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (isNew)
                            {
                                if (!reader.HasRows)
                                {
                                    msg = "Saving";

                                    command.CommandText = "INSERT INTO dbo.person (person_id, surname, first_name, other_name, " +
                                        "national_id, gender, dob, marital_status, nationality, country, city, address, " +
                                        "email,mobile,landline) " +
                                        "VALUES (@personId, @surname, @first_name, @other_name, @national_id, @gender, @dob, " +
                                        "@marital_status, @nationality, @country,@city,@address,@email, @mobile, " +
                                        "@landline)";

                                    reader.Close();

                                    int i = command.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        Messaging.information(msg + " successfully!", title);
                                        clearControls();
                                    }
                                }
                            }
                            else
                            {
                                msg = "Updating";
                                reader.Close();

                                command.CommandText = "UPDATE dbo.person SET " +
                                    "surname= @surname," +
                                    "first_name = @first_name, " +
                                    "other_name= @other_name," +
                                    "national_id= @national_id," +
                                    "gender= @gender," +
                                    "dob= @dob," +
                                    "marital_status= @marital_status," +
                                    "nationality= @nationality," +
                                    "country= @country," +
                                    "city= @city," +
                                    "address= @address," +
                                    "email= @email," +
                                    "mobile= @mobile," +
                                    "landline= @landline " +
                                    "WHERE person_id = @personId";

                                int i = command.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    Messaging.information(msg + " successfully!", title);
                                }
                            }
                        }

                        savePhoto();
                        studentList.searchPerson("");
                    }
                }

            }
            catch (Exception ex)
            {
                Messaging.error("Error! " + msg + " Failed!\n" + ex.ToString(), title);
            }
        }

        protected void LoadImage()
        {
            try
            {
                OpenFileDialog openFileDia = new OpenFileDialog();
                if (openFileDia.ShowDialog() == DialogResult.OK)
                {
                    this.photo = Image.FromFile(openFileDia.FileName);
                    this.setPicBoxImage();
                    txtPath.Text = openFileDia.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setPicBoxImage()
        {
            this.pbImage.Image = resizeImage(photo);
            if (photo.Height < pbImage.Height && photo.Width < pbImage.Width)
            {
                this.pbImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {

            }
        }

        private Image resizeImage(Image imgToResize)
        {
            int destWidth = pbImage.Width;
            int destHeight = pbImage.Height;
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        //Open file in to a filestream and read data in a byte array.
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void delete(string id)
        {
            try
            {
                command = connection.GetCommand("SELECT * FROM dbo.person WHERE national_id = @national_id", CommandType.Text);
                //create the command
                command.AddParameter("@national_id", id, SqlDbType.VarChar);
                using (command)
                {

                    // initialize the reader and execute the command 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Close();
                            command.CommandText = "DELETE FROM dbo.person WHERE national_id = @national_id";

                            int i = command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                searchPerson("");
                                Messaging.information("Deleted successfully!", title);
                                clearControls();
                            }

                        }
                        else
                        {
                            Messaging.warning("No staff details found!", title);

                        }
                    }
                    studentList.searchPerson("");
                }
            }
            catch (Exception ex)
            {
                Messaging.error("Error! Failed deleting!\n" + ex.ToString(), title);
            }
        }

        public void getImage(string id)
        {
            //create the command
            command = connection.GetCommand("select pp.photo from dbo.person_photo pp,dbo.person p " +
                "where pp.person_id=p.person_id and p.national_id= @_id", CommandType.Text);
            command.AddParameter("@_id", id, SqlDbType.VarChar);

            using (command)
            {

                // initialize the reader and execute the command 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            try
                            {
                                //Get image data from gridview column.
                                byte[] imageData = (byte[])reader["photo"];

                                //Initialize image variable
                                Image newImage;
                                //Read image data into a memory stream
                                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                                {
                                    ms.Write(imageData, 0, imageData.Length);

                                    //Set image variable value using memory stream.
                                    newImage = Image.FromStream(ms, true);
                                    this.photo = newImage;
                                }

                                //set picture
                                //pbImage.Image = newImage;

                                this.setPicBoxImage();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        reader.Close();
                    }
                    else
                    {
                        //Messaging.information("No staff details found!", title);
                    }
                }
            }
        }

        private void PersonalDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            studentList.isOpen = false;
        }
    }
}
