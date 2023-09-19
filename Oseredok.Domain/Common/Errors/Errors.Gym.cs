using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Gym
        {
            public static Error InvalidId => Error.Conflict(
                code: "Gym.InvalidId",
                description: "There is no gym with given id");
        }
    }
}