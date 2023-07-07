using BookingService.Application.Common.Interfaces;
using BookingService.Application.Persistance;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Account.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IBookingServiceDbContext db;
        private readonly IFireBaseAuthenticationService firebaseService;
        public RegisterUserCommandHandler(IBookingServiceDbContext db, IFireBaseAuthenticationService firebaseService)
        {
            this.db = db;
            this.firebaseService = firebaseService;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var checkUser = db.Users.Any(x => x.Email == request.Email && x.DeleteDate == null);
            if (checkUser)
            {
                throw new ApplicationException("Email is already registered");
            }
            var user = new User
            {
                FirstName = request.userData.FirstName,
                LastName = request.userData.LastName,
                Email = request.Email,
                Role = request.userData.EntityNo,
            };
            db.Users.Add(user);

            await firebaseService.CreateUserWithEmailAndPasswordAsync(request.Email!, request.Password!, request.userData);

            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
