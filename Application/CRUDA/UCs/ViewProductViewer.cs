using CRUDA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDA.Classes;
using System.Data.SqlClient;

namespace CRUDA.UCs
{
    public partial class ViewProductViewer : UserControl
    {
        List<ProductViewSeller> u = new List<ProductViewSeller>();// for admin to view all users login in at that time 
        User user;
        public ViewProductViewer(User user)
        {
            InitializeComponent();
            this.user = user;   
        }
        private void PopulateItemsViewer(int x)
        {


            ViewProducts[] listitems = new ViewProducts[x];
            for (int i = 0; i < x; i++)
            {

                listitems[i] = new ViewProducts(u[i],user);
                //if (flowLayoutPanel1.Controls.Count > 0) {
                //    flowLayoutPanel1.Controls.Clear();

                //}

                flowLayoutPanel1.Controls.Add(listitems[i]);

            }


        }

        private void getProductsViewer()
        {

            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand($" select p.ProductID, u.UserName, p.Name,p.Description,p.ProductCategory,p.Price,p.Quantity,p.LikesCount,p.ReviewsCount,p.Available  from Users as U join Products as p on p.AddedByUserID=u.UserID ", con2);


            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                if ( reader.GetBoolean(reader.GetOrdinal("Available"))) {
                    ProductViewSeller z = new ProductViewSeller(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), 1);
                    u.Add(z);
                }
                else {
                    ProductViewSeller z = new ProductViewSeller(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), 0);
                    u.Add(z);
                }

            }
            reader.Close();
            cmd2.ExecuteNonQuery();


        }
        private int countProductsViewer()
        {
            int x = 0;
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand($"  select count(*)  from Users as U join Products as p on p.AddedByUserID=u.UserID", con);


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                x = (reader.GetInt32(0));
            }
            reader.Close();
            cmd.ExecuteNonQuery();



            return x;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewProductViewer_Load(object sender, EventArgs e)
        {
            try
            {
                int x = countProductsViewer();
                getProductsViewer();
                PopulateItemsViewer(x);
            }
            catch (Exception ex) { }
        }
    }
}
