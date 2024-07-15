using Demo.Entities;
using MediatR;

namespace Demo.Queries;

public class GetListOrderQuery : IRequest<List<Order>>
{
}