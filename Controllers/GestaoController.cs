using CasaDoSaber.Models;
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

        [HttpPost]
        public async Task<IActionResult> Publiseer(CarreirasModel carreira)
        {
            if (ModelState.IsValid)
            {
                _context.tb_carreiras.Add(carreira);
                await _context.SaveChangesAsync();
                return RedirectToAction("Carreiras", "Home");
            }
            return View(carreira);
        }
    }
}
