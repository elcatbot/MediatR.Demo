using Demo.Commands;
using Demo.Entities;
using Demo.Infrastructure;
using Demo.Queries;
using MediatR;

namespace Demo.Handlers;

public class GetListOrderHandler : IRequestHandler<GetListOrderQuery , List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetListOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetListOrderQuery  request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetList();
    }
}