using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Coach
        {
            public static Error InvalidId => Error.Conflict(
                code: "Coach.InvalidId",
                description: "There is no coach with given id");
        }
    }
}