using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    public class StatService : IStatService
    {
        private readonly IRepository<Stat> statRepository;
        private readonly IRepository<Entry> entryRepository;

        public StatService(IRepository<Stat> statRepository, IRepository<Entry> entryRepository)
        {
            this.statRepository = statRepository;
            this.entryRepository = entryRepository;
        }

        public async Task<StatData> GetMachineStatisticsAsync(int unitId, Parameters p)
        {
            var stats = await statRepository.QueryAsync((s) => 
                s.UnitId == unitId &&
                //s.Element == element &&
                s.Date > p.Date.From(p.Resolution) && s.Date <= p.Date);
            
            var values = stats.Select((s) => 
                new StatValue { Date = s.Date, Value = s.Value });
            
            return StatFactory.GetData(StatType.Single, p, values);
        }

        public async Task<StatData> GetEntryStatisticsAsync(int unitId, Parameters p)
        {
            //var test = StatFactory.GetStat(StatType.Bar, p);
            throw new NotImplementedException();
            
        }
    }
}
