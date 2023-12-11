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

namespace ye
{
    public partial class Login : Form
    {
        private static string connect_Str = @"Data Source=PIOTISK\SQLEXPRESS_19;Initial Catalog=QuanLyCaPhe;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = checkBoxPass.Checked;
            if (!isChecked)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }

        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPass.Text;

            using (SqlConnection connection = new SqlConnection(connect_Str))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TAI_KHOAN WHERE TEN_DANG_NHAP = @Username AND MAT_KHAU = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    query = "SELECT VAI_TRO FROM TAI_KHOAN WHERE TEN_DANG_NHAP = @Username";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    int role = (int)command.ExecuteScalar();

                    query = "SELECT TEN_NGUOI_DUNG FROM NGUOI_DUNG WHERE MA_NGUOI_DUNG = (SELECT MA_NGUOI_DUNG FROM TAI_KHOAN WHERE TEN_DANG_NHAP = @Username)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    string fullName = command.ExecuteScalar().ToString();

                    string roleString = role == 1 ? "ADMIN" : "STAFF";
                    // sửa lại khúc này
                    MessageBox.Show("Đăng nhập thành công!\n\nTên người dùng: {fullName}\nVai trò: {roleString}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    main mainForm = new main();
                    mainForm.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        }
    }

