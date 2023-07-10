using BookingService.Api.Common.BaseController;
using BookingService.Application.Booking.Command.CreateBooking;
using BookingService.Application.Booking.Command.UpdateBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingService.Api.Controllers
{
    public class BookingController : ApiControllerBase
    {
        public BookingController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [SwaggerOperation("Booking")]
        public Task<ConsultationModel> Create([FromBody] CreateBookingCommand request) => mediator.Send(request);

        [HttpPut]
        [SwaggerOperation("Update-Status")]
        public Task<ConsultationModel> Update(int bookingId, string status) => mediator.Send(new UpdateBookingCommand { BookingId = bookingId, Status = status });

    }
}
