using BookingService.Application.Enums;
using BookingService.Application.Persistance;
using MediatR;

namespace BookingService.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserModel>>
    {
        private readonly IBookingServiceDbContext db;
        public GetUsersQueryHandler(IBookingServiceDbContext db) => this.db = db;
        public Task<List<UserModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = db.Users.Where(x => x.DeleteDate == null
                                   && (request.LastName == null || x.LastName == request.LastName)
                                   && (request.FirstName == null || x.FirstName == request.FirstName)
                                   && (request.EntityNo == null || x.Role == request.EntityNo))
                               .Select(x => new UserModel
                               {
                                   Id = x.Id,
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   EntityName = x.Role == (long)UserTypeEnum.Patient ? "პაციენტი" : "ექიმი",
                               }).ToList();

            return Task.FromResult(query);
        }
    }
}
