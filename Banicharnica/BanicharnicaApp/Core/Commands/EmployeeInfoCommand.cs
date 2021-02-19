namespace BanicharnicaApp.Core.Commands
{
    using App.Core.Contracts;
    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public EmployeeInfoCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);

            var empDto = controller.GetEmployeeInfo(employeeId);

            return $@"ID: {employeeId} - {empDto.FirstName} {empDto.LastName} -  ${empDto.Salary:F2}";
        }
    }
}