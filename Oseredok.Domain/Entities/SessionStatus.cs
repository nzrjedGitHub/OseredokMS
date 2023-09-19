using System.ComponentModel.DataAnnotations;

namespace Oseredok.Domain.Entities
{
    public class SessionStatus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}