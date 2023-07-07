using BookingService.Application.Enums;
using MediatR;

namespace BookingService.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserModel>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long EntityNo { get; set; }
    }
    public class UserModel
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
