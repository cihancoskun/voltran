using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Voltran.Web.Helpers
{
    public static class StringHelper
    {
        public static string ToNoDashString(this Guid guid)
        {
            return guid.ToString().Replace("-", string.Empty);
        }

        public static string ToUrlSlug(this string text)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(
                        text.Trim().ToLowerInvariant()
                            .Replace("ö", "o")
                            .Replace("ç", "c")
                            .Replace("ş", "s")
                            .Replace("ı", "i")
                            .Replace("ğ", "g")
                            .Replace("ü", "u")
                            .Replace("-", "_"),
                        @"\s+", " "), // multiple spaces to one space
                    @"\s", "-"), // spaces to hypens
                @"[^a-z0-9_\s-]", string.Empty); // removing invalid chars
        }

        public static string ToProperCaseTR(this string str)
        {
            var words = str.Split(' ');

            var sentence = new StringBuilder();
            foreach (var word in words)
            {
                var fChar = word.Substring(0, 1);
                if (Regex.Match(fChar, @"[A-Za-zÜĞİŞÇÖüğişçö]").Success)
                {
                    sentence.AppendFormat("{0}{1} ", fChar.ToUpper(ConstHelper.CultureTR), word.Substring(1).ToLower(ConstHelper.CultureTR));
                }
                else
                {
                    sentence.AppendFormat("{0}{1} ", word.Substring(0, 2).ToUpper(ConstHelper.CultureTR), word.Substring(2).ToLower(ConstHelper.CultureTR));
                }
            }

            return sentence.ToString();
        }

        public static string ToLowerTR(this string text)
        {
            return text.Trim().ToLower(ConstHelper.CultureTR);
        }

        public static bool IsEmail(this string text)
        {
            try
            {
                new MailAddress(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}