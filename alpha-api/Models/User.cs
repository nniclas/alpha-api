﻿namespace alpha_api.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Hash { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Access { get; set; }

        public IEnumerable<Entry>? Entries { get; set; }
    }
}
