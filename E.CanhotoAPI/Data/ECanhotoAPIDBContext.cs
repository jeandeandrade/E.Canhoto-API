using E.CanhotoAPI.Data.Map;
using E.CanhotoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E.CanhotoAPI.Data
{
    public class ECanhotoAPIDBContext : DbContext
    {
        public  ECanhotoAPIDBContext(DbContextOptions<ECanhotoAPIDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LeftHanded> LeftHanded { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LeftHandedMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
