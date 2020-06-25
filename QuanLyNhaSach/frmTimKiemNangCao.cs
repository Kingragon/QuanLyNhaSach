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
    public partial class frmTimKiemNangCao : Form
    {
        public frmTimKiemNangCao()
        {
            InitializeComponent();
        }

        public string path;
        public int index, tmp1 = 0;

        private void btnTim_Click(object sender, EventArgs e)
        {
            Excel excel = new Excel(path, 2);
            try
            {
                //chưa xong nha mấy má
                int i = 2, tong = 0;

                if (txtMaSach.Text != "")
                    tong++;
                if (txtNamSX.Text != "")
                    tong++;
                if (txtNhaXuatBan.Text != "")
                    tong++;
                if (txtTacGia.Text != "")
                    tong++;
                if (txtTenSach.Text != "")
                    tong++;
                if (cbTheLoai.Text != "" && cbTheLoai.Text != "Thể loại")
                    tong++;

                int tmp = 0;
                if (tong != 0)
                {
                    while (excel.ReadCell(i, 0) != "")
                    {
                        if (txtMaSach.Text != "")
                            if (txtMaSach.Text == excel.ReadCell(i, 1).ToString())
                                tmp++;

                        if (txtTenSach.Text != "")
                            if (txtTenSach.Text == excel.ReadCell(i, 2).ToString())
                                tmp++;

                        if (txtTacGia.Text != "")
                            if (txtTacGia.Text == excel.ReadCell(i, 3).ToString())
                                tmp++;

                        if (cbTheLoai.Text != "")
                            if (cbTheLoai.Text == excel.ReadCell(i, 4).ToString())
                                tmp++;

                        if (txtNhaXuatBan.Text != "")
                            if (txtNhaXuatBan.Text == excel.ReadCell(i, 6).ToString())
                                tmp++;

                        if (txtNamSX.Text != "")
                            if (txtNamSX.Text == excel.ReadCell(i, 5).ToString())
                                tmp++;

                        if (tmp == tong)
                            tmp1++;
                        i++; tmp = 0;
                    }
                }
                else MessageBox.Show("Không có cuốn sách cần tìm");

                if (tmp1 != 0)
                {
                    MessageBox.Show("Có " + tmp1 + " cuốn sách cần tìm");
                }
                else
                    MessageBox.Show("Không có cuốn sách cần tìm");
                cbTheLoai.Text = "Thể loại";
                tmp1 = 0; tong = 0; i = 1;
                excel.Close();
            }
            catch { excel.Close(); }
        }

        private void txtMaSach_Leave(object sender, EventArgs e)
        {
            /*
            if (txtMaSach.Text[0].ToString() == "V" && txtMaSach.Text[1].ToString() == "H")
                cbTheLoai.Text = cbTheLoai.Items[7].ToString();
            else
                if (txtMaSach.Text[0].ToString() == "B" && txtMaSach.Text[1].ToString() == "O")
                cbTheLoai.Text = cbTheLoai.Items[3].ToString();
            else
                if (txtMaSach.Text[0].ToString() == "T" && txtMaSach.Text[1].ToString() == "L")
                cbTheLoai.Text = cbTheLoai.Items[5].ToString();
            else
                if (txtMaSach.Text[0].ToString() == "T" && txtMaSach.Text[1].ToString() == "S")
                cbTheLoai.Text = cbTheLoai.Items[6].ToString();
            */
        }

        private void cbTheLoai_Leave(object sender, EventArgs e)
        {
            bool check = false; //false la khong co trong item
            foreach (string item in cbTheLoai.Items)
            {
                if (cbTheLoai.Text == item)
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                MessageBox.Show("Thể loại không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTheLoai.Text = "";
            }
        }
    }
}
