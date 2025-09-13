using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Application.Models.LeaveTypes;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            CreateMap<LeaveTypeCreateVM, LeaveType>();
            // This basically take Type A and map it to Type B and vice versa
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();

        }
    }
}
