using ErrorOr;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Domain.Common.Errors;
using Oseredok.Domain.Entities;
using Oseredok.Shared.DTOs.Client;
using Oseredok.Shared.DTOs.Common;

namespace Oseredok.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _ctx;

        public ClientRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(ClientCreateDto clientCreateDto)
        {
            var newClientPayment = new ClientPayment
            {
                Id = Guid.NewGuid(),
                PaymentPerSession = clientCreateDto.PaymentPerSession,
                Balance = 0,
            };
            var newClient = new Client
            {
                Id = Guid.NewGuid(),
                ClientPaymentId = newClientPayment.Id,
            };
            newClient = clientCreateDto.Adapt(newClient);
            await _ctx.AddAsync(newClientPayment);
            await _ctx.AddAsync(newClient);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IsDeletedDto> Delete(Client client)
        {
            _ctx.Clients.Remove(client);
            _ctx.ClientPayments.Remove(client.ClientPayment);
            await _ctx.SaveChangesAsync();
            var result = new IsDeletedDto()
            {
                IsDeleted = true
            };
            return result;
        }

        public async Task<ErrorOr<IEnumerable<Client>>> GetAll()
        {
            var clients = await _ctx.Clients
                .Include(client => client.User).ThenInclude(user => user.Role)
                .ToListAsync();
            return clients;
        }

        public async Task<IEnumerable<Client>?> GetAllByGym(int gymId)
        {
            return await _ctx.Clients
                .Include(client => client.ClientPayment)
                .Include(client => client.User).ThenInclude(user => user.Role)
                .Where(client => client.Gym.Id == gymId)
                .ToListAsync();
        }

        public async Task<ErrorOr<Client>> GetById(Guid id)
        {
            var client = await _ctx.Clients
                .Include(client => client.ClientPayment)
                .Include(client => client.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(client => client.Id == id);
            if (client == null)
            {
                return Errors.Client.InvalidId;
            }
            return client;
        }

        public async Task<ErrorOr<Client>> Update(ClientUpdateDto clientUpdateDto)
        {
            var client = await _ctx.Clients
                .Include(client => client.ClientPayment)
                .Include(client => client.User).ThenInclude(user => user.Role)
                .FirstOrDefaultAsync(client => client.Id == clientUpdateDto.Id);
            if (client == null)
            {
                return Errors.Client.InvalidId;
            }
            client = clientUpdateDto.Adapt(client);
            await _ctx.SaveChangesAsync();
            return client;
        }
    }
}