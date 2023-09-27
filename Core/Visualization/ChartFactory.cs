using alpha_api.Core.Visualization;

namespace alpha_api.Core.Visualization
{

    //var p = new Parameters { From = DateTime.Today, To = DateTime.Today };
    //var data = ChartFactory.GetChart(ChartType.Line, p) as ILineChartData;

    public enum ChartType { Line, Bar, Pie }
    public enum Resolution { Week, Month, Quarter }
    //public enum MachinePart { Battery, Signal, Processor }

    public class Parameters
    {
        public DateTime Date { get; set; }
        public Resolution Resolution { get; set; }
    }

    public class ChartValue
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }

    public static class ChartFactory
    {
        public static ChartData GetChart(ChartType type, Parameters p, IEnumerable<ChartValue> values)
        {
            switch (type)
            {
                case ChartType.Line:
                    return new LineChartBuilder().GetData(p);
                case ChartType.Bar:
                    return new BarChartBuilder().GetData(p);
                case ChartType.Pie:
                    return new PieChartBuilder().GetData(p);
                default:
                    throw new ApplicationException(string.Format("Type '{0}' cannot be created", type));
            }
        }
    }

    public interface IChartBuilder<TResult>
    {
        public TResult GetData(Parameters p);
    }


    public class LineChartBuilder : IChartBuilder<LineChartData>
    {
        public LineChartData GetData(Parameters p)
        {
            throw new NotImplementedException();
        }
    }

    public class BarChartBuilder : IChartBuilder<BarChartData>
    {
        public BarChartData GetData(Parameters p)
        {
            throw new NotImplementedException();
        }
    }

    public class PieChartBuilder : IChartBuilder<PieChartData>
    {
        public PieChartData GetData(Parameters p)
        {
            throw new NotImplementedException();
        }
    }
}
