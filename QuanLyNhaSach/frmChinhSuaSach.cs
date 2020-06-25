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

namespace QuanLyNhaSach
{
    public partial class frmChinhSuaSach : Form
    {
        public frmChinhSuaSach()
        {
            InitializeComponent();
        }

        public string MS, TS, TG, TL, NSX, NXB, MT, GB, SL;

        private void frmChinhSuaSach_Load(object sender, EventArgs e)
        {
            txtMaSach.Text = MS;
            txtTenSach.Text = TS;
            txtTacGia.Text = TG;
            cbTheLoai.Text = TL;
            txtNSX.Text = NSX;
            txtNamSX.Text = NXB;
            txtMoTa.Text = MT;
            txtGiaBan.Text = GB;
            txtSoLuongTon.Text = SL;
        }

        public int STT;

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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    FileInfo fl = new FileInfo("sach.xlsx");
                    Excel excel = new Excel(fl.FullName, 3);
                    excel.WriteToCell(STT + 1, 1, txtMaSach.Text.ToString());
                    excel.WriteToCell(STT + 1, 2, txtTenSach.Text.ToString());
                    excel.WriteToCell(STT + 1, 3, txtTacGia.Text.ToString());
                    excel.WriteToCell(STT + 1, 4, cbTheLoai.Text.ToString());
                    excel.WriteToCell(STT + 1, 5, txtNSX.Text.ToString());
                    excel.WriteToCell(STT + 1, 6, txtNamSX.Text.ToString());
                    excel.WriteToCell(STT + 1, 7, txtMoTa.Text.ToString());
                    excel.WriteToCell(STT + 1, 8, txtGiaBan.Text.ToString());
                    excel.WriteToCell(STT + 1, 9, txtSoLuongTon.Text.ToString());
                    excel.WriteToCell(STT + 1, 0, STT.ToString());
                    excel.Save();
                    excel.Close();
                    Close();

                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn cập nhật chứ?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                btnCapNhat_Click(sender, e);
                Close();
            }
            else if(result == DialogResult.No)
                Close();
        }
    }
}
