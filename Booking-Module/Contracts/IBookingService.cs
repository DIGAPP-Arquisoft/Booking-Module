using Booking_Module.Models;
using Booking_Module.Models.ViewModels;

namespace Booking_Module.Contracts
{
    public interface IBookingService
    {
        Task<BookingVm> AddBooking(AddBookingRequest booking);
        Task<GetCountBookingsResponse> GetBookingCount(string establishmentId, BookingParams @params);
        Task<List<BookingVm>> GetAll();
        Task<BookingVm> GetById(Guid bookingId);
        Task<Guid> PutById(AddBookingRequest request, Guid bookingId);
        Task DeleteById(Guid bookingId);
        Task<List<BookingVm>> GetBokingByUserId(string userId, BookingParams @params);
    }
}
