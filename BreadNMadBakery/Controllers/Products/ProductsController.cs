using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers;

public class ProductsController : Controller 
{
    private ProductsRepository _storage;
    public ProductsController(ProductsRepository storage)
    {
        _storage = storage;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var allProducts = _storage.GetAllProducts(); 
        return View(allProducts);
    }
}