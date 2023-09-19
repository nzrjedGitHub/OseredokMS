using System.ComponentModel.DataAnnotations;

namespace Oseredok.Domain.Entities
{
    public class ClientPayment
    {
        public Guid Id { get; set; }

        [Required]
        public decimal PaymentPerSession { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public decimal? LastPaymentSum { get; set; }

        public DateTime? LastPaymentDate { get; set; }
    }
}