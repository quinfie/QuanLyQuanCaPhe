using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace frm_DatBan
{
    public partial class frmDatBan : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_ban = new DataTable();

        string conStr = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=Sugong_Coffee;Integrated Security=True";

        public frmDatBan()
        {
            InitializeComponent();
            string sql_ban = "select *from Ban";
            dt_ban = db.getDataTable(sql_ban);
            DataColumn[] key1 = new DataColumn[1];
            key1[0] = dt_ban.Columns[0];
            dt_ban.PrimaryKey = key1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_DGV_DatBan();
            Load_cboNguoiPhuTrach();
            txtSoLuong.Clear();
        }

        List<Control> lst = new List<Control>();

        private void initLstControl()
        {
            lst.Add(lblG1);
            lst.Add(lblG2);
            lst.Add(lblG3);
            lst.Add(lblG4);
            lst.Add(lblG5);
            lst.Add(lblG6);
            lst.Add(lblG7);
            lst.Add(lblG8);
            lst.Add(lblG9);
            lst.Add(lblG10);
            lst.Add(lblG11);
            lst.Add(lblG12);
        }

        private void lblG1_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            txtMaHD.Text = ctr.Text;

            // Lấy trạng thái của bàn từ DataTable dt_ban
            int maBan = int.Parse(ctr.Text);
            DataRow row = dt_ban.Rows.Find(maBan);
            string tinhTrangBan = row["TINH_TRANG_BAN"].ToString();
            txtTinhTrangBan.Text = tinhTrangBan;

            if (ctr.BackColor == Color.WhiteSmoke)
            {
                ctr.BackColor = Color.LightBlue;
            }
            else if (ctr.BackColor == Color.LightBlue)
            {
                ctr.BackColor = Color.WhiteSmoke;
            }
            else
            {
                ctr.BackColor = Color.WhiteSmoke;
                maBan = int.Parse(txtMaHD.Text);
                tinhTrangBan = "Trống";
                //CapNhatBan(maBan, tinhTrangBan);
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        public void Load_cboNguoiPhuTrach()
        {
            string sql = "select * from Nguoi_dung";
            DataTable dtNguoiDung = db.getDataTable(sql);
            cboNguoiPhuTrach.DataSource = dtNguoiDung;
            cboNguoiPhuTrach.DisplayMember = "TEN_NGUOI_DUNG";
            cboNguoiPhuTrach.ValueMember = "MA_NGUOI_DUNG";
        }

        int number = 1;

        void Update_MaDB()
        {
            txtMaHD.Text = number.ToString();
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            Update_MaDB();
            number++;
        }

        void Load_DGV_DatBan()
        {
            dgvThongTinDatBan.AutoGenerateColumns = false;
            string sql = "select *from HOA_DON, CHI_TIET_HOA_DON, THUC_DON, NGUOI_DUNG where HOA_DON.MA_HOA_DON = CHI_TIET_HOA_DON.MA_HOA_DON AND THUC_DON.MA_MON = CHI_TIET_HOA_DON.MA_MON and NGUOI_DUNG.MA_NGUOI_DUNG = HOA_DON.NGUOI_PHU_TRACH";
            DataTable dtChiTiet = db.getDataTable(sql);
            dgvThongTinDatBan.DataSource = dtChiTiet;
        }

        //private void CapNhatBan(int maBan, string tinhTrangBan)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(conStr))
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Cap_Nhat_Trang_Thai_Ban", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
        //                command.Parameters.Add("@TinhTrangBan", SqlDbType.NVarChar, 100).Value = tinhTrangBan;
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi thực hiện stored procedure: " + ex.Message);
        //    }
        //}

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            try
            {
                initLstControl();
                foreach (var item in lst)
                {
                    if (item.BackColor == Color.LightBlue)
                    {
                        item.BackColor = Color.HotPink;
                        int maBan = int.Parse(txtMaHD.Text);
                        string tinhtrang = "Đã đặt";
                        //CapNhatBan(maBan, tinhtrang);
                        MessageBox.Show("Cập nhật thành công!");
                        // Lấy thông tin cần hiển thị từ các trường tương ứng
                        string nguoiPhuTrach = cboNguoiPhuTrach.Text;
                        int maHoaDon = int.Parse(txtMaHD.Text);
                        int soLuong = int.Parse(txtSoLuong.Text);

                        // Thêm hàng mới vào DataGridView
                        dgvThongTinDatBan.Rows.Add(nguoiPhuTrach, maHoaDon, soLuong);
                        // Lấy số lượng người ngồi từ TextBox txtSoLuong
                        int soLuongNguoiNgoi = int.Parse(txtSoLuong.Text);
                        MessageBox.Show($"Số lượng người ngồi tại bàn: {soLuongNguoiNgoi}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            Load_DGV_DatBan();
        }
    }
}