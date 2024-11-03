using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Extension
{
    // Tham khảo từ:https://manhng.com/blog/chuyen-tieng-viet-co-dau-thanh-khong-dau/

    public static string utf8Convert(this string value)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = value.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp.Replace(" ", "-"), String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
    }

}