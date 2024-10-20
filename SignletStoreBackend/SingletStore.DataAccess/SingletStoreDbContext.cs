using Microsoft.EntityFrameworkCore;
using SingletStore.DataAccess.Entities;

namespace SingletStore.DataAccess
{
    public class SingletStoreDbContext : DbContext
    {
        public SingletStoreDbContext(DbContextOptions<SingletStoreDbContext> options) : base(options) 
        {
            
        }

        public DbSet<SingletEntity> Singlets { get; set;}
    }
}
