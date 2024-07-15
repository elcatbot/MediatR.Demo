using Demo.Entities;
using MediatR;

namespace Demo.Commands;

public class UpdateOrderCommand : IRequest<Order>
{
    public int OrderId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}