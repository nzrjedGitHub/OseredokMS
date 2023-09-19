using System.ComponentModel.DataAnnotations;

namespace Oseredok.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}