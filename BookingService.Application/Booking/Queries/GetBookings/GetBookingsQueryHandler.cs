using BookingService.Application.Booking.Command.CreateBooking;
using BookingService.Application.Persistance;
using BookingService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BookingService.Application.Booking.Queries.GetBookings
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, List<ConsultationModel>>
    {
        private readonly IBookingServiceDbContext db;
        public GetBookingsQueryHandler(IBookingServiceDbContext db) => this.db = db;
        public Task<List<ConsultationModel>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var consultations = db.Consultations
                                  .Include(x => x.User)
                                  .Include(x => x.ConsultationDetail)
                                  .ThenInclude(x => x.User).ToList();

            var result = consultations.Where(x => x.User.Email == request.Email
                             && (request.BookingStatus == null || request.BookingStatus == x.ConsultationDetail.Status)
                             && (request.FromDate == null || request.FromDate == x.ConsultationDetail.StartDate)
                             && (request.ToDate == null || request.ToDate == x.ConsultationDetail.EndDate))
                         .Select(x => new ConsultationModel
                         {
                             Id = x.Id,
                             UserName = x.ConsultationDetail.User.Email,
                             Title = x.ConsultationDetail.Title,
                             Description = x.ConsultationDetail.Description,
                             StartDate = x.ConsultationDetail.StartDate,
                             EndDate = x.ConsultationDetail.EndDate,
                             Status = x.ConsultationDetail.Status,
                             StatusComment = x.ConsultationDetail.StatusComment
                         }).ToList();
            return Task.FromResult(result);
        }
    }
}
