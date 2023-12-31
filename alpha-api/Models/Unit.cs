﻿namespace alpha_api.Models
{
    public class Unit : IEntity
    {
        public int Id { get; set; }
        public string MachineId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }

        public IEnumerable<Entry>? Entries { get; set; }
        public IEnumerable<Stat>? Stats { get; set; }
    }
}
