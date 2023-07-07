using BookingService.Domain.Common.Contracts;
using BookingService.Persistance.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BookingService.Application.Persistance;
using BookingService.Domain.Entities;

namespace BookingService.Persistance
{
    public class BookingServiceDbContext : BaseDbContext, IBookingServiceDbContext
    {
        public BookingServiceDbContext(DbContextOptions<BookingServiceDbContext> options) : base(options) { }
        protected void OnModelCreating(ModelBuilder modelBuilder, Assembly assembly)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<ITrackedEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UpdateCreateCredentials(DateTime.Now);
                        break;
                    case EntityState.Modified:
                        if (entry.Entity.DeleteDate > DateTime.MinValue)
                        {
                            entry.Entity.UpdateDeleteCredentials(DateTime.Now);
                        }
                        else
                        {
                            entry.Entity.UpdateLastModifiedCredentials(DateTime.Now);
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ConsultationDetails> ConsultationDetails { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
    }
}
