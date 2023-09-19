using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Admin
        {
            public static Error InvalidId => Error.Conflict(
                code: "Admin.InvalidId",
                description: "There is no admin with given id");
        }
    }
}