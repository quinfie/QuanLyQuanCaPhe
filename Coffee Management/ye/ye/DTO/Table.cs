using System;
using System.Data.SqlClient;

namespace ye.DTO
{
    public class TableDTO
    {
        public int ID { get; set; }
        public int MaBan { get; set; }
        public string TinhTrangBan { get; set; }
        public TableDTO() { }
        public TableDTO(SqlDataReader reader)
        {
            ID = Convert.ToInt32(reader["ID"]);
            MaBan = Convert.ToInt32(reader["MA_BAN"]);
            TinhTrangBan = reader["TINH_TRANG_BAN"].ToString();
        }
    }
}
