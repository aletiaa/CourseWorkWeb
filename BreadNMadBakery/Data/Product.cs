public class Product 
{
    public Product() 
    {
        this.OrdersProducts = new List<OrderProduct>();
    }
 
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageName {get; set; }

    public List<OrderProduct> OrdersProducts { get; set; }
}