namespace Oseredok.Shared.DTOs.Coach
{
    public class CoachUpdateDto
    {
        public Guid Id { get; set; }

        public int GymId { get; set; }

        public decimal PercentagePerSession { get; set; }
    }
}