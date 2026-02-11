namespace Demo.Handlers;

public class CreateOrderCommandHandler(IOrderRepository _orderRepository) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        int orderCount = await _orderRepository.GetOrderCount();

        var order = new Order
        {
            Id = orderCount + 1,
            CustomerName = request.CustomerName,
            OrderDate = request.OrderDate
        };

        await _orderRepository.Create(order);       
    }
}