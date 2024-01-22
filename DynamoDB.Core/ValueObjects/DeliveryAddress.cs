namespace DynamoDB.Core.ValueObjects
{
    public record DeliveryAddress(string Street, string Number, string City, string Region, string PostalCode, string Country)
    {
    }
}
