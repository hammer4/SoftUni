using AutoMapper;
using Employees.Models;
using Employees.ModelsDto;

namespace Employees.App
{
    class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeesCount,
                    opt => opt.MapFrom(src => src.ManagedEmployees.Count))
                 .ForMember(dto => dto.EmployeeDtos,
                    opt => opt.MapFrom(src => src.ManagedEmployees));
            CreateMap<Employee, EmployeeManager>()
                .ForMember(dto => dto.ManagerLastName,
                    opt => opt.MapFrom(src => src.Manager.LastName));
        }
    }
}
