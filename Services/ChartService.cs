using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    public class ChartService : IChartService
    {
        private readonly IRepository<UnitStats> unitStatsRepository;
        private readonly IRepository<Entry> entryRepository;

        public ChartService(IRepository<UnitStats> unitRepository, IRepository<Entry> entryRepository)
        {
            this.unitStatsRepository = unitStatsRepository;
            this.entryRepository = entryRepository;
        }

        public ChartData GetMachineStatistics(Parameters p, MachinePart part)
        {
            var us = unitStatsRepository.Query((us) => 
                us.Date > p.Date.From(p.Resolution) && us.Date <= p.Date);

            var values = us.Select((us) => 
                new ChartValue { Date = us.Date, Value = us.Stat(part) });
            
            return ChartFactory.GetChart(ChartType.Bar, p, values);
        }

        public ChartData GetEntryStatistics(Parameters p)
        {
            //var test = ChartFactory.GetChart(ChartType.Bar, p);
            throw new NotImplementedException();
            
        }
    }
}
