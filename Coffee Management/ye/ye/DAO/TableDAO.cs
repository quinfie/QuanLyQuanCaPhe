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
    public class TableDAO
    {
        private Connect connect = new Connect();

        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> tableList = new List<TableDTO>();

            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT * FROM BAN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableDTO table = new TableDTO(reader);
                            tableList.Add(table);
                        }
                    }
                }
                connection.Close();
            }
            return tableList;
        }

        public void UpdateTableStatus(int tableID, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "UPDATE BAN SET TINH_TRANG_BAN = @NewStatus WHERE ID = @TableID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@TableID", tableID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public TableDTO GetTableByID(int tableID)
        {
            TableDTO table = null;
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();
                string query = "SELECT ID, TINH_TRANG_BAN FROM BAN WHERE ID = @TableID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            table = new TableDTO
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                TinhTrangBan = reader.GetString(reader.GetOrdinal("TINH_TRANG_BAN"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return table;
        }
    }
}
