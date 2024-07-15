using Demo.Entities;
using MediatR;

namespace Demo.Queries;

public class GetOrderQuery : IRequest<Order>
{
    public int OrderId { get; set; }
}