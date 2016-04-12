
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class RegexHelper
    {
        public static bool IsEmail(this string source)
        {
            Regex reg = new Regex(@"^[\w\._-]*@\w*\.\w{2,3}$");
            return reg.IsMatch(source.TrimNull().ToLower());
        }
    }
}
