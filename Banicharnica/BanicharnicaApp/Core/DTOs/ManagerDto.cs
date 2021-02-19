namespace BanicharnicaApp.Core.DTOs
{
    using Banicharnica.DTOs;
    using System.Collections.Generic;

    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeDto> employeeDtos { get; set; } = new HashSet<EmployeeDto>();
        public int Count => employeeDtos.Count;
    }
}