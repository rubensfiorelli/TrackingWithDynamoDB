using DynamoDB.Core.Entities;

namespace DynamoDB.Core.Contracts
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}
