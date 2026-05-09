using PersonalFinanceManager.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using Tesseract;

namespace PersonalFinanceManager.Services
{
    public class ReceiptOcrService
    {
        public ReceiptOcrResult AnalyzeReceipt(string imagePath)
        {
            ReceiptOcrResult result = new ReceiptOcrResult();

            if (string.IsNullOrWhiteSpace(imagePath))
            {
                result.Success = false;
                result.Message = "Nu a fost selectată nicio imagine.";
                return result;
            }

            if (!File.Exists(imagePath))
            {
                result.Success = false;
                result.Message = "Fișierul imaginii nu există.";
                return result;
            }

            string text = ExtractTextFromImage(imagePath);

            result.RawText = text;

            if (string.IsNullOrWhiteSpace(text))
            {
                result.Success = false;
                result.Message = "Nu s-a putut extrage text din imagine.";
                return result;
            }

            result.Date = ExtractDate(text);
            result.Total = ExtractTotal(text);

            if (result.Date == null && result.Total == null)
            {
                result.Success = false;
                result.Message = "Textul a fost citit, dar nu s-au găsit data sau totalul.";
                return result;
            }

            result.Success = true;
            result.Message = "Datele au fost extrase cu succes.";
            return result;
        }

        private string ExtractTextFromImage(string imagePath)
        {
            string tessdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");
            string languageFilePath = Path.Combine(tessdataPath, "ron.traineddata");

            if (!Directory.Exists(tessdataPath))
            {
                return string.Empty;
            }

            if (!File.Exists(languageFilePath))
            {
                return string.Empty;
            }

            try
            {
                using (TesseractEngine engine = new TesseractEngine(tessdataPath, "ron", EngineMode.Default))
                using (Pix image = Pix.LoadFromFile(imagePath))
                using (Page page = engine.Process(image))
                {
                    return page.GetText();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private DateTime? ExtractDate(string text)
        {
            Regex dateRegex = new Regex(
                @"Data\s*[:\-]?\s*(\d{1,2}[\.\/\-]\d{1,2}[\.\/\-]\d{2,4})",
                RegexOptions.IgnoreCase);

            Match match = dateRegex.Match(text);

            if (!match.Success)
            {
                return null;
            }

            string dateText = match.Groups[1].Value.Trim();

            string[] formats =
            {
                "dd.MM.yyyy",
                "d.MM.yyyy",
                "dd.M.yyyy",
                "d.M.yyyy",
                "dd/MM/yyyy",
                "d/MM/yyyy",
                "dd-MM-yyyy",
                "d-MM-yyyy"
            };

            if (DateTime.TryParseExact(
                dateText,
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate))
            {
                return parsedDate;
            }

            return null;
        }

        private decimal? ExtractTotal(string text)
        {
            Regex totalRegex = new Regex(
                @"TOTAL\s*[:\-]?\s*([0-9]+(?:[\.,][0-9]{1,2})?)",
                RegexOptions.IgnoreCase);

            Match match = totalRegex.Match(text);

            if (!match.Success)
            {
                return null;
            }

            string totalText = match.Groups[1].Value.Trim();
            totalText = totalText.Replace(",", ".");

            if (decimal.TryParse(
                totalText,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal total))
            {
                return total;
            }

            return null;
        }
    }
}