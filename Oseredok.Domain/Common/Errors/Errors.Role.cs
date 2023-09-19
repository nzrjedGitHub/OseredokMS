using ErrorOr;

namespace Oseredok.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Role
        {
            public static Error InvalidRole => Error.Conflict(
                code: "Role.InvalidRole",
                description: "There is no role with given role name");

            public static Error InvalidId => Error.Conflict(
               code: "Role.InvalidId",
               description: "There is no role with given id");
        }
    }
}