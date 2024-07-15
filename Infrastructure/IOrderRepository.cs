using System.Linq.Expressions;
using Demo.Entities;

namespace Demo.Infrastructure;

public interface IOrderRepository
{
    Task<int> GetOrderCount();
    Task<List<Order>> GetList();
    Task<Order> GetById(int id);
    Task Create(Order order);
    Task<Order> Update(Order order);
    Task<Order> FirstOrDefault(Expression<Func<Order, bool>> expression);
}