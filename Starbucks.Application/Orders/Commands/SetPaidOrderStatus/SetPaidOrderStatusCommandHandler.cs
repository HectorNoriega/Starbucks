using Starbucks.Application.Abstractions;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Enums;

namespace Starbucks.Application.Orders.Commands.PaidOrder
{
    internal sealed class SetPaidOrderStatusCommandHandler : ICommandHandler<SetPaidOrderStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetPaidOrderStatusCommandHandler(IOrderRepository orderRepository
            , IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(SetPaidOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetOrderById(request.IdOrder, cancellationToken);

            if (orderToUpdate == null)
            {
                return false;
            }

            orderToUpdate.OrderStatus = OrderStatusEnum.PAID;

            await _orderRepository.UpdateOrder(orderToUpdate, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;    
        }
    }
}
