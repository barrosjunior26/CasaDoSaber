using System.Diagnostics;
using CasaDoSaber.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Carreiras(string query, string tipoVaga)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(_context.tb_carreiras.ToList());
            }else if (tipoVaga == "ModoTrabalho")
            {
                return View(_context.tb_carreiras.Where(v => v.ModoTrabalho.Contains(query)));
            }else if(tipoVaga == "TipoVaga")
            {
                return View(_context.tb_carreiras.Where(v => v.TipoVaga.Contains(query)));
            }else if (tipoVaga == "Estado")
            {
                return View(_context.tb_carreiras.Where(v => v.Estado.Contains(query)));
            }
            else
            {
                IEnumerable<CarreirasModel> carreiras = _context.tb_carreiras.ToList();
                return View(carreiras);
            }
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CarreirasModel detalhes = _context.tb_carreiras.FirstOrDefault(d => d.Codigo == id);

            if (detalhes == null)
            {
                return NotFound();
            }

            return View(detalhes);
        }
    }
}
