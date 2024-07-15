using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
}