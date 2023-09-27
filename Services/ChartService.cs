using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    public class ChartService : IChartService
    {
        private readonly IRepository<Stat> statRepository;
        private readonly IRepository<Entry> entryRepository;

        public ChartService(IRepository<Stat> statRepository, IRepository<Entry> entryRepository)
        {
            this.statRepository = statRepository;
            this.entryRepository = entryRepository;
        }

        public async Task<ChartData> GetMachineStatisticsAsync(int unitId, Parameters p)
        {
            var stats = await statRepository.QueryAsync((s) => 
                s.UnitId == unitId &&
                //s.Element == element &&
                s.Date > p.Date.From(p.Resolution) && s.Date <= p.Date);
            
            var values = stats.Select((s) => 
                new ChartValue { Date = s.Date, Value = s.Value });
            
            return ChartFactory.GetChart(ChartType.Line, p, values);
        }

        public async Task<ChartData> GetEntryStatisticsAsync(int unitId, Parameters p)
        {
            //var test = ChartFactory.GetChart(ChartType.Bar, p);
            throw new NotImplementedException();
            
        }
    }
}
