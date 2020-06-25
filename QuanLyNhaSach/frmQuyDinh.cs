using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmQuyDinh : Form
    {
        public frmQuyDinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            numSoLuongNhapSach.Value = 150;
            numSoLuongTon.Value = 300;
            numSoLuongTonSauKhiBan.Value = 20;
        }

        //(Not complete)
        private void btnThayDoi_Click(object sender, EventArgs e)
        {

        }
    }
}
