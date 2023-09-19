using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Shared.DTOs.Session
{
    public class SessionStatusUpdateDto
    {
        public Guid Id { get; set; }

        public int SessionStatusId { get; set; }
    }
}