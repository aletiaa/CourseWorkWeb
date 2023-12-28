using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class ShopContext : DbContext
{
    public ShopContext() { }
    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options) 
        {
            Database.EnsureCreated();

        }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    // // @"Server=.\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;Encrypt=False"
    //  protected override void OnConfiguring(DbContextOptionsBuilder options)
    //  {
    //     options.UseSqlServer(@$"Server=.\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;Encrypt=False");
    //  }
}