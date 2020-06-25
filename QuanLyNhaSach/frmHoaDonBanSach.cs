using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace QuanLyNhaSach
{
    public partial class frmHoaDonBanSach : Form
    {
        public frmHoaDonBanSach()
        {
            InitializeComponent();
        }

        System.Data.DataTable dtHoaDon = new System.Data.DataTable();
        int index = 0;

        //Tạo bảng dữ liệu
        public System.Data.DataTable createTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("TenSach");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            return dt;
        }

        //(notcomplete)
        private void frmHoaDonBanSach_Load(object sender, EventArgs e)
        {
            txtNgayLapHoaDon.Text = DateTime.Now.ToString();
            dtHoaDon = createTable(); Refresh();
        }

        //Điền thông tin -> Click lập hóa đơn (-> Hủy)

        string DG;
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("Không có file!");
            else
            {
                Excel excel = new Excel(fl.FullName, 2);
                string MS = "", DG = "", TS = "";
                int i = 2; bool check = false;
                int tong = 0;
                while (excel.ReadCell(i, 0) != "")
                {
                    if (txtTenSach.Text == excel.ReadCell(i, 2) || txtMaSach.Text == excel.ReadCell(i, 1))
                    {
                        MS = excel.ReadCell(i, 1).ToString();
                        DG = excel.ReadCell(i, 7).ToString();
                        TS = excel.ReadCell(i, 2).ToString();
                        int Gia = int.Parse(DG);
                        int SoLuong = int.Parse(numSoLuong.Value.ToString());
                        tong = tong + (Gia * SoLuong);

                        bool check_trung = true;
                        for (int k = 0; k < dgvHoaDonBanSach.Rows.Count - 1; k++)
                        {
                            if (dgvHoaDonBanSach.Rows[k].Cells[0].Value.ToString() == TS)
                            {
                                MessageBox.Show("Sách thêm bị trùng!");
                                check_trung = false;
                                break;
                            }
                        }

                        if (check_trung)
                        {
                            dtHoaDon.Rows.Add(TS, numSoLuong.Value.ToString(), DG + ".000");
                            dgvHoaDonBanSach.DataSource = dtHoaDon;
                            dgvHoaDonBanSach.RefreshEdit();
                        }
                        check = true;
                        break;
                    }
                    i++;
                }
                excel.Close();

                
                for (int k = 0; k < dgvHoaDonBanSach.Rows.Count - 1; k++)
                {
                    
                }
                txtTongThanhTien.Text = tong.ToString() + ".000";

                if (check == false)
                {
                    MessageBox.Show("Không có sách!");
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtHoTenKH.Clear();
            // txtDiaChi.Clear();
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
            dtHoaDon.Rows.RemoveAt(index);
            dgvHoaDonBanSach.DataSource = dtHoaDon;
            dgvHoaDonBanSach.RefreshEdit();
        }

        public void Refresh()
        {
            FileInfo fileInfo = new FileInfo("Hóa đơn bán hàng.xlsx");
            Excel excel = new Excel(fileInfo.FullName, 1);
            excel.WriteToCell(0, 1, "");
            excel.WriteToCell(0, 0, "HÓA ĐƠN BÁN HÀNG");
            excel.WriteToCell(1, 4, "");
            excel.WriteToCell(1, 0, "");
            excel.WriteToCell(2, 0, "");
            excel.WriteToCell(2, 4, "");
            excel.WriteToCell(3, 0, "");
            excel.WriteToCell(3, 1, "");
            excel.WriteToCell(3, 2, "");
            excel.WriteToCell(3, 3, "");
            excel.WriteToCell(3, 4, "");
            excel.WriteToCell(4, 0, "");
            excel.WriteToCell(4, 2, "");
            excel.WriteToCell(4, 3, "");
            for(int i = 1; i < 15; i++)
            {
                excel.WriteToCell(i, 0, "");
                excel.WriteToCell(i, 1, "");
                excel.WriteToCell(i, 2, "");
                excel.WriteToCell(i, 3, "");
            }
            excel.Save();
            excel.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo("Hóa đơn bán hàng.xlsx");

            if (!fileInfo.Exists)
                MessageBox.Show("Không có file!");
            else
            {
                Excel excel = new Excel(fileInfo.FullName, 1);

                excel.WriteToCell(1, 0, "Ngày: " + txtNgayLapHoaDon.Text.ToString());
                excel.WriteToCell(1, 4, "Mã hóa đơn: " + txtMaHoaDon.Text.ToString());

                if (txtHoTenKH.Text != "")
                {
                    excel.WriteToCell(4, 0, "Tên sách");
                    excel.WriteToCell(4, 2, "Số lượng");
                    excel.WriteToCell(4, 3, "Đơn giá");
                    excel.WriteToCell(2, 0, "Họ tên: " + txtHoTenKH.Text.ToString());
                    excel.WriteToCell(2, 4, "Mã khách hàng: " + txtMaKH.Text.ToString());

                    for (int i = 0; i < dgvHoaDonBanSach.Rows.Count - 1; i++)
                    {
                        excel.WriteToCell(i + 5, 0, dgvHoaDonBanSach.Rows[i].Cells[0].Value.ToString());
                        excel.WriteToCell(i + 5, 1, dgvHoaDonBanSach.Rows[i].Cells[1].Value.ToString());
                        excel.WriteToCell(i + 5, 2, dgvHoaDonBanSach.Rows[i].Cells[2].Value.ToString());
                        excel.Save();
                    }

                    int VT_TongTien = dgvHoaDonBanSach.Rows.Count + 4;
                    excel.WriteToCell(VT_TongTien, 3, "Thành tiền: " + txtTongThanhTien.Text.ToString());
                }
                else
                {
                    excel.WriteToCell(3, 0, "Tên sách");
                    excel.WriteToCell(3, 1, "Số lượng");
                    excel.WriteToCell(3, 2, "Đơn giá");
                    for (int i = 0; i < dgvHoaDonBanSach.Rows.Count - 1; i++)
                    {
                        excel.WriteToCell(i + 4, 0, dgvHoaDonBanSach.Rows[i].Cells[0].Value.ToString());
                        excel.WriteToCell(i + 4, 1, dgvHoaDonBanSach.Rows[i].Cells[1].Value.ToString());
                        excel.WriteToCell(i + 4, 2, dgvHoaDonBanSach.Rows[i].Cells[2].Value.ToString());
                        excel.Save();
                    }

                    int VT_TongTien = dgvHoaDonBanSach.Rows.Count + 3;
                    excel.WriteToCell(VT_TongTien, 3, "Thành tiền: " + txtTongThanhTien.Text.ToString());
                }

                excel.Save();
                excel.Close();
                MessageBox.Show("Xuất thành công!");
            }
        }

        private void txtTenSach_Click(object sender, EventArgs e)
        {
            string TS = "";
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("Không có file!");
            else
            {
                Excel excel = new Excel(fl.FullName, 2);
                TS = "";

                int i = 2;

                while (excel.ReadCell(i, 0) != "")
                {
                    if (txtMaSach.Text == excel.ReadCell(i, 1))
                    {
                        TS = excel.ReadCell(i, 2).ToString();
                        break;
                    }
                    i++;
                }
                excel.Close();
            }
            if (txtMaSach.Text != "")
                txtTenSach.Text = TS;
            else
                txtTenSach.Text = "";
        }

        private void txtHoTenKH_Click(object sender, EventArgs e)
        {
            string TKH = "";
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("Không có file!");
            else
            {
                Excel excel = new Excel(fl.FullName, 3);
                TKH = "";

                int i = 1;

                while (excel.ReadCell(i, 0) != "")
                {
                    if (txtMaKH.Text == excel.ReadCell(i, 1))
                    {
                        TKH = excel.ReadCell(i, 2).ToString();
                        break;
                    }
                    i++;
                }
                excel.Close();
            }
            if (txtMaKH.Text != "")
                txtHoTenKH.Text = TKH;
            else
                txtHoTenKH.Text = "";
        }

        //Tính tổng thành tiền (not complete)
        //Liên kết dữ liệu (not complete)

    }
}
