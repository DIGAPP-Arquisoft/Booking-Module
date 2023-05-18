namespace Booking_Module.Models
{
    public class AddBookingRequest
    {
        public int UserId { get; set; }
        public int EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
