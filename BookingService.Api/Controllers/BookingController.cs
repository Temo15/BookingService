using BookingService.Api.Common.BaseController;
using BookingService.Application.Booking.Command.CreateBooking;
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
    }
}
