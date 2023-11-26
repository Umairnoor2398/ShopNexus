using CRUDA.Classes;
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
using CRUDA.Forms;
namespace CRUDA.UCs
{
    public partial class MessagesUC : UserControl
    {
        User u = new User();
        int id1;
        int id2;
        string Role = "";
        public MessagesUC(int id1, User u)
        {
            InitializeComponent();
            this.id1 = id1;
            this.u= u;
        }
        public MessagesUC(string Role)
        {
            InitializeComponent();
            this.Role = Role;   
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void refresh()
        {
            dataGridView1.Controls.Clear();
            dataGridView1.Columns.Clear();


        }
        private void view()
        {
            try
            {
                dataGridView1.DataSource = null;
                var con2 = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand($"select * from Communications where sender={id1}", con2);
           
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                dataGridView1.DataSource = dt2;
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;

            }catch (Exception ex) { }

        }
        private void view2()
        {
            try
            {
                dataGridView1.DataSource = null;
                var con3 = Configuration.getInstance().getConnection();
                SqlCommand cmd3 = new SqlCommand($"select * from Communications", con3);

                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;

            }
            catch (Exception ex) { }

        }
        private void DataBind()
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Message";
            Update.Text = "Message";
            Update.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(Update);


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.ColumnIndex;
            if (index == 5)
            {
                Form x = new MessageForm(id1, id2);
                x.ShowDialog();
    

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                id2 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());


                MessageBox.Show("You have Selected Seller  of Seller ID = " + id2.ToString());
            }
            catch (Exception ex) { }
        }

        private void MessagesUC_Load(object sender, EventArgs e)
        {
            
            
            if (Role == "Admin")
            {
                refresh();
                view2();
               
            }
            else {
                refresh();
                view();
                DataBind();
            }
         
        }
    }
}
