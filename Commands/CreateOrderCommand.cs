using MediatR;

namespace Demo.Commands;

public class CreateOrderCommand : IRequest
{
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}