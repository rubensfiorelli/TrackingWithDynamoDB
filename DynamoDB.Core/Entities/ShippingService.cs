using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Core.Common;

namespace DynamoDB.Core.Entities
{
    [DynamoDBTable("ShippingService")]

    public sealed class ShippingService : BaseEntity
    {
        public ShippingService(string title, decimal pricePerKg, decimal fixedPrice) : base()
        {
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }

        [DynamoDBProperty("Title")]
        public string Title { get; private set; }

        [DynamoDBProperty("PricePerKg")]
        public decimal PricePerKg { get; private set; }

        [DynamoDBProperty("FixedPrice")]
        public decimal FixedPrice { get; private set; }
    }
}
