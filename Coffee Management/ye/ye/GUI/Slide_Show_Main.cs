using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ye.GUI
{
    public partial class Slide_Show_Main : Form
    {
        private int currentImageIndex = 0;
        private string[] imagePaths;
        public Slide_Show_Main()
        {
            InitializeComponent();
            InitializeImageSlider();
        }
        private void InitializeImageSlider()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string imageDirectory = Path.Combine(workingDirectory, "Slide_Show");

            if (Directory.Exists(imageDirectory))
            {
                imagePaths = Directory.GetFiles(imageDirectory, "*.jpg")
                                       .Union(Directory.GetFiles(imageDirectory, "*.png"))
                                       .ToArray();

                if (imagePaths.Length > 0)
                {
                    SetImage(imagePaths[currentImageIndex]);
                    Timer timer = new Timer();
                    timer.Interval = 5000;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ảnh trong thư mục.", "Thông báo");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Thư mục ảnh không tồn tại.", "Thông báo");
                Close();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Length;
            SetImage(imagePaths[currentImageIndex]);
        }
        private void SetImage(string imagePath)
        {
            pictureBox1.ImageLocation = imagePath;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Length;
            SetImage(imagePaths[currentImageIndex]);
        }
    }
}
