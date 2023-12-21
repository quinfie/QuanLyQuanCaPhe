using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frm_DatBan
{
    internal class DBConnect
    {
        SqlConnection connect;
        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        public DBConnect()
        {
            string conStr = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=Sugong_Coffee;Integrated Security=True";
            Connect = new SqlConnection(conStr);
        }
        public void open()
        {
            if (Connect.State == ConnectionState.Closed)
                Connect.Open();
        }
        public void close()
        {
            if (Connect.State == ConnectionState.Open)
                Connect.Close();
        }
        public DataTable getDataTable(string conStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(conStr, Connect);
            da.Fill(dt);
            return dt;
        }
        public int updateDatabase(string selStr, DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter(selStr, Connect);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }
        public object GetData(string conStr)
        {
            SqlCommand cmd;
            open();
            cmd = new SqlCommand(conStr, Connect);
            object data = cmd.ExecuteScalar();
            close();
            return data;
        }
    }
}
