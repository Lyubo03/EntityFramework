namespace Templates.Bread_types
{
    using System;
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the 12-grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-grain Bread.");
        }
    }
}