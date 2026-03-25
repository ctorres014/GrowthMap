using Microsoft.EntityFrameworkCore;

namespace GrowthMap.Persistence.Context
{
    public class GrowthMapDbContext: DbContext
    {
        public GrowthMapDbContext(DbContextOptions<GrowthMapDbContext> options): base(options)
        {
            
        }
    }
}
