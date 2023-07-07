using BookingService.Application.Persistance;
using BookingService.Application.Users.Queries.GetUsers;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Booking.Command.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ConsultationModel>
    {
        private readonly IBookingServiceDbContext db;
        public CreateBookingCommandHandler(IBookingServiceDbContext db) => this.db = db;
        public Task<ConsultationModel> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            //request ?? throw new Exception();
            //if (request == null) throw new Exception();

            //foreach (var user in request.Users)
            //{
            //    var patient = new UserModel
            //    {
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //    }
            //}


            //var consultation = new ConsultationDetails
            //{

            //}
            throw new NotImplementedException();
        }
    }
}
