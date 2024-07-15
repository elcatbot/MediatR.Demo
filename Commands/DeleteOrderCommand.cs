using Demo.Entities;
using MediatR;

namespace Demo.Commands;

public class DeleteOrderCommand : IRequest<Order>
{
    public int OrderId { get; set; }
}