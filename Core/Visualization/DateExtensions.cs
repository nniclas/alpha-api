using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Core.Visualization
{
    public static class DateExtensions
    {
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

        // pick every nth of values
        public static IEnumerable<T> Every<T>(this IEnumerable<T> values, int nth) 
        {
            return values.Where((v, i) => i % nth == 0);
        }
    }
}
