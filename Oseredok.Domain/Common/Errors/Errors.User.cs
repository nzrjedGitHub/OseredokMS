using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use.");

            public static Error DuplicatePhoneNumber => Error.Conflict(
                code: "User.DuplicatePhoneNumber",
                description: "Phone number is already in use.");

            public static Error InvalidId => Error.Conflict(
                code: "User.InvalidId",
                description: "There is no user with given id");

            public static Error InvalidRoleName => Error.Conflict(
                code: "User.InvalidRoleName",
                description: "There is no role with given roleName");
        }
    }
}