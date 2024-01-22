using DynamoDB.Core.Entities;

namespace DynamoDB.Core.Contracts
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetCodeAsync(string code);
        Task AddAsync(ShippingOrder shippingOrder);
    }
}
