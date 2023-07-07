using BookingService.Application.Account.Commands.RegisterUser.Models;
using MediatR;

namespace BookingService.Application.Account.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserDataModel userData { get; set; }
    }
}
