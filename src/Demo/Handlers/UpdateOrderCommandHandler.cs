namespace Demo.Handlers;

public class UpdateOrderCommandHandler(IOrderRepository _orderRepository) : IRequestHandler<UpdateOrderCommand, Order>
{
     public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId);

        if(order == null)
        {
            return default!;
        }

        order.CustomerName = request.CustomerName;
        order.OrderDate = request.OrderDate;
        
        var orderUpdated = await _orderRepository.Update(order);
        return orderUpdated;
    }
}