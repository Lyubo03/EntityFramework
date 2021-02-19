namespace App.Core.Commands
{
    using Contracts;
    using System;

    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController controller;
        public SetBirthdayCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            controller.SetBirthday(employeeId, date);

           return "Birthdate set successfully!";
        }
    }
}