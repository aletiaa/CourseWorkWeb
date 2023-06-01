using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BreadNMadBakery.Models;

namespace BreadNMadBakery.Controllers;

public class HomeController : Controller
{
    private readonly ProductsRepository _productsRepository;

    public HomeController(ProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public IActionResult Index()
    {
        var random3Products = _productsRepository.GetRandomThreeProducts();
        return View(random3Products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
