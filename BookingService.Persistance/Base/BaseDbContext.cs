using Microsoft.EntityFrameworkCore;

namespace BookingService.Persistance.Base
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }
    }
}
