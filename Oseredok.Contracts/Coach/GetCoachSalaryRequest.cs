using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Contracts.Coach
{
    public record GetCoachSalaryRequest
    (Guid Id, DateTime FromDate, DateTime TillDate
        );
}