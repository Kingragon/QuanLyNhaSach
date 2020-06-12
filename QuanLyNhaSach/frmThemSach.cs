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

namespace QuanLyNhaSach
{
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }
        public bool CheckData()
        {
            bool check = false;
            //Kiểm tra mã sách có tồn tại hay không (kiểm tra định dạng) (not complete)
            if (txtMaSach.Text == "")
                MessageBox.Show("Bạn chưa nhập mã sách!");
            else if (txtTenSach.Text == "")
                MessageBox.Show("Bạn chưa nhập tên sách!");
            else if (txtTacGia.Text == "")
                MessageBox.Show("Bạn chưa nhập tên tác giả!");
            else if (cbTheLoai.Text == "")
                MessageBox.Show("Bạn chưa chọn thể loại sách!");
            else if(txtNamSX.Text == "")
                MessageBox.Show("Bạn chưa nhập năm sản xuất!");
            else if (txtNSX.Text == "")
                MessageBox.Show("Bạn chưa nhập tên nhà sản xuất!");
            else if (txtMoTa.Text == "")
                MessageBox.Show("Bạn chưa mô tả sách!");
            else if (txtGiaBan.Text == "")
                MessageBox.Show("Bạn chưa nhập giá bán!");
            else if (txtSoLuongNhap.Text == "")
                MessageBox.Show("Bạn chưa nhập số lượng sách!");
            else
            {
                int soluong;
                if (!int.TryParse(txtSoLuongNhap.Text, out soluong))
                {
                    MessageBox.Show("Số lượng tồn phải là kiểu số");
                    txtSoLuongNhap.Text = "";
                }
                else
                {
                    //Kiểm tra số lượng tồn <= 300
                    if (soluong > 300)
                    {
                        // Lưu ý quy định số lượng tồn có thể thay đổi (not complete)
                        MessageBox.Show("Số lượng không được lớn hơn 300!");
                        txtSoLuongNhap.Text = "";
                    }
                    else
                    {
                        //Kiểm tra kiểu của giá bán
                        double giaban;
                        if (!double.TryParse(txtGiaBan.Text, out giaban))
                            MessageBox.Show("Giá bán phải là kiểu số thực!");
                        else 
                            check = true;

                    }
                }
            }
            return check;
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

                //reset các thông tin text về ban đầu (xóa trắng)
                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtTacGia.Text = "";
                cbTheLoai.Text = "";
                txtNSX.Text = "";
                txtNamSX.Text = "";
                txtMoTa.Text = "";
                txtGiaBan.Text = "";
                txtSoLuongNhap.Text = "";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu không?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //cập nhật new data (not compelete)
            }
            else if(result == DialogResult.No)
                Close();
        }

    }
}
