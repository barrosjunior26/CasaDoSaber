using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GestaoController(ApplicationDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public IActionResult Publiseer()
        {
            return View();
        }
    }
}
