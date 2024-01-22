using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Core.Contracts;
using DynamoDB.Core.Entities;

namespace DynamoDB.Data.Repositories
{
    public class ShippingServiceRepository : IShippingServiceRepository
    {
        private readonly IDynamoDBContext _context;

        public ShippingServiceRepository(IDynamoDBContext context) => _context = context;

        public async Task<List<ShippingService>> GetAllAsync()
        {
            var existing = await _context.ScanAsync<ShippingService>(default).GetRemainingAsync();

            return existing;
        }
    }
}
