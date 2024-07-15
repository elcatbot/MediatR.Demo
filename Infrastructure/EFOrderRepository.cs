using System.Linq.Expressions;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure;

public class EFOrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public EFOrderRepository(OrderContext context)
    {
        _context = context;
    }
    
    public async Task<Order> GetById(int id)
    {
        return (await _context.Orders.FindAsync(id))!;
    }

    public async Task<List<Order>> GetList()
    {
        return await _context.Orders.ToListAsync();
    }

    public Task<Order> FirstOrDefault(Expression<Func<Order, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetOrderCount() => await _context.Orders.CountAsync();

    public async Task Create(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public Task<Order> Update(Order order)
    {
        throw new NotImplementedException();
    }

    
}