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
    public class PaymentDAO
    {
        private Connect connect = new Connect();
        public int InsertHoaDon(double thanhTien)
        {
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();

                string insertHoaDonQuery = "INSERT INTO HOA_DON (THANH_TIEN) VALUES (@ThanhTien); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(insertHoaDonQuery, connection))
                {
                    command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public void InsertChiTietHoaDon(int maHoaDon, int maMon, int soLuong)
        {
            using (SqlConnection connection = new SqlConnection(connect.GetConnection()))
            {
                connection.Open();

                string insertChiTietHoaDonQuery = "INSERT INTO CHI_TIET_HOA_DON (MA_HOA_DON, MA_MON, SO_LUONG) VALUES (@MaHoaDon, @MaMon, @SoLuong);";
                using (SqlCommand command = new SqlCommand(insertChiTietHoaDonQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    command.Parameters.AddWithValue("@MaMon", maMon);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
