using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IChartService
    {
        ChartData GetEntryStatistics(int unitId, Parameters p);
        ChartData GetMachineStatistics(int unitId, Parameters p, string element);
    }
}
