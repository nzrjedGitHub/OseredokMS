using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasOne(c => c.User)
               .WithOne(u => u.Coach)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Coach
                {
                    Id = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                    UserId = Guid.Parse("d4119255-950b-4d87-b568-9ce087f34698"),
                    GymId = 1,
                    PercentagePerSession = 15,
                },

                new Coach //default coach
                {
                    Id = Guid.Parse("d4e61167-950b-4d87-b568-9ce087f3c744"), //dc id
                    UserId = Guid.Parse("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                    GymId = 1,
                    PercentagePerSession = 0,
                }
                );
        }
    }
}