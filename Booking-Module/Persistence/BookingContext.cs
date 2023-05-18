using Booking_Module.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking_Module.Persistence
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
