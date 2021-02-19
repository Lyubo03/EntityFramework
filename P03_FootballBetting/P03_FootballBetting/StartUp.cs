namespace P03_FootballBetting
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new FootballBettingContext();

            context.Database.Migrate();
        }
    }
}