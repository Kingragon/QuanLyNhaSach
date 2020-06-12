using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhaSach
{
    public partial class frmQuanLyNhaSach : Form
    {
        System.Data.DataTable dtSach = new System.Data.DataTable();
        
        int index;

        public frmQuanLyNhaSach()
        {
            InitializeComponent();

        }

        //Tạo bảng dữ liệu
        public System.Data.DataTable createTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("MaSach");
            dt.Columns.Add("TenSach");
            dt.Columns.Add("TacGia");
            dt.Columns.Add("TheLoai");
            dt.Columns.Add("GiaBan");
            dt.Columns.Add("SoLuong");
            return dt;
        }

        public string path;

        private void frmQuanLyDauSach_Load(object sender, EventArgs e)
        {
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("Không có file!");
            else
            {
                path = fl.FullName;
                Excel excel = new Excel(path, 1);
                try
                {
                    dtSach = createTable();

                    int i = 2;
                    while (excel.ReadCell(i, 0) != "")
                    {
                        dtSach.Rows.Add(excel.ReadCell(i, 0).ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                            excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString() + ".000 đồng", excel.ReadCell(i, 6).ToString());
                        i++;
                    }

                    dgvSach.DataSource = dtSach;

                    excel.Close();
                }
                catch { excel.Close(); }

                //dgvSach.RefreshEdit();

                //txtMaSach auto cập nhật (not complete)
            }
        }

        public System.Data.DataTable GanData()
        {
            return (System.Data.DataTable)dgvSach.DataSource;
        }

        // Row <=> Thông tin chi tiết sách
        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            
            index = dgvSach.CurrentCell.RowIndex;
            System.Data.DataTable dt = (System.Data.DataTable)dgvSach.DataSource;
            if (dt.Rows.Count > 0)
            {
                txtMaSach.Text = dgvSach.Rows[index].Cells[1].Value.ToString();
                txtTenSach.Text = dgvSach.Rows[index].Cells[2].Value.ToString();
                txtTacGia.Text = dgvSach.Rows[index].Cells[3].Value.ToString();
                cbTheLoai.Text = dgvSach.Rows[index].Cells[4].Value.ToString();
                txtGiaBan.Text = dgvSach.Rows[index].Cells[5].Value.ToString();
                txtSoLuong.Text = dgvSach.Rows[index].Cells[6].Value.ToString(); //Số lượng tồn
            }
        }

        //Click Thêm -> mở form mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach();
            f.Show();
        }

        //Click Chỉnh sửa -> mở form mới
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            frmChinhSuaSach f = new frmChinhSuaSach();
            f.Show();
        }

        //Chọn thông tin -> Click Xóa (1 hàng)
        //Vấn đề: chọn nhiều hàng xóa cùng lúc (not complete)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                dtSach.Rows.RemoveAt(index);
                dgvSach.DataSource = dtSach;
                dgvSach.RefreshEdit();
            }   
        }

        //Click Tìm (Ngân - not complete)
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Thể loại")
            {
                MessageBox.Show("Bạn chưa chọn thể loại để tìm kiếm!");
                return;
            }
            
            //DataTable dt = createTable();
            string theloai = cbTimKiem.SelectedItem.ToString();
            Excel excel = new Excel(path, 1);
            dtSach = createTable();

            int TongSoSach = 0, i = 1, STT = 1;
            while (excel.ReadCell(i, 4) != "")
            {
                if (theloai == excel.ReadCell(i, 4))
                {
                    dtSach.Rows.Add(STT++.ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                    excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString(), excel.ReadCell(i, 6).ToString());
                    TongSoSach++;
                }
                i++;
            }
            gbxThongTin.Text = "Thông tin các đầu sách (" + TongSoSach.ToString() + ")";
            TongSoSach = 0;
            STT = 1;
            dgvSach.DataSource = dtSach;
            excel.Close();
        }       

        //Click Tìm kiếm nâng cao (not complete)
        private void btnTimKiemNangCao_Click(object sender, EventArgs e)
        {
            frmTimKiemNangCao f = new frmTimKiemNangCao();
            f.path = path;
            f.Show();
        }

        private void hóaĐơnBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonBanSach f = new frmHoaDonBanSach();
            f.Show();
        }

        //Click menu Danh sách sách -> mở form
        private void danhSáchSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachSach f = new frmDanhSachSach();
            f.path = path;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.Show();
        }
 
        //not complete
        private void thayĐổiQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //not complete
        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyNhaSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("HIHI");
        }

        private void refToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDauSach_Load(sender, e);
            gbxThongTin.Text = "Thông tin các đầu sách";
        }


        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietSach f = new ChiTietSach();
            f.path = path;
            f.i = index + 1;
            f.ShowDialog();
        }
    }
}
