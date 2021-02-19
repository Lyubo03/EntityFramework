namespace Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

        public void Remove(GiftBase gift)
        {
            if (!gifts.Contains(gift))
            {
                throw new InvalidOperationException("There is no such a gift!");
            }
            gifts.Remove(gift);
        }
    }
}