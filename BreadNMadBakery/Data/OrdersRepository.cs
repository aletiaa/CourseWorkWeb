using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class OrdersRepository 
{
    private ShopContext _db;
    private ProductsRepository _productsRepository;
    public OrdersRepository(ShopContext db,  ProductsRepository productsRepository)
    {
        _db = db;
        _productsRepository = productsRepository;
    }

    public void CreateOrder(Order order)
    {
        var allItems = Cart.Instance.GetAllItems();
        order.CreationDate = DateTime.Now;
        
        foreach (var item in allItems)
        {
            var productId = item.ProductId;
            Product product = _productsRepository.FindProduct(productId);

            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Order = order;
            orderProduct.Product = product;
            orderProduct.ProductQuantity = item.Quantity;
            order.OrdersProducts.Add(orderProduct);
        }
        
        _db.Orders.Add(order);

        _db.SaveChanges();

        Cart.Instance.Clear();
    }

    public List<Order> GetAllOrders()
    {
        var orders = _db.Orders.Include(o => o.OrdersProducts)
                               .ThenInclude(o => o.Product)
                               .ToList();

        return orders;
    }
}