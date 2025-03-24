using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    public static class Methods
    {
        public static bool Empty(this IEnumerable<object>? list)
        {
            if (list == null)
            {
                return true;
            }

            else if (!list.Any())
            {
                return true;
            }

            return false;
        }

        public static string TrimNullSafe(this string? toCheck)
        {
            if (toCheck == null)
            {
                return string.Empty;
            }

            else
            {
                return toCheck.Trim();
            }
        }
    } 
}
