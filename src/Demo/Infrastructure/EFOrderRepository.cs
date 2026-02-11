
namespace Demo.Infrastructure;

public class EFOrderRepository(OrderContext _context) : IOrderRepository
{
    public async Task<Order> GetById(int id) => (await _context.Orders.FindAsync(id))!;

    public async Task<List<Order>> GetList() => await _context.Orders.ToListAsync();

    public async Task<int> GetOrderCount() => await _context.Orders.CountAsync();

    public async Task Create(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order> Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }
}