using AutoMapper;
using Booking_Module.Entities;
using Booking_Module.Models.ViewModels;

namespace Booking_Module.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingVm>()
                .ForMember(dest => dest.StartHour, opt => opt.MapFrom(src => src.TimeBlock.StartHour))
                .ForMember(dest => dest.EndHour, opt => opt.MapFrom(src => src.TimeBlock.EndHour));
        }
    }
}
