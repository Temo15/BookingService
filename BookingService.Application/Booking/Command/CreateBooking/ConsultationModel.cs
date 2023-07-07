using BookingService.Application.Users.Queries.GetUsers;

namespace BookingService.Application.Booking.Command.CreateBooking
{
    public class ConsultationModel
    {
        public List<UserModel> Users { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long Organiser { get; set; }
        public int Status { get; set; }
        public string? StatusComment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
