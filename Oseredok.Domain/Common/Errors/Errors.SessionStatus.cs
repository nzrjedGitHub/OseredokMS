using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class SessionStatus
        {
            public static Error InvalidSessionStatus => Error.Conflict(
                code: "SessionStatus.InvalidSessionStatus",
                description: "There is no SessionStatus with given SessionStatus name");

            public static Error InvalidId => Error.Conflict(
               code: "SessionStatus.InvalidId",
               description: "There is no SessionStatus with given id");
        }
    }
}