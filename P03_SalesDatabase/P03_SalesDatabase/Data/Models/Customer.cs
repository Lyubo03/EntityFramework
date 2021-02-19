﻿namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(80)]
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}