using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Contracts.Admin
{
    public record AdminUpdateRequest(
        Guid Id,
        int GymId,
        decimal Salary);
}