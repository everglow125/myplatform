using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class FormatHelper
    {
        public static bool HasValue(this DataSet source)
        {
            return source == null || source.Tables.Count > 0;
        }

        public static bool HasValue(this DataTable source)
        {
            return source == null || source.Rows.Count > 0;
        }

        public static bool HasValue(this DataRow source, int index, bool allowEmpty = true)
        {
            return source[index] != DBNull.Value && source[index] != null
                && (allowEmpty || source[index].ToString() != string.Empty);
        }

        public static bool HasValue(this DataRow source, string columnName, bool allowEmpty = true)
        {
            return source[columnName] != DBNull.Value && source[columnName] != null
                && (allowEmpty || source[columnName].ToString() != string.Empty);
        }

        public static string TrimNull(this string source)
        {
            if (string.IsNullOrEmpty(source)) return "";
            return source.Trim();
        }

        public static bool IsEmpty(this string source)
        {
            return string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);
        }

        public static DateTime ToDate(this string source)
        {
            return Convert.ToDateTime(source);
        }

        public static string ShortDate(this DateTime source)
        {
            return source.ToString("yyyy-MM-dd");
        }



    }
}
