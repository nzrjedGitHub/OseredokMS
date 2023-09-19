namespace Oseredok.Shared.DTOs.Admin
{
    public class AdminCreateDto
    {
        public Guid UserId { get; set; }

        public int GymId { get; set; }

        public decimal Salary { get; set; }
    }
}