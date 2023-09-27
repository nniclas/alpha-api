using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Core.Visualization
{
    public static class Extensions
    {
        private static readonly string DATE_FORMAT = "YYYY-MM-DD";

        public static DateTime From(this DateTime date, Resolution resolution) {

            switch (resolution)
            {
                case Resolution.Week: return date.AddDays(-7);
                case Resolution.Month: return date.AddMonths(-1);
                case Resolution.Quarter: return date.AddMonths(-3);
                default: return date;
            }

        }

        public static string String(this DateTime date)
        {
            return date.ToString(DATE_FORMAT);
        }

        // pick every nth of values
        public static IEnumerable<T> Every<T>(this IEnumerable<T> values, int nth) 
        {
            return values.Where((v, i) => i % nth == 0);
        }

        //public static int Stat(this Stat stat, MachinePart part)
        //{

        //    switch (part)
        //    {
        //        case MachinePart.Signal: return stats.SignalStrength;
        //        case MachinePart.Battery: return stats.Battery;
        //        case MachinePart.Processor: return stats.Processor;
        //        default: return 0;
        //    }

        //}
    }
}
