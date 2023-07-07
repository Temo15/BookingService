using BookingService.Api.Common.BaseController;
using BookingService.Application.Users.Queries.GetUser;
using BookingService.Application.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingService.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [SwaggerOperation("Users")]
        public Task<List<UserModel>> Get([FromQuery] GetUsersQuery request) => mediator.Send(request);

        [HttpGet("UserId")]
        [SwaggerOperation("User")]
        public Task<UserModel> GetUser(int Id) => mediator.Send(new GetUserQuery { Id = Id });
    }
}
