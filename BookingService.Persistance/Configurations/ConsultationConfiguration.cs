using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistance.Configurations
{
    public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.ToTable("Consultations");

            builder.HasOne(x => x.User)
                .WithMany(y => y.Consultations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ConsultationDetail)
                .WithMany(y => y.Consultations)
                .HasForeignKey(x => x.ConsultationDetailId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
