using alpha_api.Core.Visualization;
using System.Collections.Generic;

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
                    return new LineChartBuilder().GetData(p, values);
                case ChartType.Bar:
                    return new BarChartBuilder().GetData(p, values);
                case ChartType.Pie:
                    return new PieChartBuilder().GetData(p, values);
                default:
                    throw new ApplicationException(string.Format("Type '{0}' cannot be created", type));
            }
        }
    }

    public interface IChartBuilder<TResult>
    {
        public TResult GetData(Parameters p, IEnumerable<ChartValue> values);
    }


    // assume input values are 1 val/day and every existing value in date period


    public class LineChartBuilder : IChartBuilder<LineChartData>
    {
        public LineChartData GetData(Parameters p, IEnumerable<ChartValue> values)
        {
            var nths = new List<dynamic>() {
                new { res= Resolution.Week, nth=1 },
                new { res= Resolution.Month, nth=7 },
                new { res= Resolution.Quarter, nth=3 }
            };
            var result = values.Every((int)nths.Find((rp) => rp.res == p.Resolution)!.nth).ToList();

            return new LineChartData() { 
                Labels = result. Select((cv) => cv.Date.String()), 
                Data = result.Select((cv) => cv.Value),
            };
        }
    }

    public class BarChartBuilder : IChartBuilder<BarChartData>
    {
        public BarChartData GetData(Parameters p, IEnumerable<ChartValue> values)
        {
            throw new NotImplementedException();
        }
    }

    public class PieChartBuilder : IChartBuilder<PieChartData>
    {
        public PieChartData GetData(Parameters p, IEnumerable<ChartValue> values)
        {
            throw new NotImplementedException();
        }
    }
}
