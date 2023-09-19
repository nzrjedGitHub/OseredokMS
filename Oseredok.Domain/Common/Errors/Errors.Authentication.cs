using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            /*public static Error InvalidCredentials => Error.Validation(*/

            public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication.InvalidCred",
            description: "Invalid credentials.");
        }
    }
}