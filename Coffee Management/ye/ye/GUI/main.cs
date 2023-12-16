using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        Menu_Coffee menu = new Menu_Coffee();
        Color mycolor = Color.FromArgb(255, 217, 195);

        public main()
        {
            InitializeComponent();
            panel_img_home.Visible = true;
        }

        private void main_Load(object sender, EventArgs e)
        {

            flowLayoutPanel2.AutoScroll = false;
        }

        private void LoadProducts(string categoryName)
        {
            panel_img_home.Visible = false;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();

            List<Product> thucDons;

            if (categoryName == "All")
            {
                thucDons = menu.GetDataFromDatabase();
            }
            else
            {
                thucDons = menu.GetData_From_Category(categoryName);
            }

            foreach (Product thucDon in thucDons)
            {
                Widget thucDonWidget = new Widget();
                thucDonWidget.LoadDataFromDatabase(thucDon);
                thucDonWidget.AddToCartClicked += ThucDonWidget_AddToCartClicked;

                flowLayoutPanel2.Controls.Add(thucDonWidget);
            }
        }
        private void btn_menu_Click(object sender, EventArgs e)
        {
            LoadProducts("All");
        }
        private void btn_coffee_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_coffee.Text);
        }
        private void btn_tea_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_tea.Text);
        }
        private void btn_smoothie_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_smoothie.Text);
        }
        private void btn_cookies_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_cookies.Text);
        }
        private void btn_macarons_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_macarons.Text);
        }
        private void btn_donuts_Click(object sender, EventArgs e)
        {
            LoadProducts(btn_donuts.Text);
        }


        private void btn_logOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_homePage_Click(object sender, EventArgs e)
        {
            panel_img_home.Visible = true;
        }


        private void DisplaySearchResults(List<Product> searchResults)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (Product product in searchResults)
            {
                Widget productWidget = new Widget();
                productWidget.LoadDataFromDatabase(product);
                flowLayoutPanel2.Controls.Add(productWidget);
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            string searchTerm = textBox_Search.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                List<Product> searchResults = menu.SearchData(searchTerm);
                if (searchResults.Count > 0)
                {
                    DisplaySearchResults(searchResults);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }


        private void ThucDonWidget_AddToCartClicked(object sender, Widget.AddToCartEventArgs e)
        {
            Payment monAn = e.MonAn;
            AddMonAnToCart(monAn);
        }
        private void btn_payment_Click(object sender, EventArgs e)
        {
            panel_payment.Visible = true;
        }

        private bool isHeaderAdded = false;
        private void SetupListView()
        {
            listViewMonAn.View = View.Details;
            listViewMonAn.MultiSelect = false;
            if (!isHeaderAdded)
            {
                listViewMonAn.Columns.Add("Tên món ăn", 180).TextAlign = HorizontalAlignment.Left;
                listViewMonAn.Columns.Add("Số lượng", 55).TextAlign = HorizontalAlignment.Left;
                listViewMonAn.Columns.Add("Thành tiền", 83).TextAlign = HorizontalAlignment.Left;
                isHeaderAdded = true;
            }

            if (listViewMonAn.Columns.ContainsKey("Tên món ăn"))
            {
                listViewMonAn.Columns["Tên món ăn"].AutoResize(ColumnHeaderAutoResizeStyle.None);
            }
        }

        private void AddMonAnToCart(Payment monAn)
        {
            if (!isHeaderAdded)
            {
                SetupListView();
            }

            string tenMonAn = monAn.TEN_MON;
            string gia = monAn.GIA.ToString("N0");
            string soLuong = monAn.SO_LUONG.ToString();

            string giaThanh = (monAn.GIA * monAn.SO_LUONG).ToString("N0");

            ListViewItem item = new ListViewItem(new string[] { "", soLuong, giaThanh + " VNĐ" });

            Font itemFont = new Font("Arial", 12);
            item.Font = itemFont;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(1, 40);
            listViewMonAn.SmallImageList = imageList;

            item.UseItemStyleForSubItems = false;
            item.SubItems[0].Font = itemFont;
            item.SubItems[0].Text = tenMonAn.Replace("\n", Environment.NewLine);

            listViewMonAn.Columns[0].TextAlign = HorizontalAlignment.Left;
            listViewMonAn.Columns[0].Width = Math.Max(listViewMonAn.Columns[0].Width, 100);

            // Thêm item vào ListView
            listViewMonAn.Items.Add(item);

            if (listViewMonAn.Items.Count > 5)
            {
                listViewMonAn.TopItem = listViewMonAn.Items[listViewMonAn.Items.Count - 1];
            }
            UpdateTotal();
        }
        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                string thanhTienStr = item.SubItems[2].Text.TrimEnd(' ', 'V', 'N', 'Đ');
                if (decimal.TryParse(thanhTienStr, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"), out decimal thanhTien))
                {
                    total += thanhTien;
                }
            }

            // Hiển thị tổng trong TextBox
            txtTongGia.Text = total.ToString("N3") + " VNĐ";

        }

        private void button_delete_all_Click(object sender, EventArgs e)
        {
            listViewMonAn.Items.Clear();
            UpdateTotal();
        }
        private void button_delete_select_Click(object sender, EventArgs e)
        {
            if (listViewMonAn.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewMonAn.SelectedItems)
                {
                    listViewMonAn.Items.Remove(selectedItem);
                }

                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}