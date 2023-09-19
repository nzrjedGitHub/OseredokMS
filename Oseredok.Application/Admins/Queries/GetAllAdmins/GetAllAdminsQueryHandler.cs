using ErrorOr;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Admins.Queries.GetAllAdmins
{
    public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, ErrorOr<IEnumerable<Admin>>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllAdminsQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ErrorOr<IEnumerable<Admin>>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return await _adminRepository.GetAll();
        }
    }
}