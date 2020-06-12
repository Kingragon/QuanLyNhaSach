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

namespace QuanLyNhaSach
{
    public partial class ChiTietSach : Form
    {
        public ChiTietSach()
        {
            InitializeComponent();
        }

        public int i;
        public string path;

        private void ChiTietSach_Load(object sender, EventArgs e)
        {
            Excel excel = new Excel(path, 1);
            try
            {
                txtMaSach.Text = excel.ReadCell(i, 1).ToString();
                txtTenSach.Text = excel.ReadCell(i, 2).ToString();
                txtTacGia.Text = excel.ReadCell(i, 3).ToString();
                txtTheLoai.Text = excel.ReadCell(i, 4).ToString();
                txtSoLuong.Text = excel.ReadCell(i, 5).ToString();
                txtGiaBan.Text = excel.ReadCell(i, 6).ToString();
                txtNXB.Text = excel.ReadCell(i, 7).ToString();
                txtNamSanXuat.Text = excel.ReadCell(i, 8).ToString();
                txtMoTa.Text = excel.ReadCell(i, 9).ToString();
                excel.Close();
            }
            catch
            { excel.Close(); }

            //string s = "hinhanh:\" + 
            FileInfo fl = new FileInfo("hinh anh\\Orca2.jpg");
            //pictureBox1.Image = Image.FromFile("hinhanh:\\Orca2.jpg");
            if (!fl.Exists)
                MessageBox.Show("File không tồn tại! \\");
            else
            {
                pictureBox1.ImageLocation = fl.FullName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
