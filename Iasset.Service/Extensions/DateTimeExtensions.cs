﻿using System;

namespace Iasset.Service.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(unixTimeStamp)
                .ToLocalTime();
        }
    }
}
