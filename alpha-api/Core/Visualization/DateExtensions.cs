using alpha_api.Core.Visualization;
using alpha_api.Models;
using Google.Protobuf.WellKnownTypes;
using System.Globalization;

namespace alpha_api.Core.Visualization
{
    public static class DateExtensions
    {
        public static readonly IEnumerable<string> MONTHS = new List<string>() { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        private static readonly string DATE_FORMAT = "yyyy-MM-dd";

        public static DateTime From(this DateTime date, Resolution resolution) {

            switch (resolution)
            {
                case Resolution.Week: return date.AddDays(-7);
                case Resolution.Month: return date.AddMonths(-1);
                case Resolution.Quarter: return date.AddMonths(-3);
                default: return date;
            }

        }

        public static string String(this DateTime date, bool day = false)
        {
            if (day)
                return date.DayOfWeek.ToString();
            return date.ToString(DATE_FORMAT);
        }

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

        // get/calc units of selected resolution from source values (smallest-unit values)
        // avg: get avg for unit or pick a momentary value
        public static IEnumerable<StatValue<DateTime>> GetDateUnits(this IEnumerable<StatValue<DateTime>> values, Resolution res, bool avg = false)
        {
            var units = new List<StatValue<DateTime>>();
            var unitMap = new Dictionary<Resolution, Func<DateTime, int>>() { 
                 { Resolution.Week, (d) =>  d.Day },
                 { Resolution.Month, (d) => d.IsoWeek() },
                 { Resolution.Quarter, (d) => d.Month }
            };

            var pbreak = unitMap[res](values.ToList().First().Stat);
            var valuesInPeriod = new List<StatValue<DateTime>>();
            var avgs = new List<double>();

            values.ToList().ForEach((v) =>
            {
                valuesInPeriod.Add(v);
                if (unitMap[res](v.Stat) != pbreak)
                {
                    if (avg) // if avg, overwrite Value prop with avg value
                        v.Value = Convert.ToInt32(valuesInPeriod.Select((v) => v.Value).Average());
                    
                    units.Add(v);
                    pbreak = unitMap[res](v.Stat);
                    valuesInPeriod.Clear();
                }
            });
            return units;
        }


        public static string UnitOfResolution(this DateTime date, Resolution res)
        {
            switch (res)
            {
                case (Resolution.Week): return date.DayOfWeek.ToString();
                case (Resolution.Month): return $"W {date.IsoWeek()}";
                case (Resolution.Quarter): return MONTHS.ToList()[date.Month];
            }
            return date.ToString();
        }

    }
}
