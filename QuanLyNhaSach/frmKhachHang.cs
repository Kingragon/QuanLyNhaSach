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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyNhaSach
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        public System.Data.DataTable dtSach = new System.Data.DataTable();
        public System.Data.DataTable createTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("MKH");
            dt.Columns.Add("HT");
            dt.Columns.Add("DC");
            dt.Columns.Add("EM");
            dt.Columns.Add("SDT");
            return dt;
        }

        public int stt;
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemKH themKH = new frmThemKH();
            themKH.ShowDialog();
            frmKhachHang_Load(sender, e);
        }

        bool check_delete = false;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Excel excel = new Excel();
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("File không tồn tại!");
            else
            {
                excel = new Excel(@fl.FullName, 3);
                dtSach = createTable();

                int i = 1, TongKH = 0;
                while (excel.ReadCell(i, 0) != "")
                {
                    dtSach.Rows.Add(i.ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                        excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString());
                    TongKH++;
                    i++;
                }

                if (check_delete)
                {
                    int _stt = 0;
                    for (int j = 0; j < i; j++)
                    {
                        _stt = j + 1;
                        excel.WriteToCell(_stt, 0, _stt.ToString());
                    }
                    _stt = i;
                    excel.WriteToCell(_stt, 0, "");
                    check_delete = false;
                    excel.Save();
                }

                dgvKhachHang.DataSource = dtSach;
                gbxKhachHang.Text = "Số lượng khách hàng (" + TongKH.ToString() + ")";
                cbTimKiem.Items.Clear();
                int stt = 2;
                while (excel.ReadCell(stt, 1) != "")
                {
                    cbTimKiem.Items.Add(excel.ReadCell(stt, 1).ToString());
                    stt++;
                }

                excel.Close();
            }
        }

        int index;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvKhachHang.CurrentCell.RowIndex;
            System.Data.DataTable dt = (System.Data.DataTable)dgvKhachHang.DataSource;
            if (dt.Rows.Count > 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[index].Cells[1].Value.ToString();
                txtHoTenKH.Text = dgvKhachHang.Rows[index].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[index].Cells[3].Value.ToString();
                txtEmail.Text = dgvKhachHang.Rows[index].Cells[4].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[index].Cells[5].Value.ToString();

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FileInfo fl = new FileInfo("sach.xlsx");
            Excel excel = new Excel(fl.FullName, 3);
            index = dgvKhachHang.CurrentCell.RowIndex;
            excel.DeleteRow(index);
            excel.Close();
            check_delete = true;
            frmKhachHang_Load(sender, e);
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            frmChinhSuaKH chinhSuaKH = new frmChinhSuaKH();
            index = dgvKhachHang.CurrentCell.RowIndex;
            System.Data.DataTable dt = (System.Data.DataTable)dgvKhachHang.DataSource;
            if (dt.Rows.Count > 0)
            {
                chinhSuaKH.MKH = dgvKhachHang.Rows[index].Cells[1].Value.ToString();
                chinhSuaKH.HTKH = dgvKhachHang.Rows[index].Cells[2].Value.ToString();
                chinhSuaKH.DICH = dgvKhachHang.Rows[index].Cells[3].Value.ToString();
                chinhSuaKH.SDT = dgvKhachHang.Rows[index].Cells[4].Value.ToString();
                chinhSuaKH.EM = dgvKhachHang.Rows[index].Cells[5].Value.ToString();
            }
            chinhSuaKH.STT = index;
            chinhSuaKH.ShowDialog();
            frmKhachHang_Load(sender, e);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Mã KH")
            {
                MessageBox.Show("Bạn chưa chọn mã khách hàng để tìm kiếm!");
                return;
            }

            //DataTable dt = createTable();
            string theloai = cbTimKiem.SelectedItem.ToString();
            FileInfo fl = new FileInfo("sach.xlsx");
            Excel excel = new Excel(fl.FullName, 3);
            dtSach = createTable();

            int i = 2, STT = 1;
            while (excel.ReadCell(i, 1) != "")
            {
                if (theloai == excel.ReadCell(i, 1))
                {
                    dtSach.Rows.Add(STT++.ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                    excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString());
                }
                i++;
            }
            gbxKhachHang.Text = "Số lượng khách hàng (" + 1.ToString() + ")";
            STT = 1;
            dgvKhachHang.DataSource = dtSach;
            excel.Close();
        }

        private void refesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }
    }
}
