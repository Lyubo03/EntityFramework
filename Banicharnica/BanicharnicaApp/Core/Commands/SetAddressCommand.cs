namespace BanicharnicaApp.Core.Commands
{
    using App.Core.Contracts;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController controller;

        public SetAddressCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var address = args[1];

            controller.SetAddress(employeeId, address);

            return "Adress set successfully";
        }
    }
}