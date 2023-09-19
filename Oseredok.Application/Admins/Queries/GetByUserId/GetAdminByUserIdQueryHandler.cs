using ErrorOr;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Admins.Queries.GetByUserId
{
    public class GetAdminByUserIdQueryHandler : IRequestHandler<GetAdminByUserIdQuery, ErrorOr<Admin>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAdminByUserIdQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ErrorOr<Admin>> Handle(GetAdminByUserIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var admin = await _adminRepository.GetByUserId(query.Id);
            return admin;
        }
    }
}