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
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }    
}
