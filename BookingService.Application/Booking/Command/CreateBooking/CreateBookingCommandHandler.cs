using BookingService.Application.Enums;
using BookingService.Application.Persistance;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Booking.Command.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ConsultationModel>
    {
        private readonly IBookingServiceDbContext db;
        public CreateBookingCommandHandler(IBookingServiceDbContext db) => this.db = db;
        public async Task<ConsultationModel> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new Exception();

            var patient = db.Users.FirstOrDefault(x => x.Email == request.PatientEmail && x.DeleteDate == null);
            var doctor = db.Users.FirstOrDefault(x => x.Email == request.DoctorEmail && x.DeleteDate == null);

            var consultationDetails = new ConsultationDetails
            {
                UserId = request.Organiser == (long)UserTypeEnum.Patient ? patient!.Id : doctor!.Id,
                Organiser = request.Organiser,
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = "TENTATIVE"
            };
            db.ConsultationDetails.Add(consultationDetails);
            await db.SaveChangesAsync(cancellationToken);

            var consultation = new Consultation
            {
                UserId = request.Organiser == (long)UserTypeEnum.Patient ? doctor!.Id : patient!.Id,
                ConsultationDetailId = consultationDetails.Id,
            };
            db.Consultations.Add(consultation);
            await db.SaveChangesAsync(cancellationToken);

            return new ConsultationModel
            {
                Id = consultationDetails.Id,
                Patient = patient.Email,
                Doctor = doctor.Email,
                Title = consultationDetails.Title,
                Description = consultationDetails.Description,
                StartDate = consultationDetails.StartDate,
                EndDate = consultationDetails.EndDate,
                Status = "TENTATIVE",
            };
        }
    }
}
