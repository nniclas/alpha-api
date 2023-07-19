using alpha_api.Core.Enums;

namespace alpha_api.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int? Measure { get; set; }
        public EntryTag Tag { get; set; }
        public string? Notes { get; set; } 
    }
}
