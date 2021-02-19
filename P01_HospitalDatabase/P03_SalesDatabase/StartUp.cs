namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using P03_SalesDatabase.Data;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SalesDbContext();

            context.Database.Migrate();
        }
    }
}