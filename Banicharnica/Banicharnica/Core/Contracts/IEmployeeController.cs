using App.Core.DTOs;
using Banicharnica.DTOs;
using System;

namespace App.Core.Contracts
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employeeDto);
        void SetBirthday(int employeeId, DateTime date);
        void SetAddress(int employeeId, string address);
        EmployeeDto GetEmployeeInfo(int employeeId);
        EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId);
    }
}