using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace Common
{
    public class CookieHelper
    {
        private static string Get3DesKey()
        {
            return ConfigurationManager.AppSettings["key3des"] ?? "!QA@WS#ED1qa2ws3ed123456";
        }

        public static bool Add(string cookieName, string value, int validHours = 168)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddHours(validHours);
                cookie.Value = EncryptHelper.Encrypt3DES(value, Get3DesKey());
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("Cookie", ex);
                return false;
            }
        }

        public static string Get(string cookieName)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[cookieName] == null) return null;
                var value = HttpContext.Current.Request.Cookies[cookieName].Value;
                return EncryptHelper.Decrypt3DES(value, Get3DesKey());
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("Cookie", ex);
                return null;
            }
        }

        public static void Disable(string cookieName)
        {
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddHours(-1);
        }
    }
}
