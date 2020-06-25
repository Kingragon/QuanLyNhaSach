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
    public partial class frmChinhSuaKH : Form
    {
        public frmChinhSuaKH()
        {
            InitializeComponent();
        }

        public string MKH, HTKH, DICH, EM, SDT;
        public int STT;

        public bool Check_mail(string txt)
        {
            for (int i = 0; i < txt.Length; i++)
                if (txt[i] != '@')
                {
                    return false;
                }
            return true;
        }

        public bool Email_Leave(string txt)
        {
            txt = txt.ToLower();
            if (!txt.Contains("@gmail.com"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                return false;
            }
            return true;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Email_Leave(txtEmail.Text);
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

        public bool Leave_SDT(string txt)
        {
            if (txt.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải gồm 10 số!");
                return false;
            }
            else
            if (txt != "")
                if (txt[0] != '0')
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0!");
                    return false;
                }
            return true;
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            Leave_SDT(txtSDT.Text);
        }

        private void frmChinhSuaKH_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = MKH;
            txtHoTenKH.Text = HTKH;
            txtDiaChi.Text = DICH;
            txtEmail.Text = EM;
            txtSDT.Text = SDT;
        }

        bool CheckData()
        { 
            if (txtHoTenKH.Text == "")
                MessageBox.Show("Bạn chưa nhập họ tên khách hàng!");
            else if (txtDiaChi.Text == "")
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
            else if (txtEmail.Text == "")
                MessageBox.Show("Bạn chưa nhập email!");
            else if (txtSDT.Text == "")
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
            else
            {
                if (txtSDT.Text.Length == 10) //check sđt đủ 10 số không, có tồn tại kí tự khác số không (not complete)
                    return true;
                //check email (not complete - có thể không làm)
            }
            return false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (Leave_SDT(txtSDT.Text) == true && Email_Leave(txtEmail.Text) == true)
                    {
                        FileInfo fl = new FileInfo("sach.xlsx");
                        Excel excel = new Excel(fl.FullName, 3);
                        STT++;
                        excel.WriteToCell(STT, 1, txtMaKH.Text.ToString());
                        excel.WriteToCell(STT, 2, txtHoTenKH.Text.ToString());
                        excel.WriteToCell(STT , 3, txtDiaChi.Text.ToString());
                        excel.WriteToCell(STT , 5, txtEmail.Text.ToString());
                        excel.WriteToCell(STT , 4, "'" + txtSDT.Text.ToString());
                        excel.WriteToCell(STT , 0, STT.ToString());
                        excel.Save();
                        excel.Close();
                        Close();
                    }
                    
                }
            }
            //else
                //giữ nguyên dữ liệu (not complete)
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            btnCapNhat_Click(sender, e);
        }

        
    }
}
