using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDA
{
    public partial class Student : UserControl
    {
        string first, last, registeration, email, contact;
        int id, status;
        bool update = false;
        bool check_f = false, check_l = false, check_r = false, check_e = false, check_c = false;

        public Student()
        {
            InitializeComponent();
        }
        public Student(int id, String first, String last, String registeration, String email, string contact, int status, bool update)
        {
            InitializeComponent();
            this.id = id;
            this.first = first;
            this.last = last;
            this.registeration = registeration;
            this.email = email;
            this.contact = contact;
            this.update = update;
            this.status = status;
            if (update == true)
            {
                Firsttxtbx.Text = first;
                txtLASTName.Text = last;
                txtbxRrgisteration.Text = registeration;
                txtbxEmailAddress.Text = email;
                txtbxContactNumber.Text = contact;
                if (status == 5)
                { cmbxStatus.Text = "Active"; }
                else if (status == 6)
                { cmbxStatus.Text = "InActive"; }
                btnCreateAccount.Text = "Update Student";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StudentListControl newUserControl = new StudentListControl();
            //newUserControl.Dock = DockStyle.Fill;
            //this.Parent.Controls.Add(newUserControl);
            //newUserControl.BringToFront();
            this.Hide();
        }

        private String  check() {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($" IF ( select MAX(1) FROM STUDENT WHERE RegistrationNumber = '{txtbxRrgisteration.Text}') > 0 BEGIN   SELECT '1' END ELSE BEGIN   SELECT '2' END", con);
             string X="";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X=(reader.GetString(0));
            }
            reader.Close();

            // X=cmd.ExecuteReader().GetString(0);
            cmd.ExecuteNonQuery();
            return X;


        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string y = check();
            if (check_c && check_e && check_f && check_l && check_r)
            {
                

                if (update == false && y != "1")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName,@LastName,@Contact,@Email, @RegisterationNo,@Status)", con);
                    cmd.Parameters.AddWithValue("@FirstName", (Firsttxtbx.Text));
                    cmd.Parameters.AddWithValue("@LastName", txtLASTName.Text);
                    cmd.Parameters.AddWithValue("@RegisterationNo", txtbxRrgisteration.Text);
                    cmd.Parameters.AddWithValue("@Email", txtbxEmailAddress.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtbxContactNumber.Text);
                    int id_check = 0;
                    if (cmbxStatus.Text == "Active")
                    {
                        id_check = 5;
                    }
                    else
                    {
                        id_check = 6;
                    }

                    cmd.Parameters.AddWithValue("@Status", id_check);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Student Set RegistrationNumber = @RegisterationNo, FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email= @Email WHERE Id = @ID", con);
                    cmd.Parameters.AddWithValue("@FirstName", (Firsttxtbx.Text));
                    cmd.Parameters.AddWithValue("@LastName", txtLASTName.Text);
                    cmd.Parameters.AddWithValue("@RegisterationNo", txtbxRrgisteration.Text);
                    cmd.Parameters.AddWithValue("@Email", txtbxEmailAddress.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtbxContactNumber.Text);


                    int id_check = 0;
                    if (cmbxStatus.Text == "Active")
                    {
                        id_check = 5;
                    }
                    else
                    {
                        id_check = 6;
                    }
                    cmd.Parameters.AddWithValue("@Status", id_check);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");

                }
                if (y == "1") { MessageBox.Show("Already exist"); }
            }
            else {
                if (y == "1") { MessageBox.Show("Already exist"); }
                
                MessageBox.Show("Fill the correct data first"); }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblContactNumberSignal_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Lblontact_Click(object sender, EventArgs e)
        {

        }

        private void LastNamelbl_Click(object sender, EventArgs e)
        {

        }

        private void Registerationlbl_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblEmailAddressSignal_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstNameSingal_Click(object sender, EventArgs e)
        {

        }

        private void lbllastNameSignal_Click(object sender, EventArgs e)
        {

        }

        private void lblResgSignal_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbx_Enter(object sender, EventArgs e)
        {

        }

        private void lblRecordSignal_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Firsttxtbx.Text = string.Empty;
            txtLASTName.Text = string.Empty;
            txtbxRrgisteration.Text = string.Empty;
            txtbxEmailAddress.Text = string.Empty;
            txtbxContactNumber.Text = string.Empty;
            cmbxStatus.Text = string.Empty;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Firsttxtbx_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (Firsttxtbx.Text == string.Empty)
            {// check is empty
                lblFirstNameSingal.Text = "Enter the name";
                check_f = false;
            }
            //else if (int.TryParse(Firsttxtbx.Text, out i))
            //{//Check isnumberic
            //    lblFirstNameSingal.Text = "Allowed characters: a-z, A-Z";
            //    check_f = false;
            //}
            else if (Firsttxtbx.Text.Any(ch => !char.IsLetter(ch)))

            {//check isSpecialCharactor
                lblFirstNameSingal.Text = "Allowed characters: a-z, A-Z";
                check_f = false;
            }
            else
            {//ready for storage or action
                lblFirstNameSingal.Text = " ";
                check_f = true;
            }
        }

        private void txtLASTName_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (txtLASTName.Text == string.Empty)
            {// check is empty
                lbllastNameSignal.Text = "Enter the name";
                check_l = false;
            }
            else if (int.TryParse(txtLASTName.Text, out i))
            {//Check isnumberic
                lbllastNameSignal.Text = "Allowed characters: a-z, A-Z";
                check_l = false;
            }
            else if (txtLASTName.Text.Any(ch => !char.IsLetter(ch)))
            {//check isSpecialCharactor
                lbllastNameSignal.Text = "Allowed characters: a-z, A-Z";
                check_l = false;
            }
            else
            {//ready for storage or action
                lbllastNameSignal.Text = " ";
                check_l = true;
            }
        }

        private void txtbxRrgisteration_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d{4}-[A-Za-z]+-\d+$";

            // Check if the text matches the pattern
            if (Regex.IsMatch(txtbxRrgisteration.Text, pattern))
            {
                lblResgSignal.Text = "The text is valid.";
                check_r = true;

            }
            else
            {
                lblResgSignal.Text = "The text is not valid.";
                check_r = false;
            }
            if (txtbxRrgisteration.Text == string.Empty) { check_r = false; }

        }

        private void txtbxContactNumber_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (txtbxContactNumber.Text == string.Empty)
            {// check is empty
                lblContactNumberSignal.Text = "Enter the name";
                check_c = false;
            }
            if (txtbxContactNumber.Text.Any(ch => !char.IsDigit(ch)))
            {//check isSpecialCharactor
                lblContactNumberSignal.Text = "Allowed characters: 1-9";
                check_c = false;
            }

            else

            {//ready for storage or action
                lblContactNumberSignal.Text = " ";
                check_c = false;
            }
            if (IsValidPhoneNumber(txtbxContactNumber.Text))
            {
                lblContactNumberSignal.Text = ("Phone number is valid.");

                check_c = true;
            }
            //else
            //{
            //    check_c = false;
            //    lblContactNumberSignal.Text = ("Phone number is invalid.");
            //}
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // regular expression pattern for a valid phone number
            string pattern = @"^\+\d{1,3}\d{3,}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }

        private void txtbxEmailAddress_TextChanged(object sender, EventArgs e)
        {
            check_e = IsValidEmail(txtbxEmailAddress.Text);
          
            if (check_e == false) { lblEmailAddressSignal.Text = "enter valid email !!!"; }
            else{ lblEmailAddressSignal.Text = ""; }
            if (txtbxEmailAddress.Text == string.Empty) { check_e = false; }
        }
        bool IsValidEmail(string eMail)
        {
            bool Result = true;

            try
            {
                Regex emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

                // Check if the email matches the regular expression
                Result= emailRegex.IsMatch(eMail);
                 
            }
            catch
            {
                Result = false;
            };

            return Result;
        }
    }
}
