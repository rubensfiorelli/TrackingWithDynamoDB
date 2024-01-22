using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Core.Common;

namespace DynamoDB.Core.Entities
{
    [DynamoDBTable("ShippingOrderLine")]

    public sealed class ShippingOrderLine : BaseEntity
    {
        public ShippingOrderLine(string title, decimal price) : base()
        {
            Title = title;
            Price = price;
        }

        [DynamoDBProperty("Title")]
        public string Title { get; private set; }
        
        [DynamoDBProperty("Price")]
        public decimal Price { get; private set; }
    }
}
