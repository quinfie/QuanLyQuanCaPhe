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
    public class Connect
    {
        private SqlConnection connection;
        private string connectionString = @"Data Source=PIOTISK\SQLEXPRESS_19;Initial Catalog=Sugong_Coffee;Persist Security Info=True;User ID=sa;Password=123";

        public Connect()
        {
            connection = new SqlConnection(connectionString);
        }

        public string GetConnection()
        {
            return connectionString;
        }
    }
}
