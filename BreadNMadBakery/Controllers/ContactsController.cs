using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BreadNMadBakery.Models;

public class ContactsController : Controller
{
    [Route("/[controller]/Contacts")]
    [HttpGet]

    public IActionResult Index()
    {
        return View();
    }
}