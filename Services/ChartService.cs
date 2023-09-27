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

        public ChartData GetMachineStatistics(int unitId, Parameters p)
        {
            var stats = statRepository.Query((s) => 
                s.UnitId == unitId &&
                s.Element == element &&
                s.Date > p.Date.From(p.Resolution) && s.Date <= p.Date);

            var values = stats.Select((s) => 
                new ChartValue { Date = s.Date, Value = s.Value });
            
            return ChartFactory.GetChart(ChartType.Line, p, values);
        }

        public ChartData GetEntryStatistics(int unitId, Parameters p)
        {
            //var test = ChartFactory.GetChart(ChartType.Bar, p);
            throw new NotImplementedException();
            
        }
    }
}
