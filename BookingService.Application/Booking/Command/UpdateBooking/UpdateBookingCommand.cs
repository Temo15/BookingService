using BookingService.Application.Booking.Command.CreateBooking;
using MediatR;

namespace BookingService.Application.Booking.Command.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<ConsultationModel>
    {
        public int BookingId { get; set; }
        public string? Status { get; set; }
    }
}
