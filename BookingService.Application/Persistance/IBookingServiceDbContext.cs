using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookingService.Application.Persistance
{
    public interface IBookingServiceDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<ConsultationDetails> ConsultationDetails { get; set; }
        DbSet<Consultation> Consultations { get; set; }

        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
