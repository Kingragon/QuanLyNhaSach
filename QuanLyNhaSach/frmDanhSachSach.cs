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
    public partial class frmDanhSachSach : Form
    {
        public frmDanhSachSach()
        {
            InitializeComponent();
        }

        DataTable dtSach = new DataTable();

        //Tạo bảng dữ liệu
        public DataTable createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("MaSach");
            dt.Columns.Add("TenSach");
            dt.Columns.Add("TacGia");
            dt.Columns.Add("NXS");
            dt.Columns.Add("NXB");
            dt.Columns.Add("MoTa");
            dt.Columns.Add("TheLoai");
            dt.Columns.Add("GiaBan");
            dt.Columns.Add("SoLuong");            
            return dt;
        }

        public string path;
        private void frmDanhSachSach_Load(object sender, EventArgs e)
        {
            dgvDanhSachSach.AutoSize = true;
            Excel excel = new Excel(path, 2);
            dtSach = createTable();
            int i = 2;
            while (excel.ReadCell(i, 0) != "")
            {
                dtSach.Rows.Add(excel.ReadCell(i, 0).ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(),
                    excel.ReadCell(i, 3).ToString(), excel.ReadCell(i, 5).ToString(), excel.ReadCell(i, 6).ToString(), excel.ReadCell(i, 9).ToString(),
                    excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 7).ToString(), excel.ReadCell(i, 8).ToString());
              
                i++;
            }

            dgvDanhSachSach.DataSource = dtSach;

            dgvDanhSachSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            excel.Close();
            //dgvSach.RefreshEdit();
        }

        private void dgvDanhSachSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Row <=> Thông tin chi tiết sách
        /*private void dgvDanhSachSach_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvDanhSachSach.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgvDanhSachSach.DataSource;
            if (dt.Rows.Count > 0)
            {
                txtMaSach.Text = dgvDanhSachSach.Rows[index].Cells[0].Value.ToString();
                txtTenSach.Text = dgvDanhSachSach.Rows[index].Cells[1].Value.ToString();
                txtTacGia.Text = dgvDanhSachSach.Rows[index].Cells[2].Value.ToString();
                cbTheLoai.Text = dgvDanhSachSach.Rows[index].Cells[3].Value.ToString();
                txtGiaBan.Text = dgvDanhSachSach.Rows[index].Cells[4].Value.ToString();
                txtSoLuong.Text = dgvDanhSachSach.Rows[index].Cells[5].Value.ToString(); //Số lượng tồn

                //Vấn đề: Giá bán và số lượng lấy dữ liệu từ frmmain (not complete) 
            }
        }*/

        //Bổ sung button tìm kiếm (not complete)
    }
}
