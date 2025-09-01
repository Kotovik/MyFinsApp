using Spire.Pdf;
using Spire.Pdf.Texts;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ExtractTextFromPage

{

    class Program

    {
        public static void Main(string[] args)

        {
            List<string> txt = new List<string>();
            // Создаем объект PdfDocument

            PdfDocument pdf = new PdfDocument();

            // Загружаем PDF-файл

            pdf.LoadFromFile(@"C:\Users\Diago\OneDrive\Desktop\test.pdf");

            StringBuilder extractedText = new StringBuilder();

            foreach (PdfPageBase page in pdf.Pages)
            {
                // Create a PdfTextExtractor for the current page
                PdfTextExtractor extractor = new PdfTextExtractor(page);
                // Set extraction options
                PdfTextExtractOptions option = new PdfTextExtractOptions
                {
                    IsExtractAllText = true
                };
                // Extract text from the current page
                string text = extractor.ExtractText(option);
                // Append the extracted text to the StringBuilder
                extractedText.AppendLine(text);
            }

            txt.Add(extractedText.ToString());

            pdf.Close();
            
        }

    }

}