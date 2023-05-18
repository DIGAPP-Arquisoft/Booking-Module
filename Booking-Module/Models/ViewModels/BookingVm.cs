namespace Booking_Module.Models.ViewModels
{
    public class BookingVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
    }
}
