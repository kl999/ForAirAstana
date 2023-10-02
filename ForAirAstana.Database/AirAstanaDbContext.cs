using Microsoft.EntityFrameworkCore;

namespace ForAirAstana.Database
{
    public class AirAstanaDbContext : DbContext
    {
        DbSet<Entities.Flight> Flights { get; set; }
        DbSet<Entities.Role> Roles { get; set; }
        DbSet<Entities.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Flight>().ToTable("Flights");
            modelBuilder.Entity<Entities.Role>().ToTable("Roles");
            modelBuilder.Entity<Entities.User>().ToTable("Users");

            modelBuilder.Entity<Entities.Flight>().Property(i => i.Origin).HasMaxLength(256);
            modelBuilder.Entity<Entities.Flight>().Property(i => i.Arrival).HasMaxLength(256);
            modelBuilder.Entity<Entities.Flight>().HasIndex(i => i.Arrival);

            modelBuilder.Entity<Entities.User>().Property(i => i.Username).HasMaxLength(256);
            modelBuilder.Entity<Entities.User>().Property(i => i.Password).HasMaxLength(256);
            modelBuilder.Entity<Entities.User>().HasOne(i => i.Role).WithMany().HasForeignKey(i => i.RoleId);
        }
    }
}