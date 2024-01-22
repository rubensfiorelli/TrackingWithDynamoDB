using DynamoDB.Application.ViewModels;

namespace DynamoDB.Application.Services
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAll();
    }
}
