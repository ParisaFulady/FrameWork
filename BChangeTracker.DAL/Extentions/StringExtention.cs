using System;
using System.Collections.Generic;
using System.Text;

namespace BChangeTracker.DAL.Extentions
{
    public static class StringExtention
    {
        public const char ArabicKeChar = 'ﻛ';
        public const char ArabicYeChar1 = 'ي';
        public const char ArabicYeChar2 = 'ي';
        public const char PersionKeChar = 'ک';
        public const char PersionYeChar = 'ی';

        public static string SetPersionYeKe(this string input)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>
            {

                ["ي"] = "ی",
                ["ﻛ"] = "ک",
                ["ی"] = "ی"
            };
            foreach (var item in keyValues)
            {
                input = input.Replace(item.Key, item.Value);
            }
            return input;
        }
    }
}
