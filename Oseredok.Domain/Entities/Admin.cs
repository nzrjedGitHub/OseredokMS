using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oseredok.Domain.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public User User { get; set; }

        public Gym Gym { get; set; }
    }
}