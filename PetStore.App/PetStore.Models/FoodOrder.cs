﻿using PetStore.Models.Foods;

namespace PetStore.Models
{
    public class FoodOrder
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int OrderId { get; set; }
        public Order Order{get;set;}
    }
}