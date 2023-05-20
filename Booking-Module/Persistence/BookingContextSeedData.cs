using Booking_Module.Entities;
using Booking_Module.Entities.Common;

namespace Booking_Module.Persistence
{
    public class BookingContextSeedData
    {
        public static async Task LoadDataAsync(BookingContext context)
        {
            if (!context.TimeBlocks.Any())
            {
                context.TimeBlocks!.AddRange(GetDefaultTimeBlocks());
                await context.SaveChangesAsync();
            }
        }

        public static IEnumerable<TimeBlock> GetDefaultTimeBlocks()
        {
            return new List<TimeBlock> 
            { 
                new TimeBlock
                {
                    Name = "Mañana",
                    StartHour = "7:00 AM",
                    EndHour = "1:00 PM",
                    CreateAt = DateTime.Now,
                    IsActive = true
                },
                new TimeBlock
                {
                    Name = "Tarde",
                    StartHour = "2:00 PM",
                    EndHour = "8:00 PM",
                    CreateAt = DateTime.Now,
                    IsActive = true
                }
            };
        }
    }
}
