using Starbucks.Application.Abstractions;
using Starbucks.Application.Orders.Queries.GetOrderById;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.Orders.Queries.GetOrders
{
    internal sealed class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var listOrderDTO =  new List<OrderDTO>();
            var orders = await _orderRepository.GetOrders(cancellationToken);
            var products = await _productRepository.GetProducts(cancellationToken);


            foreach (var order in orders)
            {
                var orderDetail = await _orderDetailRepository.GetOrdersByOrderId(order.Id, cancellationToken);

                var orderDetailsDTO = from od in orderDetail
                                      join p in products on od.IdProduct equals p.Id
                                      select new OrderDetailDTO(p.Name, od.Quantity);


                listOrderDTO.Add(new OrderDTO(order.Id, order.ClientName, order.NameAttention, order.OrderStatus, order.DateCreated, orderDetailsDTO.ToList()));
            }

            return listOrderDTO;
        }
    }
}
