using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
                new Admin
                {
                    Id = Guid.Parse("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                    UserId = Guid.Parse("d4119255-950b-4d87-f432-9ce087f34698"),
                    Salary = 6000,
                    GymId = 1,
                }
                );
        }
    }
}