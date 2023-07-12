namespace BookingService.Application.Booking.Command.CreateBooking
{
    public class ConsultationModel
    {
        public int Id { get; set; }
        public string? Patient { get; set; }
        public string? Doctor { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? StatusComment { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
