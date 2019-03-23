using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

//using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace DataWriter
{
    public class ExcelWriter
    {
        public string FilePath { get; set; }

        public ExcelWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public void WriteData(DataTable dt)
        {
            if (File.Exists(this.FilePath))
                File.Delete(this.FilePath);

            if (dt.Rows.Count == 0)
                throw new Exception("Data Table does not contain any rows.");

            using (FileStream stream = new FileStream(this.FilePath, 
                FileMode.CreateNew, FileAccess.Write))
            {
                string sheetName = (dt.TableName == string.Empty) ?
                   "Sheet1" : dt.TableName;
                
                IWorkbook wb = new XSSFWorkbook();
                ISheet sheet = wb.CreateSheet(sheetName);

                var cellStyle = (XSSFCellStyle)wb.CreateCellStyle();
                cellStyle.WrapText = true;

                var rowHeader = sheet.CreateRow(0);
                for (int i=0; i< dt.Columns.Count; i++)
                {
                    var cell = rowHeader.CreateCell(i);
                    var o = dt.Rows[0][i];
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                    cell.CellStyle = cellStyle;
                }
 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var rowIndex = i + 1;
                    var row = sheet.CreateRow(rowIndex);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        var cell = row.CreateCell(j);
                        var o = dt.Rows[i][j];
                        cell.SetCellValue(o.ToString());

                        sheet.AutoSizeColumn(dt.Columns[j].Ordinal);
                    }
                }

                wb.Write(stream);
            }
        }
    }
}
