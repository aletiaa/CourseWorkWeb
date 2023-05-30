using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BreadNMadBakery.Models;

public class AboutController : Controller
{
    [Route("/[controller]/About")]
    [HttpGet]

    public IActionResult Index()
    {
        return View();
    }
}