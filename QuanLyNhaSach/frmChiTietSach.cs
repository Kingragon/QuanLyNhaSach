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
    public partial class frmChiTietSach : Form
    {
        public frmChiTietSach()
        {
            InitializeComponent();
        }

        public int i;
        public string path;

        private void ChiTietSach_Load(object sender, EventArgs e)
        {
            Excel excel = new Excel(path, 2);
            try
            {
                i++;
                lbTuaSach.Text = excel.ReadCell(i, 2).ToString();
                txtMaSach.Text = excel.ReadCell(i, 1).ToString();
                txtTacGia.Text = excel.ReadCell(i, 3).ToString();
                txtTheLoai.Text = excel.ReadCell(i, 4).ToString();
                txtNamSanXuat.Text = excel.ReadCell(i, 5).ToString();
                txtNXB.Text = excel.ReadCell(i, 6).ToString();
                txtSoLuong.Text = excel.ReadCell(i, 8).ToString();
                txtGiaBan.Text = excel.ReadCell(i, 7).ToString();
                txtMoTa.Text = excel.ReadCell(i, 9).ToString();
                excel.Close();
            }
            catch
            { 
                excel.Close();
            }

            string s = "AlbumSach\\" + txtMaSach.Text + ".jpg";
            FileInfo fl = new FileInfo(s);
            if (!fl.Exists)
                MessageBox.Show("File không tồn tại!");
            else
            {
                pbxSach.ImageLocation = fl.FullName;
                pbxSach.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

    }
}
