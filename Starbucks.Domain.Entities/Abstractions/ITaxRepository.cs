using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Repositories
{
    public interface ITaxRepository
    {
        public Task<List<Tax>> getTaxes();
    }
}
