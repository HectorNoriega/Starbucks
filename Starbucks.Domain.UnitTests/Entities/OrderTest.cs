using Starbucks.Domain.Entities;
using Starbucks.Domain.Enums;

namespace Starbucks.Domain.UnitTests.Entities
{
    public class OrderTest
    {
        [Fact]
        public void Create_order_item_success()
        {
            //Arrange    
            var id = Guid.NewGuid();
            var clientName = "FakeClientName";
            var cashierName = "FakeCashierName";
            var dateCreated = DateTime.Now;
            var status = OrderStatusEnum.PREPARING;

            //Act 
            var fakeOrderItem = new Order(id, clientName, cashierName, dateCreated, status);

            //Assert
            Assert.NotNull(fakeOrderItem);
        }
    }
}
