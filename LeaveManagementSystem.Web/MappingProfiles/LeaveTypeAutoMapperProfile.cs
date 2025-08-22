using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
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
