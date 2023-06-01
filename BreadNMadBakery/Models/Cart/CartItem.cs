public class CartItem
{
    public CartItem(int productId, string productName, string imageName, double price, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
        ProductName = productName;
        ImageName = imageName;
        Price = price;
    }

    public int ProductId { get; }
    public string ProductName { get; }
    public string ImageName {get;}
    public double Price { get; }
    public int Quantity { get; private set; }

    public void IncreaseQuantity()
    {
        Quantity++;
    }
}