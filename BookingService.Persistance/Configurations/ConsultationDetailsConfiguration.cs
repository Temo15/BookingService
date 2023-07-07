using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Persistance.Configurations
{
    public class ConsultationDetailsConfiguration : IEntityTypeConfiguration<ConsultationDetails>
    {
        public void Configure(EntityTypeBuilder<ConsultationDetails> builder)
        {
            builder.ToTable("ConslutationDetails");

            builder.HasOne(x => x.User)
                .WithMany(y => y.ConsultationDetails)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
