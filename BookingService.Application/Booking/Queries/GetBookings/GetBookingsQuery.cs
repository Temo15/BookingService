using BookingService.Application.Booking.Command.CreateBooking;
using MediatR;

namespace BookingService.Application.Booking.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<List<ConsultationModel>>
    {
        public string? BookingStatus { get; set; }
        public string Email { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

    }
}
