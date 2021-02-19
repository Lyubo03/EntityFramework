namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public int CountryId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}