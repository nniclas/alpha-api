using alpha_api.Core.Visualization;
using System.Collections.Generic;

namespace alpha_api.Core.Visualization
{

    //var p = new Parameters { From = DateTime.Today, To = DateTime.Today };
    //var data = StatFactory.GetStat(StatType.Line, p);

    public enum StatType { Single, Series }
    public enum Resolution { Week, Month, Quarter }
    //public enum MachinePart { Battery, Signal, Processor }

    public class Parameters
    {
        public DateTime Date { get; set; }
        public Resolution Resolution { get; set; }
    }

    public class StatValue
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }

    public static class StatFactory
    {
        public static StatData GetData(StatType type, Parameters p, IEnumerable<StatValue> values)
        {
            switch (type)
            {
                case StatType.Single:
                    return new SingleDataBuilder().Get(p, values);
                case StatType.Series:
                    return new SeriesDataBuilder().Get(p, values);
                default:
                    throw new ApplicationException(string.Format("Type '{0}' cannot be created", type));
            }
        }
    }
}
