using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyFinsApp
{
    public static class Para
    {


        public static void ParsExel()
        {
            using (var workbook = new XLWorkbook(@"C:\Users\Diago\OneDrive\Desktop\Statement 04.09.2024 - 04.09.2025.XLSX"))
            {
                StreamWriter bd = new StreamWriter(@"C:\Users\Diago\OneDrive\Desktop\save.txt",true);

                var worksheet = workbook.Worksheet(1);

                // Чтение данных
                for (int i = 2; i <= worksheet.RowsUsed().Count(); i++)
                {
                    var amount = worksheet.Cell(i, 8);
                    var type = worksheet.Cell(i, 13);
                    var date = worksheet.Cell(i, 1);
                    var info = worksheet.Cell(i, 7);
                    var category = worksheet.Cell(i, 11);
                    var comment = worksheet.Cell(i, 15);
                   
                    bd.WriteLine(FormattableString.Invariant($"{amount.Value}|{type.Value}|{date.Value}|{info.Value}|{category.Value}|{comment.Value}")); 

                }
                bd.Close();
            }
        }
    }
}