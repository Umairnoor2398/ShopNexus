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
using CRUDA.Classes;
namespace CRUDA.UCs
{
    public partial class ViewProducts : UserControl
    {
        ProductViewSeller u;
        User user;
        int availablitycheck=0;
        public ViewProducts(ProductViewSeller u, User user)
        {
            InitializeComponent();
            this.u = u;
            this.user = user;   
            ProductName_lbl.Text = u.Name;
            likes_lbl.Text = u.LikesCount.ToString();
            review_lbl.Text = u.ReviewsCount.ToString();
            description_lbl.Text = u.Description;

            availablitycheck = u.Available;
            if (availablitycheck == 1)
            {
                avalaibilityImg.Image = CRUDA.Properties.Resources.icons8_checked_20;
            }
            else {
                avalaibilityImg.Image = CRUDA.Properties.Resources.icons8_no_20;

            }

            sellerName_lbl.Text = u.Seller;
            category_lbl.Text = u.ProductCategory;
            price_lbl.Text = u.Price.ToString()+" PKR";


        }

        private void pictureProduct_Click(object sender, EventArgs e)
        {

        }

        private void Cart_Btn_Click(object sender, EventArgs e)
        {
            if (user.UserRole == "") {
                MessageBox.Show("Login In First To Do the Action");
            
            }
        }

        private void cart_btn2_Click(object sender, EventArgs e)
        {
            if (user.UserRole == "")
            {
                MessageBox.Show("Login In First To Do the Action");

            }
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            ProductName_lbl.Text = u.Name;
            likes_lbl.Text = u.LikesCount.ToString();
            review_lbl.Text = u.ReviewsCount.ToString();
            description_lbl.Text = u.Description;

            availablitycheck = u.Available;
            if (availablitycheck == 1)
            {
                avalaibilityImg.Image = CRUDA.Properties.Resources.icons8_checked_20;
            }
            else
            {
                avalaibilityImg.Image = CRUDA.Properties.Resources.icons8_no_20;

            }

            sellerName_lbl.Text = u.Seller;
            category_lbl.Text = u.ProductCategory;
            price_lbl.Text = u.Price.ToString() + " PKR";



            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand($" select Product_Img  from ProductsImg where ProductID = @ProductID", con2);
            cmd2.Parameters.AddWithValue("@ProductID",u.ProductID);

            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                string z = (reader.GetString(0));
                pictureProduct.ImageLocation = z;
            }
            reader.Close();
            cmd2.ExecuteNonQuery();

        }
    }
}
