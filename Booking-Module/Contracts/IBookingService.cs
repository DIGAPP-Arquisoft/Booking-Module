using Booking_Module.Models;
using Booking_Module.Models.ViewModels;

namespace Booking_Module.Contracts
{
    public interface IBookingService
    {
        Task<int> AddBooking(AddBookingRequest booking);
        Task<List<BookingVm>> GetAll();
        Task<BookingVm> GetById(int bookingId);
        Task<int> PutById(AddBookingRequest request, int bookingId);
        Task DeleteById(int bookingId);
    }
}
