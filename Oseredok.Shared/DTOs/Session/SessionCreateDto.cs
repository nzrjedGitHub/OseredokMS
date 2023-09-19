namespace Oseredok.Shared.DTOs.Session
{
    public class SessionCreateDto
    {
        public Guid ClientId { get; set; }

        public Guid CoachId { get; set; }

        public int GymId { get; set; }

        public int SessionStatusId { get; set; }

        public DateTime SessionDate { get; set; }
    }
}