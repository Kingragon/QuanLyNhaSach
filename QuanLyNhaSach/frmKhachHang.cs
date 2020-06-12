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

        System.Data.DataTable dtSach = new System.Data.DataTable();

        public void RefreshInfor()
        {
            txtMaKH.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtHoTenKH.Text = "";
        }

        public string DeleteSpace(string txt)
        {
            if (txt[0] == ' ')
            {
                for (int i = txt.Length - 1; i >= 0; i--)
                    if (txt[i] == ' ' && txt[i + 1] == ' ')
                        txt = txt.Remove(i + 1, 1);
            }
            else
            {
                for (int i = txt.Length - 1; i >= 1; i--)
                    if (txt[i] == ' ' && txt[i + 1] == ' ')
                        txt = txt.Remove(i + 1, 1);
            }
            if (txt[0] == ' ') txt = txt.Remove(0, 1);
            return txt;
        }

        public bool CheckWord(string txt)
        {
            //chu nhap vao la lower
            txt = txt.ToLower();

            //kiem tra co thuoc bang chu cai hay khong
            int bienthu = 1;
            for (int i = 0; i < txt.Length; i++)
            {
                for (char j = 'a'; j <= 'z'; j++)
                {
                    bienthu = 1;
                    if (txt[i] == j || txt[i] == ' ')
                    {
                        bienthu = 0;
                        break;
                    }
                }
            }
            if (bienthu == 0)
                return true;
            else return false;
        }

        public string Upper(string txt)
        {
            string kq; //ket qua 
            //chu nhap vao la lower
            txt = txt.ToLower();

            //kiem tra co thuoc bang chu cai hay khong
            if (CheckWord(txt))
            {
                kq = char.ToUpper(txt[0]).ToString();
                for (int i = 1; i < txt.Length; i++)
                {
                    if (txt[i] == ' ')
                        kq += char.ToUpper(txt[i + 1]).ToString();
                    else
                        if (txt[i] != ' ' && txt[i - 1] != ' ')
                        kq += txt[i].ToString();
                    if (i < txt.Length - 1)
                        if (txt[i] != ' ' && txt[i + 1] == ' ')
                            kq += " ";
                }
                return kq;
            }
            else return txt = "";
        }

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

        Excel excel = new Excel();
        public void KhoiTao(string path)
        {
            excel = new Excel(@path, 1);
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                excel.WriteToCell(0, j, dataGridView1.Columns[j].HeaderText);
            excel.Close();
        }

        int Stt = 1;
        private void btnThem_Click(object sender, EventArgs e)
        {
            string STTs;
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("File không tồn tại!");
            else
            {
                excel = new Excel(@fl.FullName, 3);
                int stt = 1;
                while (excel.ReadCell(stt, 0) != "")
                {
                    if (excel.ReadCell(stt + 1, 0) == "")
                    {
                        STTs = excel.ReadCell(stt, 0);
                        Stt = int.Parse(STTs);
                        Stt++;
                        break;
                    }
                    else stt++;
                }
            }

            //ghi vao excel
            excel.WriteToCell(Stt, 1, txtMaKH.Text.ToString());
            excel.WriteToCell(Stt, 2, txtHoTenKH.Text.ToString());
            excel.WriteToCell(Stt, 3, txtDiaChi.Text.ToString());
            excel.WriteToCell(Stt, 4, txtEmail.Text.ToString());
            excel.WriteToCell(Stt, 5, "'" + txtSDT.Text.ToString());
            excel.WriteToCell(Stt, 0, Stt.ToString());
            Stt++;

            //ghi vao grid view
            dtSach = createTable();

            int i = 1;
            while (excel.ReadCell(i, 0) != "")
            {
                dtSach.Rows.Add(i.ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                    excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString());
                i++;
            }
            dataGridView1.DataSource = dtSach;

            RefreshInfor();
            excel.Save();
            excel.Close();
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
                txtMaKH.Text = DeleteSpace(txtMaKH.Text.ToString());
        }

        private void txtHoTenKH_Leave(object sender, EventArgs e)
        {
            if (txtHoTenKH.Text != "")
                txtHoTenKH.Text = Upper(txtHoTenKH.Text.ToString());
            if (txtHoTenKH.Text == "")
                MessageBox.Show("Họ và tên không hợp lệ");
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            FileInfo fl = new FileInfo("sach.xlsx");
            if (!fl.Exists)
                MessageBox.Show("File không tồn tại!");
            else
            {
                excel = new Excel(@fl.FullName, 3);
                dtSach = createTable();

                int i = 1;
                while (excel.ReadCell(i, 0) != "")
                {
                    dtSach.Rows.Add(i.ToString(), excel.ReadCell(i, 1).ToString(), excel.ReadCell(i, 2).ToString(), excel.ReadCell(i, 3).ToString(),
                        excel.ReadCell(i, 4).ToString(), excel.ReadCell(i, 5).ToString());
                    i++;
                }
                dataGridView1.DataSource = dtSach;
                excel.Close();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSDT.Text.Length > 9)
            {
                txtSDT.ReadOnly = true;
                MessageBox.Show("Số điện thoại chỉ có 10 số thôi, bớt nhập xàm lại nha!");
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            txtSDT.Text = "";
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            txtSDT.Text = "";
        }

        public bool Check_mail(string txt)
        {
            for (int i = 0; i < txt.Length; i++)
                if (txt[i] != '@')
                {
                    return false;
                }
                    return true;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if(Check_mail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
            }

            string tmp = "gmail.com";
            if (tmp.Contains(txtEmail.Text.ToString()))
                MessageBox.Show("Email không hợp lệ!");
        }
    }
}
