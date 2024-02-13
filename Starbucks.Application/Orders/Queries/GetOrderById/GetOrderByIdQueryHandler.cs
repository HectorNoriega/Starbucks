using Starbucks.Application.Abstractions;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.Orders.Queries.GetOrderById
{
    internal sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.orderId, cancellationToken);
            var products = await _productRepository.GetProducts(cancellationToken);

            if (order == null) return null;

            var orderDetail = await _orderDetailRepository.GetOrdersByOrderId(order.Id, cancellationToken);
            var orderDetailsDTO = from od in orderDetail
                                  join p in products on od.IdProduct equals p.Id
                                  select new OrderDetailDTO(p.Name, od.Quantity);

            var orderDTO = new OrderDTO(order.Id, order.ClientName, order.NameAttention, order.OrderStatus, order.DateCreated, orderDetailsDTO.ToList());

            return orderDTO;
        }
    }
}
