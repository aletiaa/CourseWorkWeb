using Microsoft.EntityFrameworkCore;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options) 
        {
            Database.EnsureCreated();

        }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    // // @"Server=.\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;Encrypt=False"
    //  protected override void OnConfiguring(DbContextOptionsBuilder options)
    //  {
    //     options.UseSqlServer(@$"Server=.\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;Encrypt=False");
    //  }
}