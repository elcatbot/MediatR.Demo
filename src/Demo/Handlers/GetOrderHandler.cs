namespace Demo.Handlers;

public class GetOrderHandler(IOrderRepository _orderRepository) : IRequestHandler<GetOrderQuery , Order>
{
    public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetById(request.OrderId);
    }
}