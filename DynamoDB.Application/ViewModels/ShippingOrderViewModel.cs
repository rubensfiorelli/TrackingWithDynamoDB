using DynamoDB.Core.Entities;

namespace DynamoDB.Application.ViewModels
{
    public class ShippingOrderViewModel
    {
        public ShippingOrderViewModel(string trackingCode,
                                      string description,
                                      DateTimeOffset postedAt,
                                      decimal weightInKg,
                                      string fullAddress)
        {
            TrackingCode = trackingCode;
            Description = description;
            PostedAt = postedAt;
            WeightInKg = weightInKg;
            FullAddress = fullAddress;
        }

        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset PostedAt { get; private set; }
        public decimal WeightInKg { get; private set; }
        public string FullAddress { get; private set; }


        public static ShippingOrderViewModel FromEntity(ShippingOrder entity)
        {
            var address = entity.DeliveryAddress;

            return new ShippingOrderViewModel(
                    entity.TrackingCode, 
                    entity.Description, 
                    entity.PostedAt, 
                    entity.WeightInKg,
                    $"{address.Street}, {address.Number}, {address.City}, {address.Region}, {address.PostalCode}, {address.Country}");

        }

    }
}
