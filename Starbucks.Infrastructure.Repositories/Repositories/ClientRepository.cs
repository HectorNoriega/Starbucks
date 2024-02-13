using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.Repositories
{
    public sealed class ClientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task AddClient(Client clientItem, CancellationToken cancellationToken)
        {
            _dbContext.ClientItems.Add(clientItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateClient(Client clientItem, CancellationToken cancellationToken)
        {
            var clientItemAux = await _dbContext.ClientItems
                    .FindAsync(new object[] { clientItem.Id });

            if (clientItemAux == null)
            {
                return;
            }

            clientItemAux.Email = clientItem.Email;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
