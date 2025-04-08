using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverter.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ParseCustom(this string input)
        {
            if (DateTime.TryParse(input, out DateTime result))
            {
                result = result.Date;
                return result.ToString("yyyy-MM-dd");
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
