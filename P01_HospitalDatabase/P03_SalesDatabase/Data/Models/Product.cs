﻿namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //TODO: Name unicode
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}