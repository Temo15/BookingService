using BookingService.Domain.Common.Contracts;

namespace BookingService.Domain.Common.BaseEntities
{
    public abstract class TrackedEntity<T> : BaseEntity<T>, ITrackedEntity
    {
        public string? CreatedBy { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public string? LastModifiedBy { get; protected set; }
        public DateTime? LastModifiedDate { get; protected set; }
        public string? DeletedBy { get; protected set; }
        public DateTime? DeleteDate { get; set; }
        public void Delete()
        {
            DeleteDate = DateTime.Now;
        }
        public void UpdateCreateCredentials(DateTime createDate)
        {
            CreateDate = createDate;
        }
        public void UpdateLastModifiedCredentials(DateTime lastModifiedDate)
        {
            LastModifiedDate = lastModifiedDate;
        }
        public void UpdateDeleteCredentials(DateTime deleteDate)
        {
            DeleteDate = deleteDate;
        }
    }
}
