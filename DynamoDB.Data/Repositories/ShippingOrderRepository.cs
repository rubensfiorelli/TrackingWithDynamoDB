using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Core.Contracts;
using DynamoDB.Core.Entities;

namespace DynamoDB.Data.Repositories
{
    public class ShippingOrderRepository : IShippingOrderRepository
    {
        private readonly IDynamoDBContext _context;

        public ShippingOrderRepository(IDynamoDBContext context) => _context = context;

        public async Task AddAsync(ShippingOrder shippingOrder)
        {
            var order = await _context.LoadAsync<ShippingOrder>(shippingOrder.Id, shippingOrder.TrackingCode);

            await _context.SaveAsync(order);

        }

        public async Task<ShippingOrder> GetCodeAsync(string trackingCode)
        {
            var code = await _context.LoadAsync<ShippingOrder>(trackingCode);
            if (trackingCode is null)
                return null;

            return code;
        }
    }
}
