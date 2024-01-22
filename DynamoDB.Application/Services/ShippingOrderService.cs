using DynamoDB.Application.InputModels;
using DynamoDB.Application.ViewModels;
using DynamoDB.Core.Contracts;

namespace DynamoDB.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        private readonly IShippingOrderRepository _repository;

        public ShippingOrderService(IShippingOrderRepository repository) => _repository = repository;

        public async Task<string> Add(AddShippingOrderInputModel model)
        {
            var shippingOrder = model.ToEntity();
            var shippingServices = model
                .Services
                .Select(s => s.ToEntity())
                .ToList();

            shippingOrder.SetupServices(shippingServices);

            await _repository.AddAsync(shippingOrder);

            return shippingOrder.TrackingCode;
        }

        public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = await _repository.GetCodeAsync(trackingCode);

            return ShippingOrderViewModel.FromEntity(shippingOrder);
        }
    }
}
