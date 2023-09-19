namespace Oseredok.Shared.DTOs.Coach
{
    public class CoachCreateDto
    {
        public Guid UserId { get; set; }

        public int GymId { get; set; }

        public decimal PercentagePerSession { get; set; }
    }
}