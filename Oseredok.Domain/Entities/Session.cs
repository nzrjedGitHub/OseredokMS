using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oseredok.Domain.Entities
{
    public class Session
    {
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public Guid CoachId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        [ForeignKey(nameof(SessionStatus))]
        public int SessionStatusId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        public Client Client { get; set; }

        public Coach Coach { get; set; }

        public Gym Gym { get; set; }

        public SessionStatus SessionStatus { get; set; }
    }
}