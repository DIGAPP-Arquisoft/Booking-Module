namespace Booking_Module.Models
{
    public class AddBookingRequest
    {
        public string UserId { get; set; }
        public string EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public int BlockId { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
