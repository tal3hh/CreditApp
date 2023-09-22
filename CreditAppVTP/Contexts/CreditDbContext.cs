using CreditAppVTP.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditAppVTP.Contexts
{
    public class CreditDbContext : DbContext
    {
        public CreditDbContext(DbContextOptions<CreditDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>().HasOne(x => x.AppUser).WithMany(x => x.Credits).HasForeignKey(x => x.AppUserId);
            modelBuilder.Entity<AppUser>().HasOne(x => x.Work).WithOne(x => x.AppUser).HasForeignKey<Work>(x => x.AppUserId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Work>? Works { get; set; }
        public DbSet<Credit>? Credits { get; set; }
    }
}
