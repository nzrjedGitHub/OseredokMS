using Microsoft.EntityFrameworkCore;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionStatus> SessionStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<ClientPayment> ClientPayments { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}