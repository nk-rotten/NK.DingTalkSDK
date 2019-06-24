using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DingTalk
{
    public static class DateHelper
    {
        /// <summary>
        ///  获取 Unix 时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long GetUnixDate(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalMilliseconds;
        }

        /// <summary>
        /// 时间戳转换为日期
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(long timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return dtStart.AddMilliseconds(timeStamp);
        }
    }
}
