using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class SessionStatusConfiguration : IEntityTypeConfiguration<SessionStatus>
    {
        public void Configure(EntityTypeBuilder<SessionStatus> builder)
        {
            builder.HasData(
                new SessionStatus
                {
                    Id = 4,
                    Name = "awaiting"
                },
                new SessionStatus
                {
                    Id = 5,
                    Name = "accepted"
                },
                new SessionStatus
                {
                    Id = 6,
                    Name = "inProcess"
                },
                new SessionStatus
                {
                    Id = 7,
                    Name = "completed"
                }
                );
        }
    }
}