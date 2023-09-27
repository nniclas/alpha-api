using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IChartService
    {
        Task<ChartData> GetEntryStatisticsAsync(int unitId, Parameters p);
        Task<ChartData> GetMachineStatisticsAsync(int unitId, Parameters p);
    }
}
