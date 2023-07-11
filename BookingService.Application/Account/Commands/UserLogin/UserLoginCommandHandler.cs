using BookingService.Application.Common.Interfaces;
using BookingService.Application.Persistance;
using MediatR;

namespace BookingService.Application.Account.Commands.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand>
    {
        private readonly IBookingServiceDbContext db;
        private readonly IFireBaseAuthenticationService firebaseService;
        public UserLoginCommandHandler(IBookingServiceDbContext db, IFireBaseAuthenticationService firebaseService)
        {
            this.db = db;
            this.firebaseService = firebaseService;
        }
        public async Task Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var checkEmail = db.Users.FirstOrDefault(x => x.Email == request.Email && x.DeleteDate == null);
            if (checkEmail is null)
            {
                throw new Exception("Email does not exists");
            }

            var token = await firebaseService.SignInWithEmailAndPasswordAsync(request.Email, request.Password);
        }
    }
}
