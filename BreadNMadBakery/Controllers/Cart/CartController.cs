using Microsoft.AspNetCore.Mvc;

public class CartController : Controller 
{
    public CartController() {}

    public IActionResult Index()
    {
        return View(Cart.Instance);
    }

    public IActionResult AddToCart(int id, string productName, string imageName, double price)
    {
        Cart.Instance.AddProduct(id, productName, imageName, price);
        return RedirectToAction("Index", "Cart");
    }

    public IActionResult RemoveFromCart(int id)
    {
        Cart.Instance.RemoveProduct(id);
        return RedirectToAction("Index", "Cart");
    }
}