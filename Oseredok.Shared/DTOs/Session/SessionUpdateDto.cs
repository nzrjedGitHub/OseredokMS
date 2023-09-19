namespace Oseredok.Shared.DTOs.Session
{
    public class SessionUpdateDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid CoachId { get; set; }

        public int SessionStatusId { get; set; }

        public DateTime SessionDate { get; set; }
    }
}