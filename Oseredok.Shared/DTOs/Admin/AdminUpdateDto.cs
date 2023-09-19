namespace Oseredok.Shared.DTOs.Admin
{
    public class AdminUpdateDto
    {
        public Guid Id { get; set; }

        public int GymId { get; set; }

        public decimal Salary { get; set; }
    }
}