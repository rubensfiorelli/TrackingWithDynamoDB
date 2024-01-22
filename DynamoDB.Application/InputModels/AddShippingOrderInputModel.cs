using DynamoDB.Core.Entities;
using DynamoDB.Core.ValueObjects;

namespace DynamoDB.Application.InputModels
{
    public class AddShippingOrderInputModel
    {
        public string Description { get; set; }
        public decimal WeightInKg { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public List<ShippingServiceInputModel> Services { get; set; }

        public ShippingOrder ToEntity()
            => new ShippingOrder(
                Description, 
                WeightInKg, 
                DeliveryAddress.ToValueObject()
                );
    }

    public class DeliveryAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public DeliveryAddress ToValueObject()
            => new DeliveryAddress(Street, Number, City, Region, PostalCode, Country);
    }

    public class ShippingServiceInputModel
    {
        public string Title { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal FixedPrice { get; set; }

        public ShippingService ToEntity()
            => new ShippingService(Title, PricePerKg, FixedPrice);
    }


}
