﻿namespace Templates.Bread_types
{
    using System;
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat Bread.");
        }
    }
}