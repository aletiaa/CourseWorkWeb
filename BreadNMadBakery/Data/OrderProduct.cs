public class OrderProduct
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public int ProductQuantity { get; set; }
}