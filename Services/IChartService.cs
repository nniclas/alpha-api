using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IChartService
    {
        ChartData GetEntryStatistics(Parameters p);
        ChartData GetMachineStatistics(Parameters p, string element);
    }
}
