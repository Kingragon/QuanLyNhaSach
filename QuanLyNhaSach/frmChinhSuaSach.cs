using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach;

namespace QuanLyNhaSach
{
    public partial class frmChinhSuaSach : Form
    {
        public frmChinhSuaSach()
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
            else if (txtNamSX.Text == "")
                MessageBox.Show("Bạn chưa nhập năm sản xuất!");
            else if (txtNSX.Text == "")
                MessageBox.Show("Bạn chưa nhập tên nhà sản xuất!");
            else if (txtMoTa.Text == "")
                MessageBox.Show("Bạn chưa mô tả sách!");
            else if (txtGiaBan.Text == "")
                MessageBox.Show("Bạn chưa nhập giá bán!");
            else if (txtSoLuongTon.Text == "")
                MessageBox.Show("Bạn chưa nhập số lượng sách!");
            else
            {
                int soluong;
                if (!int.TryParse(txtSoLuongTon.Text, out soluong))
                {
                    MessageBox.Show("Số lượng tồn phải là kiểu số");
                    txtSoLuongTon.Text = "";
                }
                else
                {
                    //Kiểm tra số lượng tồn <= 300
                    if (soluong > 300)
                    {
                        // Lưu ý quy định số lượng tồn có thể thay đổi (not complete)
                        MessageBox.Show("Số lượng không được lớn hơn 300!");
                        txtSoLuongTon.Text = "";
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

        /// <summary>
        /// Ngân - hàm này thích thì cứ xóa
        /// </summary>
        public void Hien()
        {
            frmQuanLyNhaSach.Equals(txtMaSach.Text, txtGiaBan.Text).ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    //cập nhật data (not compelete)

                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn cập nhật chứ?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //cập nhật data (not compelete)
                Close();
            }
            else if(result == DialogResult.No)
                Close();
        }
    }
}
