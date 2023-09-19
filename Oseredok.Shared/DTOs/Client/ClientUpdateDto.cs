namespace Oseredok.Shared.DTOs.Client
{
    public class ClientUpdateDto
    {
        public Guid Id { get; set; }

        public Guid? CoachId { get; set; }

        public int GymId { get; set; }
    }
}