namespace alpha_api.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Element { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public Unit? Unit { get; set; }
    }
}
