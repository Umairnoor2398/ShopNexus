﻿using CRUDA.Classes;
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

namespace CRUDA.UCs
{
    public partial class loginUC : UserControl
    {
        User u;
        public loginUC()
        {
            InitializeComponent();
        }

        private void cmbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEmailAddressSignal_Click(object sender, EventArgs e)
        {

        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {

        }

        private void lblContactNumberSignal_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbxEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbxContactNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lblontact_Click(object sender, EventArgs e)
        {

        }

        private void Firsttxtbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstNameSingal_Click(object sender, EventArgs e)
        {

        }

        private void txtLASTName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastNamelbl_Click(object sender, EventArgs e)
        {

        }

        private void lbllastNameSignal_Click(object sender, EventArgs e)
        {

        }

        private void txtbxRrgisteration_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registerationlbl_Click(object sender, EventArgs e)
        {

        }

        private void lblResgSignal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
            var con = Configuration.getInstance().getConnection();
            
            SqlCommand cmd = new SqlCommand($"SELECT MAX(1) FROM USERS WHERE Email = @Email AND Password = @Password;", con);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPasswoed.Text);
            int X = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetInt32(0));
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            
            if (X == 1)
            {
                MessageBox.Show("User Login Successfully");
                var con2 = Configuration.getInstance().getConnection();
              
                SqlCommand cmd2 = new SqlCommand($"SELECT * FROM USERS WHERE Email = @Email AND Password = @Password;", con2);
                cmd2.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd2.Parameters.AddWithValue("@Password", txtPasswoed.Text);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    u = new User( (reader2.GetInt32(0)), reader2.GetString(1), reader2.GetString(2), reader2.GetString(3), reader2.GetString(4), reader2.GetString(5), reader2.GetString(6), reader2.GetString(7), reader2.GetString(8));
                }
                reader2.Close();
                cmd2.ExecuteNonQuery();
             

                Form x = new DashBoard(u);
                x.Show();
                this.Hide();
              //  string userName,string Password, string firstName, string lastName, string email, string gender, string contact, string userRole
            }

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtPasswoed.Text= string.Empty;
        }

        private void lblRecordSignal_Click(object sender, EventArgs e)
        {

        }

        private void gbx_Enter(object sender, EventArgs e)
        {

        }

        private void account_Click(object sender, EventArgs e)
        {

        }
    }
}
