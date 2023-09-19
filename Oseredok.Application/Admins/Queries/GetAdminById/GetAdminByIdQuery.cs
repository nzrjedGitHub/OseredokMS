using ErrorOr;
using MediatR;
using Oseredok.Domain.Entities;

namespace Oseredok.Application.Admins.Queries.GetAdminById
{
    public record GetAdminByIdQuery(
        Guid Id) : IRequest<ErrorOr<Admin>>;
}