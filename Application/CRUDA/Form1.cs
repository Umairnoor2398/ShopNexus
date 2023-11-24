using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.tool.xml.html;
using Image = System.Drawing.Image;
using iText.IO.Image;
using CRUDA.Forms;
using CRUDA.Classes;
using CRUDA.UCs;
using System.Web.UI.Design.WebControls;

namespace CRUDA
{
    public partial class DashBoard : Form
    {


        User u= new User();

        bool studentlist;


        public DashBoard()
        {
            InitializeComponent();

        }
        public DashBoard(User u)
        {
            InitializeComponent();
            this.u = u;
        }

        //
        //private void ExportToPDF()
        //{
        //   string name = "Air Line Management System";
        //    string passsName = "Raveeha";
        //   string l = "Name of Passenger";
        //    string ticketno = "Ticket 3027";
        //    string Flight = "Qatar";
        //    string From = "Pakistan";
        //    string To = "Turkey";
        //    string Quanity = "5";
        //    string Amount = "10000";
        //    try
        //    {
        //        Document document = new Document(PageSize.A4, 20, 20, 20, 20);
        //        PdfWriter.GetInstance(document, new FileStream(passsName + " Ticket.pdf", FileMode.Create));
        //        // passenger name ()

        //        document.Open();


        //        iTextSharp.text.Font headingFont = FontFactory.GetFont("Times New Roman", 18, iTextSharp.text.Font.BOLD);

        //        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C:\\4th Smester\\airplane.png");
        //        image.ScaleToFit(60,50);
        //        float pageWidth = document.PageSize.Width;
        //        float x = (pageWidth - image.ScaledWidth) / 2;
        //        image.SetAbsolutePosition(x,800);

        //        document.Add(image);

        //        Paragraph heading = new Paragraph(name, headingFont);
        //        heading.Alignment = Element.ALIGN_CENTER;
        //        heading.SpacingBefore = 10f;
        //        heading.SpacingAfter = 10f;
                 
        //        document.Add(heading);

        //        LineSeparator line = new LineSeparator();
        //        document.Add(line);


        //        iTextSharp.text.Font headingFont2 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading2 = new Paragraph(l+" :                                                                    "+passsName , headingFont2);// raveeha
        //        heading2.Alignment = Element.ALIGN_LEFT;
        //        heading2.SpacingBefore = 10f;
        //        heading2.SpacingAfter = 10f;

        //        document.Add(heading2);



        //        iTextSharp.text.Font headingFont3 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading3 = new Paragraph("Ticket No"+ " :                                                                                    " + ticketno, headingFont3);
        //        heading3.Alignment = Element.ALIGN_LEFT;  
        //        heading3.SpacingBefore = 10f;
        //        heading3.SpacingAfter = 10f;

        //        document.Add(heading3);

        //        iTextSharp.text.Font headingFont4 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading4  = new Paragraph("Flight Type" + " :                                                                                    " + Flight, headingFont4);
        //        heading4.Alignment = Element.ALIGN_LEFT; 
        //        heading4.SpacingBefore = 10f;
        //        heading4.SpacingAfter = 10f;

        //        document.Add(heading4);


        //        iTextSharp.text.Font headingFont5 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading5 = new Paragraph("Current Location" + " :                                                                        " + From, headingFont4);
        //        heading5.Alignment = Element.ALIGN_LEFT;
        //        heading5.SpacingBefore = 10f;
        //        heading5.SpacingAfter = 10f;

        //        document.Add(heading5);

        //        iTextSharp.text.Font headingFont6 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading6 = new Paragraph("Desired Location" + " :                                                                         " + To, headingFont6);
        //        heading6.Alignment = Element.ALIGN_LEFT;  
        //        heading6.SpacingBefore = 10f;
        //        heading6.SpacingAfter = 10f;

        //        document.Add(heading6);

        //        iTextSharp.text.Font headingFont7 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading7 = new Paragraph("Amount of Passengers" + " :                                                                         " + Quanity, headingFont7);
        //        heading7.Alignment = Element.ALIGN_LEFT;
        //        heading7.SpacingBefore = 10f;
        //        heading7.SpacingAfter = 10f;

        //        document.Add(heading7);

        //        iTextSharp.text.Font headingFont8 = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD);
        //        Paragraph heading8 = new Paragraph("Biling Amount" + " :                                                                                " + Amount, headingFont7);
        //        heading8.Alignment = Element.ALIGN_LEFT;
        //        heading8.SpacingBefore = 10f;
        //        heading8.SpacingAfter = 10f;

        //        document.Add(heading8);


        //        document.Close();
        //    }
        //    catch (Exception exp) { MessageBox.Show("Fill all the columns of table (status) it can not be null"); }
        //    // Close the document
        //}



        //
        private void pParent_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadform(object form)
        {


            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pParent.Controls.Add(f);
            this.pParent.Tag = f;
            f.Show();


            //ExportToPDF();



        }
        public void loadc(object usercontrol)
        {

            UserControl f = usercontrol as UserControl;
            //f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pParent.Controls.Add(f);
            this.pParent.Tag = f;
            f.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStriplblDate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");
            toolStriplblTime.Text = DateTime.Now.ToString("hh:mm:ss:tt");



        }

        

 


        private void Form1_Load(object sender, EventArgs e)
        {
            if (u.UserRole == "")// viewer
            {
                loadc(new ViewProductViewer(u));
            }
            else if (u.UserRole == "Admin")
            {
                accountlbl.Text = u.UserName;
                op1.Text = "View Users";
                op1.Visible = true;

            }
            else if (u.UserRole == "Seller")
            {
                accountlbl.Text = u.UserName;
                op1.Text = "Add Product";
                op1.Visible = true;
            }
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pParent.Controls.Clear();
            //loadc(new StudentListControl());
        }

        private void rubricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pParent.Controls.Clear();
            //loadc(new RubricLevelC());
        }

        // public void openSL() { loadform(new StudentListForm()); }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }// In Form1


        // In Form2

    

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.pParent.Controls.Clear();
            //loadc(new StudentRC());
        }


        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rubericLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                this.pParent.Controls.Clear();
                //loadc(new AssessCompC());
            
        }

        private void assessmentComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.pParent.Controls.Clear();
            //loadc(new ViewAttendanceC());
        }

        private void Studentfromlbl_Click_1(object sender, EventArgs e)
        {
            
                this.pParent.Controls.Clear();
                loadc(new Student());
        }

        private void toolStriplblAllRight_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void op2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    

        private void account_Click(object sender, EventArgs e)
        {

            if (u.UserRole == "")// viewer
            {
                LoginForm x = new LoginForm();
                x.Show();
                this.Close();
            }
        }

        private void accountimg_Click(object sender, EventArgs e)
        {

            if (u.UserRole == "")// viewer
            {
                LoginForm x = new LoginForm();
                x.Show();
                this.Close();
            }
        }

        private void GoToAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void op1_Click_1(object sender, EventArgs e)
        {
            if (u.UserRole == "")// viewer
            {

            }
            else if (u.UserRole == "Admin")
            {
                this.pParent.Controls.Clear();
                loadc(new ViewUsersUC());
            }
            else if (u.UserRole == "Seller")
            {
                this.pParent.Controls.Clear();
                loadc(new AddProduct_UC(u, false));
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
