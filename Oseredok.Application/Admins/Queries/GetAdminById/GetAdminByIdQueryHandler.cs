using ErrorOr;
using MediatR;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Application.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, ErrorOr<Admin>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAdminByIdQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ErrorOr<Admin>> Handle(GetAdminByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var admin = await _adminRepository.GetById(query.Id);
            return admin;
        }
    }
}