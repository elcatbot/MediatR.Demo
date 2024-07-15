using Demo.Commands;
using Demo.Entities;
using Demo.Infrastructure;
using MediatR;

namespace Demo.Handlers;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FirstOrDefault(o => o.Id == request.OrderId);

        order.CustomerName = request.CustomerName;
        order.OrderDate = request.OrderDate;
        
        var orderUpdated = await _orderRepository.Update(order);
        return orderUpdated;
    }
}