using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Shared.DTOs.Coach
{
    public class GetCoachSalaryDto
    {
        public Guid Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime TillDate { get; set; }
    }
}