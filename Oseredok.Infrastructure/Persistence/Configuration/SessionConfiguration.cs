using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne(s => s.Coach)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Client)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Gym)
               .WithMany(g => g.Sessions)
               .HasForeignKey(s => s.GymId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Session
                {
                    Id = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c79f"),
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    ClientId = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    GymId = 1,
                    SessionStatusId = 5
                },
                new Session
                {
                    Id = Guid.Parse("d4f62345-950b-4d27-b568-9ce087f3c79f"),
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    ClientId = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    GymId = 1,
                    SessionStatusId = 6
                },
                new Session
                {
                    Id = Guid.Parse("d4f65555-950b-4d27-b231-9ce087f3c79f"),
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    ClientId = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    GymId = 1,
                    SessionStatusId = 7
                },
                new Session
                {
                    Id = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    SessionDate = new DateTime(2022, 07, 06),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    ClientId = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    GymId = 1,
                    SessionStatusId = 7
                },
                new Session
                {
                    Id = Guid.Parse("d4e61167-950b-4d87-b528-9ce087f8c79f"),
                    SessionDate = new DateTime(2022, 07, 06),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    ClientId = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    GymId = 1,
                    SessionStatusId = 7
                }
                );
        }
    }
}