namespace Demo.Queries;

public record GetOrderQuery(int OrderId) : IRequest<Order>;