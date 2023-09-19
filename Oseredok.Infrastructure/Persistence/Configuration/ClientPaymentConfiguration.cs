using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oseredok.Domain.Entities;

namespace Oseredok.Infrastructure.Persistence.Configuration
{
    public class ClientPaymentConfiguration : IEntityTypeConfiguration<ClientPayment>
    {
        public void Configure(EntityTypeBuilder<ClientPayment> builder)
        {
            builder.HasData(
                new ClientPayment
                {
                    Id = Guid.Parse("d4e65555-950b-4d87-b111-9ce087f3c79f"),
                    Balance = 100,
                    LastPaymentDate = new DateTime(2022, 06, 05),
                    LastPaymentSum = 100,
                    PaymentPerSession = 50
                }
            );
        }
    }
}