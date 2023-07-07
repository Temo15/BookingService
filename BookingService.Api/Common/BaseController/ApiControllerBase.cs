using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Common.BaseController
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;
        public ApiControllerBase(IMediator mediator) => this.mediator = mediator;
    }
}
