namespace CasSystem.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Model;
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxName)]
        public string Name { get; set; }
        [MaxLength(MaxModification)]
        public string Modification { get; set; }
        public int Year { get; set; }
        public int MakeID { get; set; }
        public Make Make { get; set; }
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}