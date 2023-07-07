using BookingService.Domain.Common.BaseEntities;

namespace BookingService.Domain.Entities
{
    public class ConsultationDetails : TrackedEntity<int>
    {
        public int UserId { get; set; }
        public long Organiser { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public string? StatusComment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
