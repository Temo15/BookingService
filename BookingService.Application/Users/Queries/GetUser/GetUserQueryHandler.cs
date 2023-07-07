using BookingService.Application.Enums;
using BookingService.Application.Persistance;
using BookingService.Application.Users.Queries.GetUsers;
using MediatR;

namespace BookingService.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IBookingServiceDbContext db;
        public GetUserQueryHandler(IBookingServiceDbContext db) => this.db = db;
        public Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == request.Id && x.DeleteDate == null);
            if(user is null)
            {
                throw new Exception("user does not exists");
            }
            var result = new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EntityName = user.Role == (long)UserTypeEnum.Patient ? "პაციენტი" : "ექიმი"
            };
            return Task.FromResult(result);
        }
    }
}
