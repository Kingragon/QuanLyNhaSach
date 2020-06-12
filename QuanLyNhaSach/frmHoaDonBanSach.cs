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
    public partial class frmHoaDonBanSach : Form
    {
        public frmHoaDonBanSach()
        {
            InitializeComponent();
        }

        DataTable dtSach = new DataTable();
        int index;

        //Tạo bảng dữ liệu
        public DataTable createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHoaDon");
            dt.Columns.Add("MaSach");
            dt.Columns.Add("TenSach");
            dt.Columns.Add("TheLoai");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            return dt;
        }

        //(notcomplete)
        private void frmHoaDonBanSach_Load(object sender, EventArgs e)
        {
            txtNgayLapHoaDon.Text = DateTime.Now.ToString();
        }
        
        //Điền thông tin -> Click lập hóa đơn (-> Hủy)
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtHoTenKH.Clear();
            txtDiaChi.Clear();
            txtMaHoaDon.Clear();
            txtMaKH.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Chọn thông tin -> Click Xóa (1 hàng)
        //Vấn đề: chọn nhiều hàng xóa cùng lúc (not complete)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtSach.Rows.RemoveAt(index);
            dgvHoaDonBanSach.DataSource = dtSach;
            dgvHoaDonBanSach.RefreshEdit();
        }

        //Tính tổng thành tiền (not complete)
        //Liên kết dữ liệu (not complete)


    }
}
