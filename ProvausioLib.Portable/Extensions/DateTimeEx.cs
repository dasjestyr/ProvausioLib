using System;

namespace ProvausioLib.Portable.Extensions
{
    public static class DateTimeEx
    {
        public static bool IsSameDay(this DateTime baseDate, DateTime compareDate)
        {
            return baseDate.Date == compareDate.Date;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}