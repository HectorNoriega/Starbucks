namespace Starbucks.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Order(Guid id, string clientName, string nameAttention, DateTime dateCreated, string orderStatus ) : base(id)
        {
            Id = id;
            ClientName = clientName;
            NameAttention = nameAttention;
            DateCreated = dateCreated;
            OrderStatus = orderStatus;
        }

        public string ClientName { get;set; }
        public string NameAttention { get;set; }
        public DateTime DateCreated { get;set; }
        public string OrderStatus { get;set; }
    }
}

