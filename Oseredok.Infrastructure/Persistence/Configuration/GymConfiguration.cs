using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.HasData(
                new Gym
                {
                    Id = 1,
                    Address = "someAddress",
                    ClientCapacity = 5,
                }
                );
        }
    }
}