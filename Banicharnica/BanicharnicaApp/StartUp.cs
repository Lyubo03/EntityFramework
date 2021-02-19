namespace BanicharnicaApp
{
    using App.Core;
    using App.Core.Contracts;
    using App.Core.Controllers;
    using AutoMapper;
    using Banicharnica.Models;
    using BanicharnicaApp.Core;
    using BanicharnicaApp.Core.Contracts;
    using BanicharnicaApp.Core.Controllers;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureService();

            IEngine engine = new Engine(service);
            engine.Run();
        }
        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<BanicharnicaContext>(opts =>
                            opts.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<BanicharnicaProfile>());

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();

            serviceCollection.AddTransient<ICommandItrepreter, CommandInterpreter>();

            serviceCollection.AddTransient<IManagerController, ManagerController>();

            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}