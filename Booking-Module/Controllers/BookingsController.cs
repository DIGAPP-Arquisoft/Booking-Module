using Booking_Module.Contracts;
using Booking_Module.Models;
using Booking_Module.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Module.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(AddBookingRequest request)
            => Ok(await _bookingService.AddBooking(request));

        [HttpGet]
        public async Task<ActionResult<List<BookingVm>>> GetAll()
            => Ok(await _bookingService.GetAll());

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<BookingVm>> GetById(int bookingId)
            => Ok(await _bookingService.GetById(bookingId));

        [HttpPut("{bookingId}")]
        public async Task<ActionResult<int>> PutById([FromBody] AddBookingRequest request, int bookingId)
            => Ok(await _bookingService.PutById(request, bookingId));

        [HttpDelete("{bookingId}")]
        public async Task<ActionResult> DeleteById(int bookingId)
        {
            await _bookingService.DeleteById(bookingId);
            return NoContent();
        }
    }
}
