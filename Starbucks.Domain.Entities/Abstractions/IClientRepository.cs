using Starbucks.Domain.Entities;

namespace Starbucks.Domain
{
    public interface IClientRepository
    {
        void Insert(Client client);
    }
}
