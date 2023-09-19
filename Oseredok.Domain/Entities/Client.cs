using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oseredok.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientPayment))]
        public Guid ClientPaymentId { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public Guid? CoachId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public User User { get; set; }

        public ClientPayment ClientPayment { get; set; }

        public Coach Coach { get; set; }

        public Gym Gym { get; set; }
    }
}