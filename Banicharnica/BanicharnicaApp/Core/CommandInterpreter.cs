namespace App.Core
{
    using Contracts;
    using System;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandItrepreter
    {
        private readonly IServiceProvider serviceProvider;
        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public string Read(string[] input)
        {
            string commandName = input[0] + "Command";

            var args = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var constructor = type.GetConstructors().First();

            var constructorParameters = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var service = constructorParameters
                .Select(serviceProvider.GetService)
                .ToArray();


            var command = (ICommand)constructor.Invoke(service);

            string result = command.Execute(args);
            
            return result;
        }
    }
}