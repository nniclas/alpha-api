using alpha_api.Core.Enums;
using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

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

        // split into dictionary by machine element
        public async Task<Dictionary<string, StatData>> GetMachineStatisticsAsync(int unitId, Parameters p)
        {
            var stats = await statRepository.QueryAsync((s) => 
                s.UnitId == unitId &&
                s.Date > p.Date.From(p.Resolution) && s.Date <= p.Date);
            
            return stats.DistinctBy(x => x.Element).Select((st) =>
                new KeyValuePair<string, StatData>(
                    st.Element, StatFactory.GetPeriodData(
                        StatType.Single, 
                        p, 
                        stats
                            .Where((v) => v.Element == st.Element)
                            .Select((v) => new StatValue<DateTime> { Stat = v.Date, Value = v.Value })
                    ,true)
                )
            ).ToDictionary(x => x.Key, x => x.Value);
        }
        
        public async Task<StatData> GetEntryStatisticsAsync(int unitId, Parameters p)
        {
            var entries = await entryRepository.QueryAsync((e) =>
                 e.UnitId == unitId &&
                 e.Date > p.Date.From(p.Resolution) && e.Date <= p.Date);

            var sValues = ((Event[])Enum.GetValues(typeof(Event))).Select((e) =>
            {
                return new StatValue<Event>() { 
                    Stat = e, 
                    Value = entries.Count((x) => x.Event == e) 
                };
            });

            return new StatData
            {
                Data = sValues.Select((sv) => sv.Value),
                Titles = sValues.Select((sv) => sv.Stat.ToString())
            };
        }
    }
}
