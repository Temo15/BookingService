using BookingService.Api.Common.BaseController;
using BookingService.Application.Account.Commands.RegisterUser;
using BookingService.Application.Account.Commands.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingService.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(IMediator mediator) : base(mediator) { }

        [HttpPost("Register")]
        [SwaggerOperation("RegisterUser")]
        public async Task RegisterUser([FromBody] RegisterUserCommand request) => await mediator.Send(request);

        [HttpPost("Login")]
        [SwaggerOperation("UserLogin")]
        public Task Login([FromBody] UserLoginCommand request) => mediator.Send(request);
    }
}