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
    public partial class frmChinhSuaKH : Form
    {
        public frmChinhSuaKH()
        {
            InitializeComponent();
        }

        bool CheckData()
        {
            if (txtMaKH.Text == "")
                MessageBox.Show("Bạn chưa nhập mã khách hàng!");
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
                    //cập nhật new data (not compelete)
                }
            }
            //else
                //giữ nguyên dữ liệu (not complete)
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu không?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //cập nhật new data (not compelete)
            }
            else if (result == DialogResult.No)
                Close();
        }

        
    }
}
