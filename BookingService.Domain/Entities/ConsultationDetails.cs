﻿using BookingService.Domain.Common.BaseEntities;

namespace BookingService.Domain.Entities
{
    public class ConsultationDetails : TrackedEntity<int>
    {
        public int UserId { get; set; }
        public long Organiser { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? StatusComment { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
