using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers;

public class OrderController : Controller 
{
    private OrdersRepository _repository;
    public OrderController(OrdersRepository repository) 
    {
        _repository = repository;
    }

    public IActionResult NewOrder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        if (!ModelState.IsValid)
        {
            return View("NewOrder", order);
        }
        
        _repository.CreateOrder(order);

        return View("Order", order);
    }
}
