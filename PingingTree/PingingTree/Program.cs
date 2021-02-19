namespace PingingTree
{
    using System;
    using System.Drawing;

    public class Program
    {
        private static Random r = new Random();

        public static void Triangle(int n)
        {
            int spacesLeft = n / 2 - 1;
            int stars = 1;

            for (int i = 1; i <= n / 2; i++)
            {
                Console.Write(new string(' ', spacesLeft));
                Console.WriteLine(new string('o', stars));

                spacesLeft--;
                stars += 2;
            }
        }
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int n = int.Parse(Console.ReadLine());
            Console.Clear();
            Triangle(n);

            while (true)
            {
                int stars = 1;
                int spacesLeft = n / 2 - 1;

                for (int i = 0; i < n / 2; i++)
                {
                    Console.CursorVisible = false;
                    Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                    Console.SetCursorPosition(r.Next(spacesLeft, spacesLeft + stars), i);
                    Console.Write('o');

                    spacesLeft--;
                    stars += 2;
                }

            }
        }
    }
}
//while (true)
//            {
//                Console.ForegroundColor = (ConsoleColor) r.Next(0, 16);
//Console.CursorTop = 1;
//                Triangle(n);

//Thread.Sleep(1000);
//            }20