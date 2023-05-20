using Booking_Module.Entities.Common;

namespace Booking_Module.Entities
{
    public class TimeBlock : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}
