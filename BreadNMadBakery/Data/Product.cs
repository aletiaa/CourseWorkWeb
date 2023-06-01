public class Product 
{
    private string _imageName;

    public Product() 
    {
        this.OrdersProducts = new List<OrderProduct>();
    }
 
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    
    public string? ImageName 
    {
        get
        {  
            if (_imageName == null) 
            {
                return "no-image.jpg";
            }

            return _imageName;
        }

        set
        {
            _imageName = value;
        } 
    }

    public List<OrderProduct> OrdersProducts { get; set; }
}