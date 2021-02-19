namespace Design_patterns
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "PB, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey ,Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Bacon, Turkey, Ham, Salami", "Provolone", "Lettuce, Tomato");
            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives");

            Sandwich sandwichBLT = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwichThreeMeatCombo= sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich sandwichVegeterian = sandwichMenu["Vegetarian"].Clone() as Sandwich;
        }
    }
}