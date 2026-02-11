namespace Demo.Commands;

public record CreateOrderCommand(string CustomerName, DateTime OrderDate) : IRequest;