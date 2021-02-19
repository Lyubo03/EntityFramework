namespace Composite
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var GSM = new SingleGift("Phone",256);
            GSM.CalculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var bagerToy = new SingleGift("Bagerche", 289);
            var plainToy = new SingleGift("PlainToy", 587);
            rootBox.Add(bagerToy);
            rootBox.Add(plainToy);

            var childBox = new CompositeGift("ChildBox", 10);
            //Eminem MDF
            var toySoldier = new SingleGift("Eminem", 0);
            childBox.Add(toySoldier);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}