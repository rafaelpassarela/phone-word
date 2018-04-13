using System.Collections.Generic;
using System.Text;

namespace phone_word
{
    public static class PhoneTranslator
    {
        public static string ToNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";
            else
                value = value.ToUpperInvariant();

            var number = new StringBuilder();
            foreach (var c in value)
            {
                if (" -0123456789".Contains(c))
                {
                    number.Append(c);
                }
                else
                {
                    var res = TranslateToNumber(c);

                    if (res != null)
                        number.Append(res);
                }
            }

            return number.ToString();
        }

        static bool Contains(this string text, char c)
        {
            return text.IndexOf(c) > 0;
        }

        static int? TranslateToNumber(char c)
        {
            var combinations = new List<string>
            {
                "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
            };

            for (int i = 0; i < combinations.Count; i++)
            {
                var item = combinations[i];
                if (item.Contains(c))
                    return i + 2;
            }

            return null;
        }
    }
}