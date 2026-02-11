namespace Demo.Handlers;

public class GetListOrderHandler(IOrderRepository _orderRepository) : IRequestHandler<GetListOrderQuery , List<Order>>
{
    public async Task<List<Order>> Handle(GetListOrderQuery  request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetList();
    }
}