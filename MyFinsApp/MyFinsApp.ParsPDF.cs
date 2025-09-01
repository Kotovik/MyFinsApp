using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
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
        
        public static void ParsPDF()
        {
            using (PdfReader reader = new PdfReader(@"C:\Users\Diago\OneDrive\Desktop\test.pdf"))
            {
                StringBuilder text = new StringBuilder();
                ITextExtractionStrategy Strategy = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string page = "";

                    page = PdfTextExtractor.GetTextFromPage(reader, i, Strategy);
                    string[] lines = page.Split('\n');
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line.ToString());
                    }
                }
            }
        }

    }
}