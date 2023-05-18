using AutoMapper;
using Booking_Module.Contracts;
using Booking_Module.Entities;
using Booking_Module.Exceptions;
using Booking_Module.Models;
using Booking_Module.Models.ViewModels;
using Booking_Module.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Booking_Module.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingContext _context;
        private readonly IMapper _mapper;

        public BookingService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddBooking(AddBookingRequest bookingData)
        {
            var bookingCount = await GetBookingCountByDay(bookingData.Date);
            if (bookingCount == bookingData.NumberOfPeople)
                throw new BadRequestException($"The Establishment with id {bookingData.EstablishmentId} has no space available");

            var booking = new Booking
            {
                UserId = bookingData.UserId,
                EstablishmentId = bookingData.EstablishmentId,
                Date = bookingData.Date,
                Hour = bookingData.Hour,
                CreateAt = DateTime.Now
            };

            _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking.Id;
        }

        public async Task<List<BookingVm>> GetAll()
        {
            var bookings = await _context.Bookings.Where(b => b.IsActive).ToListAsync();
            if (bookings == null)
                throw new NotFoundException("No bookings found");

            return _mapper.Map<List<BookingVm>>(bookings);
        }

        public async Task<BookingVm> GetById(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");
            
            return _mapper.Map<BookingVm>(booking);
        }

        public async Task DeleteById(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<int> PutById(AddBookingRequest bookingData, int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if(booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");

            var bookingCount = await GetBookingCountByDay(bookingData.Date);
            if (bookingCount == bookingData.NumberOfPeople)
                throw new BadRequestException($"The Establishment with id {bookingData.EstablishmentId} has no space available");

            booking.UserId = bookingData.UserId;
            booking.EstablishmentId = bookingData.EstablishmentId;
            booking.Date = bookingData.Date;
            booking.Hour = bookingData.Hour;
            booking.UpdateAt = DateTime.Now;

            _context.Update(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        private async Task<int> GetBookingCountByDay(DateTime bookingDate)
        {
            var bookingCount = await _context.Bookings.Where(b => b.Date.Day == bookingDate.Day).CountAsync();
            return bookingCount;
        }
    }
}
