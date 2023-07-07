using MediatR;

namespace BookingService.Application.Account.Commands.UserLogin
{
    public class UserLoginCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
