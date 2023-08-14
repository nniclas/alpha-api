namespace alpha_api.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string MachineId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }

        public IEnumerable<Entry>? Entries { get; set; }
    }
}
