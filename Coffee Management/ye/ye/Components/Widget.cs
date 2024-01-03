using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ye.DTO;
using System.IO;

namespace ye
{

    public partial class Widget : UserControl
    {
        public class AddToCartEventArgs : EventArgs
        {
            public Payment MonAn { get; }

            public AddToCartEventArgs(Payment monAn)
            {
                MonAn = monAn;
            }
        }
        public Product ProductInfo { get; private set; }
        public delegate void MonAnEventHandler(Payment monAn);
        private int current_value = 0;
        public Widget()
        {
            InitializeComponent();
            SetWidgetProperties();
        }

        public Product GetSelectedProduct()
        {
            return ProductInfo;
        }

        private void SetWidgetProperties()
        {
            Color mycolor = Color.FromArgb(255, 217, 195);
            this.BackColor = mycolor;
            panel1.BackColor = mycolor;
            button_add.BackColor = mycolor;
            button_minus.BackColor = mycolor;
            tb_details.BackColor = mycolor;
            button_add_to_cart.BackColor = mycolor;
        }

        public void LoadDataFromDatabase(Product menu)
        {
            ProductInfo = menu;
            name_pr.Text = menu.TEN_MON;
            price_pr.Text = string.Format("{0:N0} VNĐ", menu.GIA);
            tb_details.Text = menu.THANH_PHAN;
            string folderPath = "Image\\";
            string imageName = menu.HINH_ANH;
            string imagePath = Path.Combine(folderPath, imageName);
            img_pr.ImageLocation = imagePath;
        }


        private void button_minus_Click(object sender, EventArgs e)
        {
            current_value--;
            UpdateLabelValue();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            current_value++;
            UpdateLabelValue();
        }

        private void UpdateLabelValue()
        {
            label_count.Text = current_value.ToString();
        }

        private void Widget_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler<AddToCartEventArgs> AddToCartClicked;
        private void btn_add_to_cart_Click(object sender, EventArgs e)
        {
            Payment monAn = new Payment
            {
                TEN_MON = ProductInfo.TEN_MON,
                GIA = ProductInfo.GIA,
                SO_LUONG = current_value
            };
            AddToCartClicked?.Invoke(this, new AddToCartEventArgs(monAn));
            label_count.Text = "0";
            current_value = 0;

        }
    }
}
