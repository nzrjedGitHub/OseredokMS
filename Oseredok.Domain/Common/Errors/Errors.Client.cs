using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Client
        {
            public static Error InvalidId => Error.Conflict(
                code: "Client.InvalidId",
                description: "There is no client with given id");
        }
    }
}