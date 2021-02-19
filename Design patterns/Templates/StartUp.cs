namespace Templates
{
    using Templates.Bread_types;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bread sourdough = new Sourdough();
            sourdough.Make();

            Bread twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            Bread wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}