namespace App.Core.Controllers
{
    using App.Core.Contracts;
    using App.Core.DTOs;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Banicharnica.DTOs;
    using System;
    using System.Linq;
    using Banicharnica.Models;

    public class EmployeeController : IEmployeeController
    {
        private readonly BanicharnicaContext context;
        private readonly IMapper mapper;
        public EmployeeController(BanicharnicaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.Id == employeeId)
                .ProjectTo<EmployeeDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees
                        .Where(x => x.Id == employeeId)
                        .ProjectTo<EmployeePersonalInfoDto>()
                        .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Address = address;

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Birthday = date;

            context.SaveChanges();
        }
    }
}