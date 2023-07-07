namespace BookingService.Domain.Common.Contracts
{
    public interface ITrackedEntity
    {
        DateTime? DeleteDate { get; protected set; }
        void UpdateCreateCredentials(DateTime createDate);
        void UpdateLastModifiedCredentials(DateTime lastModifiedDate);
        void UpdateDeleteCredentials(DateTime deleteDate);
    }
}
