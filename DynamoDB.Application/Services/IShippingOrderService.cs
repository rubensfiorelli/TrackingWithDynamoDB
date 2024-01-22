using DynamoDB.Application.InputModels;
using DynamoDB.Application.ViewModels;

namespace DynamoDB.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel model);
        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}
