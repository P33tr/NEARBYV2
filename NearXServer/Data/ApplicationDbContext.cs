using Microsoft.EntityFrameworkCore;
using NearXShared.Models;

namespace NearXServer.Data
{
    public class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
        {
        }
        public DbSet<Review> Reviews { get; set; }
    }
}
