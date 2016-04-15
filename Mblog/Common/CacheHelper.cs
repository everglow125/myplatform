using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Common
{
    public class CacheHelper
    {
        public static void Add<T>(string key, T value, int seconds = 1440)
        {
            HttpContext.Current.Cache.Insert("GridViewDataSet ", value, null, DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration);
        }

        public static T Get<T>(string key) where T : class
        {
            if (HttpContext.Current.Cache[key] == null) return default(T);
            return HttpContext.Current.Cache[key] as T;
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Cache[key] != null)
                HttpContext.Current.Cache.Remove(key);
        }
    }
}
