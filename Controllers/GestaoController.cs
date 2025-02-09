using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class GestaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
