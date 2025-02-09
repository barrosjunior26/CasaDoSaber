using System.Diagnostics;
using CasaDoSaber.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
