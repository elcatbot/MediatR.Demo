namespace Demo.Commands;

public record DeleteOrderCommand(int OrderId) : IRequest<Order>;