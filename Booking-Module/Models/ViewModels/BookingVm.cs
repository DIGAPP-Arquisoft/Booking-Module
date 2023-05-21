namespace Booking_Module.Models.ViewModels
{
    public class BookingVm
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public string StartHour{ get; set; }
        public string EndHour{ get; set; }
    }
}
