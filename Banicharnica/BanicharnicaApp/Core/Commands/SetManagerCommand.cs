namespace BanicharnicaApp.Core.Commands
{
    using App.Core.Contracts;
    using BanicharnicaApp.Core.Contracts;

    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController controller;

        public SetManagerCommand(IManagerController controller)
        {
            this.controller = controller;
        }
        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);

            controller.SetManager(employeeId, managerId);

            return "Manager was set successfully";
        }
    }
}