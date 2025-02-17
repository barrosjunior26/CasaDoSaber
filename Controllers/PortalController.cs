using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carreiras()
        {
            return View();
        }
    }
}
