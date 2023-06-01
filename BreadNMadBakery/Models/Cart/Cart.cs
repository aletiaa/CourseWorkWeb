public class Cart 
{
    private List<CartItem> _items;
    private static Cart _instance;

    private Cart()
    {
        _items = new List<CartItem>();
    }

    public static Cart Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new Cart();
            }

            return _instance;
        }
    }

    public List<CartItem> GetAllItems()
    {
        return _items;
    }

    public void AddProduct(int productId, string productName, string imageName, double price)
    {
        var cartItem = _items.FirstOrDefault(item => item.ProductId == productId);
        
        if (cartItem != null) 
        {
            cartItem.IncreaseQuantity();
        }
        else
        {
            _items.Add(new CartItem(productId, productName, imageName, price, 1));
        }
    }

    public void RemoveProduct(int id)
    {
        var cartItem = _items.FirstOrDefault(item => item.ProductId == id);
        _items.Remove(cartItem);
    }

    public void Clear()
    {
        _items.Clear();
    }
}