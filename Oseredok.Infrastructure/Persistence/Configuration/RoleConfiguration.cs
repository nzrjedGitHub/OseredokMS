using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new Role
            {
                Id = 1,
                Name = "admin"
            },
            new Role
            {
                Id = 2,
                Name = "coach"
            },
            new Role
            {
                Id = 3,
                Name = "client"
            },
            new Role
            {
                Id = 4,
                Name = "noRole"
            }
            );
        }
    }
}