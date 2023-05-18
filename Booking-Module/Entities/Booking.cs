namespace Booking_Module.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }
    }
}
