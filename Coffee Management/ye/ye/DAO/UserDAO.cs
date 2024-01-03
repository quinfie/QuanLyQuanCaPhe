using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ye.DTO;

namespace ye.DAO
{
    public class UserDAO
    {
        private Connect connect = new Connect();
        public List<User> GetNguoiDungList()
        {
            List<User> nguoiDungList = new List<User>();

            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT MA_NGUOI_DUNG, TEN_NGUOI_DUNG FROM NGUOI_DUNG";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User nguoiDung = new User
                            {
                                MaNguoiDung = reader.GetString(0),
                                TenNguoiDung = reader.GetString(1),

                            };

                            nguoiDungList.Add(nguoiDung);
                        }
                    }
                }
                connection.Close();
            }
            return nguoiDungList;
        }
    }
}
