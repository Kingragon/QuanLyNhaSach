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

namespace QuanLyNhaSach
{
    public partial class frmThemKH : Form
    {
        public frmThemKH()
        {
            InitializeComponent();
        }

        Excel excel = new Excel();
        System.Data.DataTable dtSach = new System.Data.DataTable();
        int Stt = 1;

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

        bool CheckTrung(string txt)
        {
            FileInfo fl = new FileInfo("sach.xlsx");
            Excel excel = new Excel(fl.FullName, 3);
            int stt = 2;
            while(excel.ReadCell(stt, 1) != "")
            {
                if (txt == excel.ReadCell(stt, 1))
                    return true;
                stt++;
            }
            return false;
        }

        bool CheckData()
        {
            if (txtMaKH.Text == "")
                MessageBox.Show("Bạn chưa nhập mã khách hàng!");
            else if (CheckTrung(txtMaKH.Text.ToUpper()))
                MessageBox.Show("Mã khách hàng đã tồn tại!");
            else if (txtHoTenKH.Text == "")
                MessageBox.Show("Bạn chưa nhập họ tên khách hàng!");
            else if (txtDiaChi.Text == "")
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
            else if (txtEmail.Text == "")
                MessageBox.Show("Bạn chưa nhập email!");
            else if (txtSDT.Text == "")
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
            else
            {
                return true;
            }
            return false;
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

        //Click cập nhật -> kiểm tra thông tin -> (nếu đúng) hiện message box hỏi bạn có muốn cập nhật không
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu đầu vào
            if (CheckData())
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    string STTs;
                    FileInfo fl = new FileInfo("sach.xlsx");
                    if (!fl.Exists)
                        MessageBox.Show("File không tồn tại!");
                    else
                    {
                        excel = new Excel(fl.FullName, 3);
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
                    Stt++;
                    //ghi vao excel
                    excel.WriteToCell(Stt, 1, txtMaKH.Text.ToUpper().ToString());
                    excel.WriteToCell(Stt, 2, txtHoTenKH.Text.ToString());
                    excel.WriteToCell(Stt, 3, txtDiaChi.Text.ToString());
                    excel.WriteToCell(Stt, 4, "'" + txtSDT.Text.ToString());
                    excel.WriteToCell(Stt, 5, txtEmail.Text.ToString());
                    excel.WriteToCell(Stt, 0, Stt.ToString());
                    excel.Save();
                    excel.Close();
                    Close();
                }

                //reset các thông tin text về ban đầu (xóa trắng)
                txtMaKH.Text = "";
                txtHoTenKH.Text = "";
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                txtSDT.Text = "";
            }

            
        }

        //Click thoát -> hiện message box hỏi bạn có muốn lưu không
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu không?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                btnCapNhat_Click(sender, e);
                Close();
            }
            else if (result == DialogResult.No)
                Close();
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            if (CheckTrung(txtMaKH.Text.ToUpper()))
                MessageBox.Show("Mã khách hàng đã tồn tại!");
            if (txtMaKH.Text != "")
                txtMaKH.Text = DeleteSpace(txtMaKH.Text.ToString());
        }

        private void txtHoTenKH_Leave(object sender, EventArgs e)
        {
            if(txtHoTenKH.Text != "")
                txtHoTenKH.Text = DeleteSpace(txtHoTenKH.Text);
            if (txtHoTenKH.Text != "")
                txtHoTenKH.Text = Upper(txtHoTenKH.Text.ToString());
            else
            if (txtHoTenKH.Text == "")
                MessageBox.Show("Họ và tên không hợp lệ");
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Số điện thoại chỉ gồm các số từ 0 đến 9!");
                e.Handled = true;
            }
            /// Char.IsContro(e.KeyChar) –> kiểm tra xem phím vừa nhập vào textbox có phải là các ký tự điều khiển
            ///                             (các phím mũi tên,Delete,Insert,backspace,space bar) hay không,
            ///                             mục đích dùng hàm này là để cho phép người dùng xóa số trong trường hợp nhập sai.
            /// Char.IsDigit(e.KeyChar) –> kiểm tra xem phím vừa nhập vào textbox có phải là ký tự số hay không,
            ///
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
            txtEmail.Text = txtEmail.Text.ToLower();
            if (!txtEmail.Text.Contains("@gmail.com"))
                MessageBox.Show("Email không đúng định dạng!");
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length < 10)
                MessageBox.Show("Số điện thoại phải gồm 10 số!");
            if(txtSDT.Text != "")
            if(txtSDT.Text[0] != '0')
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0!");
        }
    }
}
