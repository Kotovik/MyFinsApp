using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Word;
using System.Text.Json;

namespace MyFinsApp
{
    public static class Para
    {


        public static void ParsExel()
        {
            using (var workbook = new XLWorkbook(@"C:\Users\Diago\OneDrive\Desktop\Statement 04.09.2024 - 04.09.2025.XLSX"))
            {
                
                var worksheet = workbook.Worksheet(1);

                string filejson = @"C:\Users\Diago\OneDrive\Desktop\Save.json";
                List<RealTransaction> translist = new List<RealTransaction>();
                try
                {
                    string existingJson = File.ReadAllText(filejson);

                    translist = JsonSerializer.Deserialize<List<RealTransaction>>(existingJson);
                }
                catch (Exception ex) { Console.WriteLine("Пук {0}",ex); }

                // Чтение данных
                for (int i = 2; i <= worksheet.RowsUsed().Count(); i++)
                {
                    var amount = Convert.ToDouble(worksheet.Cell(i, 8).Value.ToString());
                    var type = worksheet.Cell(i, 13).Value.ToString();
                    var date = worksheet.Cell(i, 1).Value.ToString();
                    var info = worksheet.Cell(i, 7).Value.ToString();
                    var category = worksheet.Cell(i, 11).Value.ToString();
                    var comment = worksheet.Cell(i, 15).Value.ToString();


                    var realtrans = new RealTransaction(date, amount, info, category, comment);
                    translist.Add(realtrans);
                    
                }
                
                string jsonString = JsonSerializer.Serialize(translist, new JsonSerializerOptions
                {
                    WriteIndented = true // для красивого форматирования
                });

                File.WriteAllText(filejson, jsonString);

            }
        }
    }
}