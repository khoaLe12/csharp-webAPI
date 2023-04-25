using Microsoft.EntityFrameworkCore;

namespace MyService.Models;

public class MyStockContext : DbContext
{
    public MyStockContext(DbContextOptions<MyStockContext> options) 
        : base(options) { }

    public virtual DbSet<Product> Products { get; set; }
}
