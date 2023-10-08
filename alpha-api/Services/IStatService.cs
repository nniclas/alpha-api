using alpha_api.Core.Enums;
using alpha_api.Core.Visualization;
using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IStatService
    {
        Task<Dictionary<string, StatData>> GetMachineStatisticsAsync(int unitId, Parameters p);
        Task<StatData> GetEntryStatisticsAsync(int unitId, Parameters p);
    }
}
