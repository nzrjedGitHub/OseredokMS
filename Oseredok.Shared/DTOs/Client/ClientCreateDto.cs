namespace Oseredok.Shared.DTOs.Client
{
    public class ClientCreateDto
    {
        public Guid UserId { get; set; }

        public decimal PaymentPerSession { get; set; }

        public int GymId { get; set; }
    }
}