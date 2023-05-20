using Booking_Module.Entities.Common;

namespace Booking_Module.Entities
{
    public class Booking : Entity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public int TimeBlockId { get; set; }
        public virtual TimeBlock TimeBlock { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
