using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Core.Common;
using DynamoDB.Core.Enums;
using DynamoDB.Core.ValueObjects;

namespace DynamoDB.Core.Entities
{
    [DynamoDBTable("ShippingOrder")]
    public sealed class ShippingOrder : BaseEntity
    {
        public ShippingOrder(string description,
                             decimal weightInKg,
                             DeliveryAddress deliveryAddress) : base()
        {
            TrackingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.UtcNow;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;

            Status = EShippingOrderStatus.Started;
            Services = new List<ShippingOrderLine>();
        }

        [DynamoDBProperty("TrackingCode")]
        public string TrackingCode { get; private set; }
        
        [DynamoDBProperty("Description")]
        public string Description { get; private set; }
        
        [DynamoDBProperty("PostedAt")]
        public DateTimeOffset PostedAt { get; private set; }

        [DynamoDBProperty("WeightInKg")]        
        public decimal WeightInKg { get; private set; }

        [DynamoDBProperty("DeliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; private set; }
        
        [DynamoDBProperty("status")]
        public EShippingOrderStatus Status { get; private set; }
        
        [DynamoDBProperty("TotalPrice")]
        public decimal TotalPrice { get; private set; }

        public List<ShippingOrderLine> Services { get; private set; }

        public void SetupServices(List<ShippingService> services)
        {
            foreach(var service  in services)
            {
                var servicePrice = service.FixedPrice + service.PricePerKg * WeightInKg;

                TotalPrice += servicePrice;
                Services.Add(new ShippingOrderLine(service.Title, servicePrice));
            }
        }
        private string GenerateTrackingCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numb = "0123456789";

            var code = new char[10];
            var ramdom = new Random();

            for (var i = 0; i < 5; i++)
            {
                code[i] = chars[ramdom.Next(chars.Length)];
            }

            for (var i = 5; i < 10; i++)
            {
                code[i] = numb[ramdom.Next(numb.Length)];
            }

            return new string(code);
        }
    }
}
