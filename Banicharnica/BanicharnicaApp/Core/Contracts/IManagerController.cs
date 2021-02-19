namespace BanicharnicaApp.Core.Contracts
{
    using BanicharnicaApp.Core.DTOs;

    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);
        ManagerDto ManagerInfo(int employeeId);
    }
}