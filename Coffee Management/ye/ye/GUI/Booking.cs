using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ye.DAO;
using ye.DTO;

namespace ye.GUI
{
    public partial class Booking : Form
    {
        private TableDAO tableDAO = new TableDAO();
        private int selectedTableID;  // Variable to store the selected table ID

        public Booking()
        {
            InitializeComponent();
            LoadTableList();
        }

        private void LoadTableList()
        {
            List<TableDTO> tableList = tableDAO.LoadTableList();

            foreach (TableDTO table in tableList)
            {
                Button tableButton = new Button
                {
                    Width = 180,
                    Height = 120,
                    Text = $"ID: {table.ID}\nStatus: {table.TinhTrangBan}",
                    Tag = table.ID,
                };

                if (table.TinhTrangBan == "Đã Đặt")
                {
                    tableButton.BackColor = Color.Yellow;
                }

                tableButton.Click += TableButton_Click;
                flp_table.Controls.Add(tableButton);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            int tableID = Convert.ToInt32(((Button)sender).Tag);
            TableDTO selectedTable = tableDAO.GetTableByID(tableID);

            if (selectedTable != null)
            {
                if (selectedTable.TinhTrangBan == "Đã Đặt")
                {
                    tableDAO.UpdateTableStatus(tableID, "Trống");
                    flp_table.Controls.Clear();
                    LoadTableList();
                    MessageBox.Show("Thay Đổi Tình Trạng Bàn Thành Công !");
                }
                else
                {
                    selectedTableID = tableID;
                    if (selectedTableID != 0)
                    {
                        tableDAO.UpdateTableStatus(selectedTableID, "Đã Đặt");
                        flp_table.Controls.Clear();
                        LoadTableList();
                        selectedTableID = 0;
                        MessageBox.Show("Thay Đổi Tình Trạng Bàn Thành Công !");
                    }
                }



            }
        }
    }
}
