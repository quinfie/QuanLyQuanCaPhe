using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ye.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ye.DAL
{
    public class Menu_Coffee
    {
        private string connectionString = @"Data Source=PIOTISK\SQLEXPRESS_19;Initial Catalog=QuanLyCaPhe;Integrated Security=True";
        public List<Product> GetDataFromDatabase()
        {
            List<Product> thucDons = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            }
            return thucDons;
        }

        public List<Product> GetData_From_Category(string name_ctg)
        {
            List<Product> thucDons = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            }
            return thucDons;
        }
    }
}
