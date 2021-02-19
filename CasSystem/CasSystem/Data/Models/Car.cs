namespace CasSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using static DataValidation.Car;

    public class Car
    {
        public int Id { get; set; }
        public DateTime Factoring { get; set; }
        [Required]
        [MaxLength(VinLength)]
        public string Vin { get; set; }
        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; }
        public double Price { get; set;  }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<CarPurchase> Purchases { get; set; } = new HashSet<CarPurchase>();
    }
}
