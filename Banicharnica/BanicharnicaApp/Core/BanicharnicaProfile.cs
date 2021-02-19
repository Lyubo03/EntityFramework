namespace BanicharnicaApp.Core
{
    using App.Core.DTOs;
    using AutoMapper;
    using Banicharnica.DTOs;
    using Banicharnica.Models;
    using BanicharnicaApp.Core.DTOs;
    using System.Security.Cryptography;

    public class BanicharnicaProfile : Profile
    {
        public BanicharnicaProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.employeeDtos, from => from.MapFrom(x => x.ManagerEmployee))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}