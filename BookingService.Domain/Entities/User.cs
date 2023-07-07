using BookingService.Domain.Common.BaseEntities;

namespace BookingService.Domain.Entities
{
    public class User : TrackedEntity<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; }
        public long Role { get; set; }
        public virtual ICollection<ConsultationDetails> ConsultationDetails { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }

    }
}
