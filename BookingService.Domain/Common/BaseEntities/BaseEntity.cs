namespace BookingService.Domain.Common.BaseEntities
{
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// A uniquie identifier.
        /// </summary>
        public T Id { get; set; }
    }
}
