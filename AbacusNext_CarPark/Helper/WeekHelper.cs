using System;

namespace AbacusNext_CarPark.Helper
{
    public class WeekHelper
    {
        public static bool IsWeekday(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static DateTime MoveNextDay(DateTime date)
        {
            return date.AddDays(1);
        }

        public static DateTime MoveToEndOfDay(DateTime date)
        {
            return date.AddHours(10);
        }
    }
}
