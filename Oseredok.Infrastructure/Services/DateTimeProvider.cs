using Oseredok.Application.Common.Interfaces.Services;

namespace Oseredok.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}