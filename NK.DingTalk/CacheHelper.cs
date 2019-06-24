using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace NK.DingTalk
{
    public static class CacheHelper
    {
        /// <summary>  
        /// 获取数据缓存  
        /// </summary>  
        /// <param name="cacheKey">键</param>  
        public static T GetCache<T>(string cacheKey)
        {
            var obj = HttpRuntime.Cache.Get(cacheKey);
            return obj == null ? default(T) : JsonConvert.DeserializeObject<T>(Convert.ToString(obj));
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string cacheKey, object objObject)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, JsonConvert.SerializeObject(objObject));
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string cacheKey, object objObject, int timeout = 7200)
        {
            try
            {
                if (objObject == null) return;
                var objCache = HttpRuntime.Cache;
                //相对过期  
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);  
                //绝对过期时间  
                objCache.Insert(cacheKey, JsonConvert.SerializeObject(objObject), null, DateTime.Now.AddSeconds(timeout), TimeSpan.Zero, CacheItemPriority.High, null);
            }
            catch (Exception)
            {
                //throw;  
            }
        }
        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string cacheKey)
        {
            var cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }
        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
