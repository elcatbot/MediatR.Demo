using Demo.Commands;
using Demo.Entities;
using Demo.Infrastructure;
using MediatR;

namespace Demo.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

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