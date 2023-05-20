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

        public async Task<BookingVm> AddBooking(AddBookingRequest bookingData)
        {
            var timeBlock = await _context.TimeBlocks.FirstOrDefaultAsync(tb => tb.Id == bookingData.BlockId);
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = bookingData.UserId,
                EstablishmentId = bookingData.EstablishmentId,
                Date = bookingData.Date,
                TimeBlockId = bookingData.BlockId,
                NumberOfPeople = bookingData.NumberOfPeople,
                CreateAt = DateTime.Now,
                IsActive = true,
                TimeBlock = timeBlock
            };

            _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingVm>(booking);
        }

        public async Task<int> GetBookingCount(string establishmentId, BookingParams @params)
        {
            var bookingCount = await _context.Bookings
            .Where(b => b.EstablishmentId == establishmentId
            && b.TimeBlockId == @params.BlockId 
            && b.Date.Day == @params.Date.Day
            && b.IsActive)
            .SumAsync(b => b.NumberOfPeople);

            return bookingCount;
        }

        public async Task<List<BookingVm>> GetAll()
        {
            var bookings = await _context.Bookings.Where(b => b.IsActive).ToListAsync();
            if (bookings == null)
                throw new NotFoundException("No bookings found");

            return _mapper.Map<List<BookingVm>>(bookings);
        }

        public async Task<BookingVm> GetById(Guid bookingId)
        {
            var booking = await _context.Bookings.Include(b => b.TimeBlock).FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");
            
            return _mapper.Map<BookingVm>(booking);
        }

        public async Task DeleteById(Guid bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> PutById(AddBookingRequest bookingData, Guid bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if(booking == null)
                throw new NotFoundException($"Booking with id {bookingId} was not found");

            booking.UserId = bookingData.UserId;
            booking.EstablishmentId = bookingData.EstablishmentId;
            booking.Date = bookingData.Date;
            booking.TimeBlockId = bookingData.BlockId;
            booking.UpdateAt = DateTime.Now;

            _context.Update(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<List<BookingVm>> GetBokingByUserId(string userId, BookingParams @params)
        {
            var bookings = await _context.Bookings
                .Where(b => b.UserId == userId 
                && b.Date.Day == @params.Date.Day 
                && b.TimeBlockId == @params.BlockId
                && b.IsActive).Include(b => b.TimeBlock).ToListAsync();
            
            return _mapper.Map<List<BookingVm>>(bookings);
        }
    }
}
