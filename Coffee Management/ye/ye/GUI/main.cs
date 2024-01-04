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
using ye.DAO;
using ye.GUI;
using ye.DTO;

namespace ye.GUI
{
    public partial class main : Form
    {
        private Menu_Coffee menu = new Menu_Coffee();
        private PaymentDAO paymentDAO = new PaymentDAO();
        Color mycolor = Color.FromArgb(255, 217, 195);
        private Form activeForm = null;
        //======================================================================
        public main()
        {
            InitializeComponent();
        }
        private void main_Load(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = false;
            Slide_Show_Main sl = new Slide_Show_Main();
            openChildForm_Home(sl);
        }
        //Menu 
        private void LoadProducts(string categoryName)
        {
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
        //======================================================================
        //Search Top
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
        //======================================================================
        //Button Excute Sidebar
        private void openChildForm(Form childForm, Control parentControl)
        {
            if (activeForm != null)
                activeForm.Close();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            parentControl.Controls.Add(childForm);
            activeForm = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void openChildForm_Home(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            activeForm = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void CloseMainFlowLayoutPanel()
        {
            if (flowLayoutPanel2.Controls.Count > 0)
            {
                flowLayoutPanel2.Controls.Clear();
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            if (activeForm is Slide_Show_Main)
                activeForm.Close();
            LoadProducts("All");
        }
        private void btn_book_Click(object sender, EventArgs e)
        {
            CloseMainFlowLayoutPanel();
            if (activeForm is Slide_Show_Main)
                activeForm.Close();
            Booking bk = new Booking();
            openChildForm(bk, flowLayoutPanel2);
        }
        private void btn_logOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }
        private void btn_homePage_Click(object sender, EventArgs e)
        {
            Slide_Show_Main sl = new Slide_Show_Main();
            openChildForm_Home(sl);
        }

        private bool isPanelVisible = false;
        private void btn_payment_Click(object sender, EventArgs e)
        {
            LoadNguoiDungToComboBox();
            if (isPanelVisible)
            {
                panel_payment.Visible = false;
            }
            else
            {
                panel_payment.Visible = true;
            }
            isPanelVisible = !isPanelVisible;
            if (activeForm is Slide_Show_Main)
                activeForm.Close();
        }
        //======================================================================
        //Payment
        private void ThucDonWidget_AddToCartClicked(object sender, Widget.AddToCartEventArgs e)
        {
            Payment monAn = e.MonAn;
            AddMonAnToCart(monAn);
        }
        private bool isHeaderAdded = false;
        private void SetupListView()
        {
            listViewMonAn.View = View.Details;
            listViewMonAn.MultiSelect = false;
            if (!isHeaderAdded)
            {
                listViewMonAn.Columns.Add("Tên món ăn", 190).TextAlign = HorizontalAlignment.Left;
                listViewMonAn.Columns.Add("Số lượng", 85).TextAlign = HorizontalAlignment.Left;
                listViewMonAn.Columns.Add("Thành tiền", 125).TextAlign = HorizontalAlignment.Left;
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

            ListViewItem existingItem = FindExistingItem(tenMonAn);

            if (existingItem != null)
            {
                // Món ăn đã tồn tại trong ListView, tăng thêm số lượng
                int existingQuantity = int.Parse(existingItem.SubItems[1].Text);
                existingQuantity += monAn.SO_LUONG;
                existingItem.SubItems[1].Text = existingQuantity.ToString();
            }
            else
            {
                // Món ăn chưa tồn tại trong ListView, thêm mới
                string giaThanh = (monAn.GIA * monAn.SO_LUONG).ToString("N0");

                ListViewItem item = new ListViewItem(new string[] { "", soLuong, giaThanh + " VNĐ" });

                Font itemFont = new Font("Arial", 12);
                item.Font = itemFont;

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
            }

            UpdateTotal();
        }
        private ListViewItem FindExistingItem(string tenMonAn)
        {
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                if (item.SubItems[0].Text == tenMonAn)
                {
                    return item;
                }
            }
            return null;
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
            MessageBox.Show("Đã xóa món thành công !", "Thông báo", MessageBoxButtons.OK);
        }
        private void button_delete_select_Click(object sender, EventArgs e)
        {
            if (listViewMonAn.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewMonAn.SelectedItems)
                {
                    listViewMonAn.Items.Remove(selectedItem);
                    MessageBox.Show("Đã xóa món thành công !", "Thông báo", MessageBoxButtons.OK);
                }

                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_payment_Click(object sender, EventArgs e)
        {
            double THANH_TIEN;
            if (TryParseNumber(txtTongGia.Text, out THANH_TIEN))
            {
                SavePaymentDetails(THANH_TIEN);
            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listViewMonAn.Items.Clear();
            txtTongGia.Clear();
        }
        private bool TryParseNumber(string input, out double result)
        {
            string numberStr = new string(input.Where(char.IsDigit).ToArray());
            return double.TryParse(numberStr, out result);
        }
        private void SavePaymentDetails(double thanhTien)
        {
            int maHoaDon = paymentDAO.InsertHoaDon(thanhTien);
            foreach (ListViewItem item in listViewMonAn.Items)
            {
                string tenMonAn = item.SubItems[0].Text;
                int soLuong = int.Parse(item.SubItems[1].Text);
                int maMon = menu.GetMaMonByTenMon(tenMonAn);
                paymentDAO.InsertChiTietHoaDon(maHoaDon, maMon, soLuong);
            }
            MessageBox.Show("Đã lưu thông tin hóa đơn và chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadNguoiDungToComboBox()
        {
            UserDAO userDAO = new UserDAO();
            List<User> nguoiDungList = userDAO.GetNguoiDungList();

            // Thiết lập nguồn dữ liệu cho ComboBox
            cb_nguoi_dung.DisplayMember = "TenNguoiDung";
            cb_nguoi_dung.ValueMember = "MaNguoiDung";
            cb_nguoi_dung.DataSource = nguoiDungList;
        }
    }
}