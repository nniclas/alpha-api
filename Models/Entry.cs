using alpha_api.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace alpha_api.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int? UserId { get; set; }
        public Event Event { get; set; }
        public EntryMeasure? Measure { get; set; }
        public EntryTag Tag { get; set; }
        public string? Notes { get; set; }

        [NotMapped]
        public Unit Unit { get; set; }
        [NotMapped]
        public User User { get; set; }
    }
}
