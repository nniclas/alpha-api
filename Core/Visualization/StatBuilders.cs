namespace alpha_api.Core.Visualization
{
    //public interface IStatBuilder<TResult>
    //{
    //    public TResult Get(Parameters p, IEnumerable<StatValue> values);
    //}

    //// assume input values are 1 val/day and every existing value in date period


    public class SingleDataBuilder
    {
        public StatData Get(Parameters p, IEnumerable<StatValue> values)
        {
            var nths = new List<dynamic>() {
                new { res= Resolution.Week, nth=1 },
                new { res= Resolution.Month, nth=7 },
                new { res= Resolution.Quarter, nth=3 }
            };
            var result = values.Every((int)nths.Find((rp) => rp.res == p.Resolution)!.nth).ToList();

            return new StatData()
            {
                Data = result.Select((cv) => cv.Value),
                Titles = result.Select((cv) => cv.Date.String()),
            };
        }
    }

    public class SeriesDataBuilder
    {
        public SeriesStatData Get(Parameters p, IEnumerable<StatValue> values)
        {
            throw new NotImplementedException();
        }
    }
}
