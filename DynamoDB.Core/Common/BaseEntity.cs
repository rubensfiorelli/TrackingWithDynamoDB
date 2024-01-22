using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB.Core.Common
{
    [DynamoDBTable("BaseEntity")]
    public abstract class BaseEntity
    {
        protected BaseEntity()
            => Id = Guid.NewGuid();

        [DynamoDBHashKey]
        public Guid Id { get; protected init; }

        [DynamoDBProperty("sk")]
        public string SK => Id.ToString();

        public bool Equals(Guid id)
            => Id == id;

        public override int GetHashCode()
            => base.GetHashCode();       

    }
}

