using BookingService.Domain.Common.BaseEntities;

namespace BookingService.Domain.Entities
{
    public class Consultation : TrackedEntity<int>
    {
        public int UserId { get; set; }
        public int ConsultationDetailId { get; set; }
        public bool ConlustationDoctorConfirmed { get; set; }
        public virtual User User { get; set; }
        public virtual ConsultationDetails ConsultationDetail { get; set; }
    }
}
