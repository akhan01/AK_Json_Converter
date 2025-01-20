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
        public static DateTime? ParseCustom(this string input)
        {
            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
