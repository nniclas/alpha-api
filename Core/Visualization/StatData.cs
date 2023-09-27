using alpha_api.Core.Visualization;

namespace alpha_api.Core.Visualization
{
    public class StatData
    {
        public IEnumerable<int> Data { get; set; }
        public IEnumerable<string> Titles { get; set; }
    }

    public class SeriesStatData : StatData
    {
        public IEnumerable<StatData> DataSeries { get; set; }
    }
}
