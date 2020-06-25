using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel; //Khai báo using này để liên kết với excel
using _Excel = Microsoft.Office.Interop.Excel; //Đặt tên khai báo trên là _Excel
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuanLyNhaSach
{
    class Excel
    {
        string path = ""; //Khai báo đường dẫn là chuỗi
        _Application excel = new _Excel.Application(); //Khai báo ứng dụng excel
        Workbook wb; //Khai báo Workbook
        Worksheet ws; //Khai báo Worksheet

        public Excel() { }

        public Excel(string link, int Sheet) //Khởi tạo excel (link mở, số sheet mở)
        {
            this.path = link; //Gán đường dẫn
            wb = excel.Workbooks.Open(link); //wb = mở workbook của excel trong link
            ws = wb.Worksheets[Sheet]; //ws = worksheet trong workbook vừa mở; [mảng, số sheet muốn mở]
        }

        public string ReadCell(int i, int j) //Đọc ô trong excel
        {
            //ô excel bắt đầu từ vị trí [1,1], ở đây truyền vào tham số 0 theo mảng
            i++;
            j++;

            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString(); //Lấy giá trị nếu ô không rỗng
            else
                return "";
        }

        public void Close()
        {
            wb.Close(); //Đóng workbook (excel)
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        }

        public void DeleteRow(int i)
        {
            i = i + 2;
            ws.Rows[i].Delete();
            wb.Save();
        }

        public void WriteToCell(int i, int j, string s)
        {
            i++; j++;
            ws.Cells[i, j].Value2 = s;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void SelectWorksheet(int SheetNumber)
        {
            this.ws = wb.Worksheets[SheetNumber];
        }

        public void Delete_Sheet()
        {
            wb.Worksheets[1].Delete();
            //wb.Save();
        }    

        public void CreateNewSheet()
        {
            ws = wb.Worksheets.Add(After: ws);
            wb.Save();
        }

        public void CreateExcel()
        {
            wb = excel.Workbooks.Add(Type.Missing);
            ws = null;
            ws = wb.Sheets["Sheet1"];
            ws = wb.ActiveSheet;
            ws.Name = "CustumerDetail";

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Thông tin khách hàng";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            excel.Quit();
        }
    }
}
