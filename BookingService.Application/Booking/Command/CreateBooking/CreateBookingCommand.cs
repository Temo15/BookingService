using MediatR;

namespace BookingService.Application.Booking.Command.CreateBooking
{
    public class CreateBookingCommand : IRequest<ConsultationModel>
    {
        public string? PatientEmail { get; set; }
        public string? DoctorEmail { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long Organiser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }    
}
