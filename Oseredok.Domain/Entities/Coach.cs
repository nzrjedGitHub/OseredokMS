using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oseredok.Domain.Entities
{
    public class Coach
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        public decimal PercentagePerSession { get; set; }

        public ICollection<Client>? Clients { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public User User { get; set; }

        public Gym Gym { get; set; }
    }
}