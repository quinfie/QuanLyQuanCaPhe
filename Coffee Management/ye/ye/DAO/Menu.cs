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
    public class Menu_Coffee
    {
        private Connect connect = new Connect();
        public List<Product> GetDataFromDatabase()
        {
            List<Product> thucDons = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT * FROM THUC_DON";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product thucDon = new Product
                            {
                                MA_MON = Convert.ToInt32(reader["MA_MON"]),
                                TEN_MON = reader["TEN_MON"].ToString(),
                                THANH_PHAN = reader["THANH_PHAN"].ToString(),
                                GIA = Convert.ToInt32(reader["GIA"]),
                                HINH_ANH = reader["HINH_ANH"].ToString(),
                                MA_DANH_MUC = Convert.ToInt32(reader["MA_DANH_MUC"])
                            };

                            thucDons.Add(thucDon);
                        }
                    }
                }
                connection.Close();
            }
            return thucDons;
        }
        public List<Product> GetData_From_Category(string name_ctg)
        {
            List<Product> thucDons = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT T.*, D.TEN_DANH_MUC " +
                               "FROM THUC_DON T " +
                               "INNER JOIN DANH_MUC D ON T.MA_DANH_MUC = D.MA_DANH_MUC " +
                               "WHERE D.TEN_DANH_MUC = @name_ctg ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name_ctg", name_ctg);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product thucDon = new Product
                            {
                                MA_MON = Convert.ToInt32(reader["MA_MON"]),
                                TEN_MON = reader["TEN_MON"].ToString(),
                                THANH_PHAN = reader["THANH_PHAN"].ToString(),
                                GIA = Convert.ToInt32(reader["GIA"]),
                                HINH_ANH = reader["HINH_ANH"].ToString(),
                                MA_DANH_MUC = Convert.ToInt32(reader["MA_DANH_MUC"]),
                            };
                            thucDons.Add(thucDon);
                        }
                    }
                }
                connection.Close();
            }
            return thucDons;
        }
        public List<Product> SearchData(string searchTerm)
        {
            List<Product> thucDons = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();

                string query = "SELECT * FROM THUC_DON WHERE TEN_MON LIKE '%' + @SearchTerm + '%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product thucDon = new Product
                            {
                                MA_MON = Convert.ToInt32(reader["MA_MON"]),
                                TEN_MON = reader["TEN_MON"].ToString(),
                                THANH_PHAN = reader["THANH_PHAN"].ToString(),
                                GIA = Convert.ToInt32(reader["GIA"]),
                                HINH_ANH = reader["HINH_ANH"].ToString(),
                                MA_DANH_MUC = Convert.ToInt32(reader["MA_DANH_MUC"])
                            };

                            thucDons.Add(thucDon);
                        }
                    }
                }
                connection.Close();
            }
            return thucDons;
        }
        public int GetMaMonByTenMon(string tenMonAn)
        {
            int maMon = 0;
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();

                string query = "SELECT MA_MON FROM THUC_DON WHERE TEN_MON = @TenMon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenMon", tenMonAn);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        maMon = reader.GetInt32(0);
                    }
                }
            }
            return maMon;
        }
    }
}
