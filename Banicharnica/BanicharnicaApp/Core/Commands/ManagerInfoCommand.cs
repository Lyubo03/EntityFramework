namespace BanicharnicaApp.Core.Commands
{
    using App.Core.Contracts;
    using BanicharnicaApp.Core.Contracts;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController controller;

        public ManagerInfoCommand(IManagerController controller)
        {
            this.controller = controller;
        }
        public string Execute(string[] args)
        {
            var sb = new StringBuilder();
            var employeeId = int.Parse(args[0]);

            var manager = controller.ManagerInfo(employeeId);

            sb.AppendLine($"{manager.FirstName} | Employees: {manager.Count}");

            foreach (var emp in manager.employeeDtos)
            {
                sb.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}