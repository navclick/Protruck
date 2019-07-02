using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProTrukRepo.Util
{
    public static class StringUtil
    {

        public static string JoinCommaSeparated(string[] data)
        {
            if (data == null)
                return null;
            else
                return string.Join(",", data);
        }

        public static string JoinCommaSeparated(long[] data)
        {
            if (data == null)
                return null;
            else
                return string.Join(",", data);
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string FormatCDRNumber(string value)
        {
            value = value.Replace('"', ' ').Trim();
            value = value.Replace("\\", "");
            if (Constant.CellNumberRegexOrders.Match(value).Success)
            {
                value = FormatCellNumber(value);

            }
            else
            {
                if (value.Contains('<') && value.Contains('>'))
                {
                    value = value.Split('<', '>')[1];
                }

            }
            value = value.Replace(" ", "");
            if (value.Length > 5)
            {
                value = FormatCellNumber(value);
            }

            return value;
        }

        public static string FormatCellNumber(string cellNumber)
        {
            if (Constant.CellNumberRegexOrders.Match(cellNumber).Success)
            {
                // Cell Number should only be numbers
                var cellNumNormalized = Constant.CellNumbersDigitsOnly.Replace(cellNumber, string.Empty);
                // Pick up last 9 digits
                return "+923" + cellNumNormalized.Substring(cellNumNormalized.Length - 9, 9);
            }
            else
                return null;
        }

        public static string FormatCellNumberOutreach(string cellNumber)
        {
            // Regex.Replace(cellNumber, Constant.CellNumbersDigitsOnly.ToString(), "")

            if (!string.IsNullOrWhiteSpace(cellNumber) && cellNumber.Length >= 10)
            {
                return "92" + cellNumber.Substring(cellNumber.Length - 10);
            }
            else
                return cellNumber;
        }

        public static string FirstCap(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return char.ToUpper(value[0]) + (value.Length > 1 ? value.Substring(1) : "");
        }

        public static string TitleCase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static string CleanSpaces(string value)
        {
            while (value.Contains("  ")) value = value.Replace("  ", "");

            return value.Trim();
        }

        public static string GeneratePassword4DigitNumeric()
        {
            const string chars = "0123456789"; //ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new string(Enumerable.Repeat(chars, 4).Select(s => s[Constant.Rand.Next(s.Length)]).ToArray());
        }

        public static string GeneratePassword4DigitNumericV2()
        {
            return GetRandomString(4, "0123456789");
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

        public static string FriendlyDatePickTime(DateTime utcTime)
        {
            return utcTime.AddHours(5).ToString("MMM dd, hh:mm tt");
        }

        public static string FriendlyDistance(double distanceMetres)
        {
            return Math.Ceiling(distanceMetres / 1000).ToString("0.00");
        }
    }
}
