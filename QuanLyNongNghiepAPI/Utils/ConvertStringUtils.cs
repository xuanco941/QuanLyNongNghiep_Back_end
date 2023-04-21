using System.Text.RegularExpressions;
using System.Text;

namespace QuanLyNongNghiepAPI.Utils
{
    public class ConvertStringUtils
    {
        public static string RemoveAccents(string input)
        {
            // Tạo bảng chuyển đổi từ ký tự có dấu sang ký tự không dấu
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string decomposed = input.Normalize(NormalizationForm.FormD);
            string result = regex.Replace(decomposed, String.Empty);

            return result;
        }
    }
}
