namespace Design_patterns
{
    using System;
    public class Sandwich : SandwichPrototype
    {
        private string meat;
        private string veggies;
        private string bread;
        private string cheese;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        public override SandwichPrototype Clone()
        {
            string ingridients = GetIngridients();

            Console.WriteLine("Cloning sandwich with ingredients: {0}", ingridients);

            return MemberwiseClone() as Sandwich;
        }

        public string GetIngridients()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}