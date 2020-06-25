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
        System.Data.DataTable dtSach = new System.Data.DataTable(); //Tạo dtSach
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
                Excel excel = new Excel(path, 2);
                try
                {
                    dtSach = createTable();

                    int i = 2;
                    while (excel.ReadCell(i, 0) != "")
                    {
                        i++;
                    }
                    
                    dgvSach.DataSource = dtSach;

                    if (check_delete)
                    {
                        int _stt = 0;
                        for (int j = 0; j < i; j++)
                        {
                            _stt = j + 2;
                            excel.WriteToCell(_stt, 0, (_stt - 1).ToString());
                        }
                        _stt = i;
                        excel.WriteToCell(_stt, 0, "");
                        check_delete = false;
                        excel.Save();
                    }

                    for(int dem = 2; dem < i; dem++)
                    {
                        dtSach.Rows.Add(excel.ReadCell(dem, 0).ToString(), excel.ReadCell(dem, 1).ToString(), excel.ReadCell(dem, 2).ToString(), excel.ReadCell(dem, 3).ToString(),
                            excel.ReadCell(dem, 4).ToString(), excel.ReadCell(dem, 7).ToString() + ".000 đồng", excel.ReadCell(dem, 6).ToString());
                    }

                    excel.Close();
                }
                catch { excel.Close(); }

                //dgvSach.RefreshEdit();

                //txtMaSach auto cập nhật (not complete)
            }
        }

        // Row <=> Thông tin chi tiết sách
        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            
            index = dgvSach.CurrentCell.RowIndex;
            System.Data.DataTable dt = (System.Data.DataTable)dgvSach.DataSource;
            if (dt.Rows.Count > 0)
            {
                string s = "AlbumSach\\" + dgvSach.Rows[index].Cells[1].Value.ToString() + ".jpg";
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

        private void pbxSach_Click(object sender, EventArgs e)
        {
            frmChiTietSach f = new frmChiTietSach();
            f.path = path;
            f.i = index + 1;
            f.ShowDialog();
        }

        //Click Thêm -> mở form mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach();
            f.ShowDialog();
            frmQuanLyDauSach_Load(sender, e);
        }

        //Click Chỉnh sửa -> mở form mới
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            frmChinhSuaSach f = new frmChinhSuaSach();
            index = dgvSach.CurrentCell.RowIndex;
            index = index + 2;
            FileInfo fl = new FileInfo("sach.xlsx");
            path = fl.FullName;
            Excel excel = new Excel(path, 2);
            System.Data.DataTable dt = (System.Data.DataTable)dgvSach.DataSource;
            if (dt.Rows.Count > 0)
            {
                f.MS = excel.ReadCell(index, 1).ToString();
                f.TS = excel.ReadCell(index, 2).ToString();
                f.TG = excel.ReadCell(index, 3).ToString();
                f.TL = excel.ReadCell(index, 4).ToString();
                f.NXB = excel.ReadCell(index, 5).ToString();
                f.NSX = excel.ReadCell(index, 6).ToString();
                f.GB = excel.ReadCell(index, 7).ToString();
                f.SL = excel.ReadCell(index, 8).ToString();
                f.MT = excel.ReadCell(index, 9).ToString();
            }
            f.STT = index;
            excel.Close();
            f.ShowDialog();
            frmQuanLyDauSach_Load(sender, e);
        }

        //Chọn thông tin -> Click Xóa (1 hàng)
        //Vấn đề: chọn nhiều hàng xóa cùng lúc (not complete)

        bool check_delete = false;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                FileInfo fl = new FileInfo("sach.xlsx");
                Excel excel = new Excel(fl.FullName, 2);
                index = dgvSach.CurrentCell.RowIndex;
                excel.DeleteRow(index + 1);
                excel.Close();
                check_delete = true;
                frmQuanLyDauSach_Load(sender, e);
            }   
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Thể loại")
            {
                MessageBox.Show("Bạn chưa chọn thể loại để tìm kiếm!");
                return;
            }
            
            //DataTable dt = createTable();
            string theloai = cbTimKiem.SelectedItem.ToString();
            Excel excel = new Excel(path, 2);
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
        public int tmp1;
        private void btnTimKiemNangCao_Click(object sender, EventArgs e)
        {
            frmTimKiemNangCao f = new frmTimKiemNangCao();
            f.path = path;
            f.ShowDialog();
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
 
        private void thayĐổiQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuyDinh f = new frmQuyDinh();
            f.Show();
        }

        //not complete
        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // ?
        private void refToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDauSach_Load(sender, e);
            gbxThongTin.Text = "Thông tin các đầu sách";
        }


        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietSach f = new frmChiTietSach();
            f.path = path;
            f.i = index + 1;
            f.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTin f = new frmThongTin();
            f.Show();
        }

    }
}
