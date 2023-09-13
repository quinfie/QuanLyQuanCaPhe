using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IlaIla
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        private void Form2_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Họ tên", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Ngày sinh", typeof(string));
            table.Columns.Add("Giới tính", typeof(string));
            table.Columns.Add("Khóa học", typeof(string));
            dataGridView1.DataSource = table;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Hp\Desktop\table.txt");
            string[] value;
            for (int i = 0; i < lines.Length; i++)
            {
                value = lines[i].ToString().Split('/');
                string[] row = new string[value.Length];

                for (int j = 0; j < value.Length; j++)
                {
                    row[j] = value[j].Trim();
                }
                table.Rows.Add(row);
            }
        }
    }
}
