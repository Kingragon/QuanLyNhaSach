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
using _Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhaSach
{
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }

        Excel excel = new Excel();
        System.Data.DataTable dtSach = new System.Data.DataTable();
        int Stt = 1;

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
            else if (txtNSX.Text == "")
                MessageBox.Show("Bạn chưa nhập tên nhà sản xuất!");
            else if (txtMoTa.Text == "")
                MessageBox.Show("Bạn chưa mô tả sách!");
            else if (txtGiaBan.Text == "")
                MessageBox.Show("Bạn chưa nhập giá bán!");
            else if (numSoLuongNhap.Value == 0)
                MessageBox.Show("Bạn chưa nhập số lượng sách!");
            else
            {
                int soluong = int.Parse(numSoLuongNhap.Value.ToString());
                    //Kiểm tra số lượng tồn <= 300
                    if (soluong > 300)
                    {
                        // Lưu ý quy định số lượng tồn có thể thay đổi (not complete)
                        MessageBox.Show("Số lượng không được lớn hơn 300!");
                        numSoLuongNhap.Value = 0 ;
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
            return check;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
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
                        excel = new Excel(@fl.FullName, 2);

                        //chạy số thứ tự tăng dần
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
                    excel.WriteToCell(Stt, 1, txtMaSach.Text.ToString());
                    excel.WriteToCell(Stt, 2, txtTenSach.Text.ToString());
                    excel.WriteToCell(Stt, 3, txtTacGia.Text.ToString());
                    excel.WriteToCell(Stt, 4, cbTheLoai.SelectedItem.ToString());
                    excel.WriteToCell(Stt, 5, numNSX.Value.ToString());
                    excel.WriteToCell(Stt, 6, txtNSX.Text.ToString());
                    excel.WriteToCell(Stt, 7, txtGiaBan.Text.ToString());
                    excel.WriteToCell(Stt, 8, numSoLuongNhap.Value.ToString());
                    excel.WriteToCell(Stt, 9, txtMoTa.Text.ToString());
                    excel.WriteToCell(Stt, 0, (Stt - 1).ToString());
                    excel.Save();
                    excel.Close();
                }

                //reset các thông tin text về ban đầu (xóa trắng)
                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtTacGia.Text = "";
                cbTheLoai.Text = "";
                txtNSX.Text = "";
                numNSX.Value = 1200;
                txtMoTa.Text = "";
                txtGiaBan.Text = "";
                numSoLuongNhap.Value = 0;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu không?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

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
