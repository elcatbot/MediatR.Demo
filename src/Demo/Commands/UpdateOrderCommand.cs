namespace Demo.Commands;

public record UpdateOrderCommand(int OrderId, string? CustomerName, DateTime OrderDate) : IRequest<Order>;