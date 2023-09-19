using System.ComponentModel.DataAnnotations;

namespace Oseredok.Domain.Entities
{
    public class Gym
    {
        public int Id { get; set; }

        [Required]
        public int ClientCapacity { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public ICollection<Client>? Clients { get; set; }

        public ICollection<Coach>? Coaches { get; set; }

        public ICollection<Session>? Sessions { get; set; }
    }
}