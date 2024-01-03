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
using ye.DAO;
using ye.DTO;

namespace ye.GUI
{
    public partial class Login : Form
    {
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPass.Text;

            LoginDAO login_dao = new LoginDAO();

            int count = login_dao.GetAccountCount(username, password);

            if (count > 0)
            {
                LoginDTO accountInfo = login_dao.GetAccountInfo(username);

                string roleString = accountInfo.vt == 1 ? "ADMIN" : "STAFF";
                MessageBox.Show($"Đăng nhập thành công!\n\nTên người dùng: {username}\nVai trò: {roleString}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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