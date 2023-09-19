using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasOne(c => c.User)
                .WithOne(u => u.Client)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Gym)
                .WithMany(u => u.Clients)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Client
                {
                    Id = Guid.Parse("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                    UserId = Guid.Parse("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                    ClientPaymentId = Guid.Parse("d4e65555-950b-4d87-b111-9ce087f3c79f"),
                    CoachId = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    GymId = 1
                }
                );
        }
    }
}