using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CRUDA.UCs
{
    public partial class SignupUC : UserControl
    {
        string first, last, registeration, email, contact;
        int id, status;

        private void btnClear_Click(object sender, EventArgs e)
        {
            Firsttxtbx.Text = string.Empty;
            txtLASTName.Text = string.Empty;
            txtbxusername.Text = string.Empty;
            txtbxEmailAddress.Text = string.Empty;
            txtbxContactNumber.Text = string.Empty;
            cmbxGender.Text = string.Empty;
            cmbxRole.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        bool update = false;
        bool check_f = false, check_l = false, check_r = false, check_e = false, check_c = false;
        public SignupUC()
        {
            InitializeComponent();
        }
        private int check()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($"  select count(*) FROM users WHERE email = '{txtbxEmailAddress.Text}' ", con);
            int X = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetInt32(0));
            }
            reader.Close();

            // X=cmd.ExecuteReader().GetString(0);
            cmd.ExecuteNonQuery();
            return X;


        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            int y = check();
            if (/*check_c && check_e && check_f && check_l && check_r*/0<1)
            {


                if (update == false && y!=1  )
                {
                    var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Users values (@UserName,@Password,@FirstName,@LastName,@Email,@Gender,@Contact,@UserRoles)", con);
                cmd.Parameters.AddWithValue("@FirstName", (Firsttxtbx.Text));
                cmd.Parameters.AddWithValue("@LastName", txtLASTName.Text);
                cmd.Parameters.AddWithValue("@UserName", txtbxusername.Text);
                cmd.Parameters.AddWithValue("@Email", txtbxEmailAddress.Text);
                cmd.Parameters.AddWithValue("@Contact", txtbxContactNumber.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbxGender.Text);     
                cmd.Parameters.AddWithValue("@UserRoles", cmbxRole.Text);
                cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
            }

            if (y == 1) { MessageBox.Show("Already exist"); }
            }
            else
            {
                if (y == 1) { MessageBox.Show("Already exist"); }

                MessageBox.Show("Fill the correct data first");
            }
        }
    }
}
