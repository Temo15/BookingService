using BookingService.Application.Booking.Command.CreateBooking;
using BookingService.Application.Enums;
using BookingService.Application.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Application.Booking.Command.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, ConsultationModel>
    {
        private readonly IBookingServiceDbContext db;
        public UpdateBookingCommandHandler(IBookingServiceDbContext db) => this.db = db;
        public async Task<ConsultationModel> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var consultationDetails = db.ConsultationDetails.FirstOrDefault(x => x.Id == request.BookingId && x.DeleteDate == null);
            if (consultationDetails == null) throw new Exception("Conslutation does not exists");
            var consultation = db.Consultations.FirstOrDefault(x => x.ConsultationDetailId == consultationDetails.Id);

            var organiser = await db.Users.FirstOrDefaultAsync(x => x.Id == consultationDetails.UserId && x.Role == consultationDetails.Organiser);
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == consultation.UserId);

            consultationDetails.Status = request.Status;
            await db.SaveChangesAsync(cancellationToken);

            return new ConsultationModel
            {
                Id = consultationDetails.Id,
                Patient = organiser.Role == (long)UserTypeEnum.Patient ? organiser.Email : user.Email,
                Doctor = organiser.Role == (long)UserTypeEnum.Doctor ? organiser.Email : user.Email,
                Title = consultationDetails.Title,
                Description = consultationDetails.Description,
                StartDate = consultationDetails.StartDate,
                EndDate = consultationDetails.EndDate,
                Status = consultationDetails.Status,
            };

        }
    }
}
