using System.ComponentModel.DataAnnotations;

public class Order
{
     public Order()
    {
        this.OrdersProducts = new List<OrderProduct>();
    }

    public int Id { get; set;}
    
    [Required(ErrorMessage = "Введіть номер телефону")]
    public string PhoneNumber { get; set;}

    public string? Comment { get; set;}

    public DateTime CreationDate { get; set; }

    [Required(ErrorMessage = "Введіть прізвище та ім'я")]
    public string FullName { get; set; }
    
    public List<OrderProduct> OrdersProducts { get; set;}
}