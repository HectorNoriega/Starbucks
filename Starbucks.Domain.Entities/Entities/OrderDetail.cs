using Starbucks.Domain.Exceptions.Base;

namespace Starbucks.Domain.Entities
{
    public class OrderDetail:Entity
    {
        public OrderDetail(Guid id, Guid idOrder, Guid idProduct, int quantity) : base(id)
        {
            if (quantity <= 0)
            {
                throw new OrderException("Invalid number of units");
            }
            Id = id;
            IdOrder = idOrder;
            IdProduct = idProduct;
            Quantity = quantity;
        }

        public Guid IdOrder { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
