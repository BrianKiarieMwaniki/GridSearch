using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearchApp.Extensions
{
    public static class StringExtensions
    {
        public static string CamelCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            return string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1));
        }
    }
}
