using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Session
        {
            public static Error InvalidId => Error.Conflict(
                code: "Session.InvalidId",
                description: "There is no session with given id");
        }
    }
}