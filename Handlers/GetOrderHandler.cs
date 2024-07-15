using Demo.Commands;
using Demo.Entities;
using Demo.Infrastructure;
using Demo.Queries;
using MediatR;

namespace Demo.Handlers;

public class GetOrderHandler : IRequestHandler<GetOrderQuery , Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetById(request.OrderId);
    }
}