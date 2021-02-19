namespace BanicharnicaApp.Core.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Banicharnica.Models;
    using BanicharnicaApp.Core.Contracts;
    using BanicharnicaApp.Core.DTOs;
    using System;
    using System.Linq;

    public class ManagerController : IManagerController
    {
        private readonly BanicharnicaContext context;
        private readonly IMapper mapper;
        public ManagerController(BanicharnicaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ManagerDto ManagerInfo(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.Id == employeeId)
                .ProjectTo<ManagerDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id!");
            }

            return employee;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("InvalidId");
            }

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}