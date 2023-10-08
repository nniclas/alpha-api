using alpha_api.Core.Visualization;
using System.Collections.Generic;

namespace alpha_api.Core.Visualization
{
    public enum StatType { Single, Series }
    public enum Resolution { Week, Month, Quarter }

    public class Parameters
    {
        public DateTime Date { get; set; }
        public Resolution Resolution { get; set; }
    }

    public class StatValue<T>
    {
        public T Stat { get; set; }
        public int Value { get; set; }
    }

    public static class StatFactory
    {
        public static StatData GetPeriodData(StatType type, Parameters p, IEnumerable<StatValue<DateTime>> values, bool unitsOfRes = false)
        {
            switch (type)
            {
                case StatType.Single:
                    return new SinglePeriodDataBuilder().Get(p, values, unitsOfRes);
                case StatType.Series:
                    return new SeriesPeriodDataBuilder().Get(p, values, unitsOfRes);
                default:
                    throw new ApplicationException(string.Format("Type '{0}' cannot be created", type));
            }
        }
    }
}
