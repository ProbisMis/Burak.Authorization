using AutoMapper;
using Burak.Authorization.Models.Requests;
using Burak.Authorization.Models.Responses;
using Burak.Authorization.Data.EntityModels;

namespace Burak.Authorization.Business.Mappers
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            /* Appointment Mappers */
            //CreateMap<AppointmentRequest, Data.EntityModels.Appointment>()
            //    .ForMember( x => x.Type, opt => opt.Ignore())
            //    .ForMember(x => x.Status, opt => opt.Ignore())
            //    .ForMember(x => x.Slot, opt => opt.Ignore());
            base.CreateMap<UserRequest, User>().ReverseMap();
            base.CreateMap<UserResponse, User>().ReverseMap();
            //CreateMap<Data.EntityModels.Appointment, AppointmentResponse>();
        }
    }
}