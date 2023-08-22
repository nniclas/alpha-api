using System;
using System.Globalization;

namespace alpha_api.Core
{
    public static class DateExtensions
    {
        public static int IsoWeek(this DateTime date)
        {
            return ISOWeek.GetWeekOfYear(date);
        }

        // from YYYY-WW to DateTime
        public static DateTime ToDateTime(this string yearWeek, DayOfWeek dow)
        {
            //var cal = new CultureInfo("en-US").Calendar;
            var yw = yearWeek.Split(new char[] { '-' }, 2);
            return ISOWeek.ToDateTime(Convert.ToInt32(yw[0]), Convert.ToInt32(yw[1]), dow);
        }

    }
}
