using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ye.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ye.DAO
{
    public class LoginDAO
    {
        private Connect connect = new Connect();
        public int GetAccountCount(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM TAI_KHOAN WHERE TEN_DANG_NHAP = @Username AND MAT_KHAU = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    return (int)command.ExecuteScalar();
                }
                connection.Close();
            }
        }

        public LoginDTO GetAccountInfo(string username)
        {
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT VAI_TRO FROM TAI_KHOAN WHERE TEN_DANG_NHAP = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int role = (int)command.ExecuteScalar();
                    return new LoginDTO { tdn = username, vt = role };
                }
                connection.Close();
            }

        }
    }
}
