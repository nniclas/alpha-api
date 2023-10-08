namespace alpha_api.Core.Visualization
{
    //public interface IStatBuilder<TResult>
    //{
    //    public TResult Get(Parameters p, IEnumerable<StatValue> values);
    //}

    //// assume input values are 1 val/day and every existing value in date period


    public class SinglePeriodDataBuilder
    {
        public StatData Get(Parameters p, IEnumerable<StatValue<DateTime>> values, bool unitsOfRes = false)
        {
           
            var result = values.GetDateUnits(p.Resolution, true);

            //var result = values.Every((int)nths.Find((rp) => rp.res == p.Resolution)!.nth).ToList();

            return new StatData
            {
                Data = result.Select((sv) => sv.Value),
                Titles = result.Select((sv) => unitsOfRes ? sv.Stat.UnitOfResolution(p.Resolution) : sv.Stat.String()),
            };
        }
    }

    public class SeriesPeriodDataBuilder
    {
        public SeriesStatData Get(Parameters p, IEnumerable<StatValue<DateTime>> values, bool dayTitles = false)
        {
            throw new NotImplementedException();
        }
    }
}
