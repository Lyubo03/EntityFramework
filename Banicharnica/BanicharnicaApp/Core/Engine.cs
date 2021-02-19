namespace App.Core
{
    using Contracts;
    using Services.Contracts;
    using System;
    using Microsoft.Extensions.DependencyInjection;
 
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeDb = serviceProvider.GetService<IDbInitializerService>();
            initializeDb.IntializeDatabase();

            var commandInterpreter = this.serviceProvider.GetService<ICommandItrepreter>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string result = commandInterpreter.Read(input);

                Console.WriteLine(result);

            }
        }
    }
}