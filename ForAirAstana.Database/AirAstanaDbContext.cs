using Microsoft.EntityFrameworkCore;

namespace ForAirAstana.Database
{
    public class AirAstanaDbContext : DbContext
    {
        public DbSet<Entities.Flight> Flights { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }
        public DbSet<Entities.User> Users { get; set; }

        public AirAstanaDbContext(DbContextOptions<AirAstanaDbContext> options)
            : base(options) { }

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

            modelBuilder.Entity<Entities.Role>().Property(i => i.Code).IsUnicode();
            modelBuilder.Entity<Entities.Role>().HasData(
                new Entities.Role { Id = 1, Code = "Moderator" },
                new Entities.Role { Id = 2, Code = "User" }
            );
        }
    }
}