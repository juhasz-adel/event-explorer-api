using Microsoft.EntityFrameworkCore;

namespace EventExplorer.Api.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
