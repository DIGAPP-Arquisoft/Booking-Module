using AutoMapper;
using Booking_Module.Entities;
using Booking_Module.Models.ViewModels;

namespace Booking_Module.Mappings
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Booking, BookingVm>();
        }
    }
}
