namespace BanicharnicaApp.Core.Commands
{
    using App.Core.Contracts;
    using System;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public EmployeePersonalInfoCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);

           var empDto = controller.GetEmployeePersonalInfo(employeeId);

            var result = @$"ID: {employeeId} - {empDto.FirstName} {empDto.LastName} - ${empDto.Salary}{Environment.NewLine}Birthday: {empDto.Birthday}{Environment.NewLine}Address: {empDto.Address}";

            return result;
        }
    }
}