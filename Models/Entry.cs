using alpha_api.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace alpha_api.Models
{
    public class Entry : IEntity
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int? UserId { get; set; }
        public Event Event { get; set; }
        public Measure? Measure { get; set; }
        public Tag Tag { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }

        public Unit? Unit { get; set; }
        public User? User { get; set; }
    }
}
