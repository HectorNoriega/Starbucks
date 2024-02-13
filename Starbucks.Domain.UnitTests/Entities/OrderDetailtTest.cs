using Starbucks.Domain.Entities;
using Starbucks.Domain.Exceptions.Base;

namespace Starbucks.Domain.UnitTests.Entities
{
    public class OrderDetailtTest
    {
        [Fact]
        public void Create_order_item_success()
        {
            //Arrange    
            var id = Guid.NewGuid();
            var idOrder = Guid.NewGuid();
            var idProduct = Guid.NewGuid();
            var units = 1;

            //Act 
            var fakeOrderItem = new OrderDetail(id, idOrder, idProduct, units);

            //Assert
            Assert.NotNull(fakeOrderItem);
        }

        [Fact]
        public void Invalid_number_of_units()
        {
            //Arrange    
            var id = Guid.NewGuid();
            var idOrder = Guid.NewGuid();
            var idProduct = Guid.NewGuid();
            var units = -1;

            //Act - Assert
            Assert.Throws<OrderException>(() => new OrderDetail(id, idOrder, idProduct, units));
        }
    }
}
