using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ye.DAL;
using ye.Model;

namespace ye
{
    public partial class main : Form
    {
        Widget widget;
        Menu_Coffee menu = new Menu_Coffee();
        private List<string> imagePaths = new List<string>();
        private List<Payment> paymentList = new List<Payment>();

        private int currentIndex = 0;
        Color mycolor = Color.FromArgb(255, 217, 195);

        public main()
        {
            InitializeComponent();
            widget = new Widget();
            widget.Wdg_MonAnAdded += OnWdg_MonAnAdded_MainForm;
            panel_payment.Visible = false;
        }
        public void Slide_Show()
        {
            string folderPath = "Slide_Show\\";
            imagePaths = Directory.GetFiles(folderPath, "*.png").ToList();
            currentIndex = 0;
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            LoadImage();
        }

        private void LoadImage()
        {
            if (imagePaths.Count > 0)
            {
                string imagePath = imagePaths[currentIndex];
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox_Slide_Show.ImageLocation = imagePath;
                }
                else
                {
                    MessageBox.Show("File not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = false;
            Slide_Show();
        }


        private void Load_Database()
        {
            panel_pro.Controls.Add(flowLayoutPanel2);
            List<Product> thucDons = menu.GetDataFromDatabase();
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            Load_Database();
        }

        private void btn_coffee_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            string name_ctg = btn_coffee.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_tea_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            string name_ctg = btn_tea.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_smoothie_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            string name_ctg = btn_smoothie.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_cookies_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            string name_ctg = btn_cookies.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_macarons_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();
            string name_ctg = btn_macarons.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_donuts_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();

            string name_ctg = btn_donuts.Text.ToString();
            List<Product> thucDons = menu.GetData_From_Category(name_ctg);
            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }

        private void btn_homePage_Click(object sender, EventArgs e)
        {
            currentIndex = 2;
            Panel existingPanel = flowLayoutPanel2.Controls["panel_pro"] as Panel;
            if (existingPanel == null)
            {
                existingPanel = new Panel();
                existingPanel.Name = "panel_pro";
                existingPanel.Width = 680;
                existingPanel.Height = 450;

                flowLayoutPanel2.Controls.Add(existingPanel);
                flowLayoutPanel2.Controls.SetChildIndex(existingPanel, 0);
            }

            existingPanel.Visible = !existingPanel.Visible;
            flowLayoutPanel2.ScrollControlIntoView(existingPanel);
            string imagePath = imagePaths[currentIndex];
            if (System.IO.File.Exists(imagePath))
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = imagePath;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Dock = DockStyle.Fill;
                existingPanel.Controls.Clear();
                existingPanel.Controls.Add(pictureBox);
            }
            else
            {
                MessageBox.Show("File not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Wdg_MonAnAddedHandler(Payment monAn)
        {
            paymentList.Add(monAn);
            UpdateListView();
        }

        // Trong main form
        private void OnWdg_MonAnAdded_MainForm(Payment monAn)
        {
            // Update the ListView on the main form
            ListViewItem item = new ListViewItem(monAn.TEN_MON); // Assuming TEN_MON is the name of the product
            item.SubItems.Add(monAn.GIA.ToString());
            item.SubItems.Add(monAn.SO_LUONG.ToString());

            listView1.Items.Add(item);

            // Optionally, you might want to update the total price or perform other actions here.
        }


        private void UpdateListView()
        {
            
            listView1.Items.Clear();
            foreach (Payment payment in paymentList)
            {
                ListViewItem item = new ListViewItem(payment.TEN_MON);
                item.SubItems.Add(payment.GIA.ToString());
                item.SubItems.Add(payment.SO_LUONG.ToString());
                listView1.Items.Add(item);
            }
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            panel_payment.Visible = true;
            UpdateListView();
        }
    }
}