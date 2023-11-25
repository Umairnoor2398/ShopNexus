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
    public partial class ViewCartUC : UserControl
    {
        List<Product> u = new List<Product>();// for admin to view all users login in at that time 
      
        int cart_id=0;
        public ViewCartUC(int cart_id)
        {
            InitializeComponent();
            this.cart_id = cart_id;
        }
        private void PopulateItems(int x)
        {
             

            CartItemUC[] listitems = new CartItemUC[x];
            for (int i = 0; i < x; i++)
            {

                listitems[i] = new CartItemUC(cart_id, u[i]);
       
                flowLayoutPanel1.Controls.Add(listitems[i]);

            }


        }

        private void getProducts()
        {

            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand($"  select p.ProductID, name, description, productCategory, price from Products as p join CartItems as c  on p.ProductID=c.ProductID where CartID={cart_id}", con2);


            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                Product z = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4));
                u.Add(z);
            }
            reader.Close();
            cmd2.ExecuteNonQuery();


        }
        private int countProducts()
        {
            int x = 0;
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand($" select count(*) from Products as p join CartItems as c  on p.ProductID=c.ProductID where CartID={cart_id}", con);


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt32(0)!=null && reader.GetInt32(0) >0){ x = reader.GetInt32(0); }
                
            }
            reader.Close();
            cmd.ExecuteNonQuery();



            return x;
        }

        private void ViewCartUC_Load(object sender, EventArgs e)
        {
            try
            {
                int x = countProducts();
                getProducts();
                PopulateItems(x);
            }
            catch (Exception ex) { }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfirmOrderBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
