using BookingService.Application.Users.Queries.GetUsers;
using MediatR;

namespace BookingService.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public int Id { get; set; }
    }
}
