using alpha_api.Core.Visualization;

namespace alpha_api.Core.Visualization
{
    public abstract class ChartData
    {
        public IEnumerable<string> Labels { get; set; }
    }

    public class LineChartData : ChartData
    {
        public IEnumerable<int> Data { get; set; }
    }

    public class BarChartData : ChartData
    {
        public IEnumerable<IEnumerable<int>> Data { get; set; }
        public IEnumerable<string> PartNames { get; set; }
    }

    public class PieChartData : ChartData
    {
        public IEnumerable<int> Data { get; set; }
        public int Total { get; set; }
    }
}
