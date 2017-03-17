using System;

namespace Iasset.Service.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTime(double unixTimeStamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
