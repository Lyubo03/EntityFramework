namespace App.Core.Commands
{
    using Banicharnica.DTOs;
    using Contracts;
    using System;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController controller;
        public AddEmployeeCommand(IEmployeeController employeeController)
        {
            this.controller = employeeController;
        }

        public string Execute(string[] args)
        {
            var firstName = args[0];
            var lastName = args[1];
            var salary = decimal.Parse(args[2]);

            EmployeeDto employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.controller.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} was added successfully";
        }
    }
}