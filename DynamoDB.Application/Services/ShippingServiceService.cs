using DynamoDB.Application.ViewModels;
using DynamoDB.Core.Contracts;

namespace DynamoDB.Application.Services
{
    public class ShippingServiceService : IShippingServiceService
    {
        private readonly IShippingServiceRepository _repository;

        public ShippingServiceService(IShippingServiceRepository repository) => _repository = repository;
      
        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var listServices = await _repository.GetAllAsync();

            return listServices
                .Select(x => new ShippingServiceViewModel(x.Id, x.Title, x.PricePerKg, x.FixedPrice))
                .ToList();
        }
    }
}
