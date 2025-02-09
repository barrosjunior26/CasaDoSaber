using CasaDoSaber.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CasaDoSaber.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public IActionResult Entrar()
        {
            ClaimsPrincipal loginUsuario = HttpContext.User;

            if (loginUsuario.Identity.IsAuthenticated)
            {
                return Redirect("/Portal/Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(string email, string senha)
        {
            UsuarioModel usuarios = _context.tb_usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            if (usuarios == null)
            {
                TempData["ErrorLogin"] = "Login ou senha estão incorretos! Por favor, tente novamente.";
                return View();
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuarios.Email));
            claims.Add(new Claim(ClaimTypes.Sid, usuarios.Id.ToString()));

            var identidadeUsuario = new ClaimsIdentity(claims, "CookieAuthentication");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identidadeUsuario);
            await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal, new AuthenticationProperties());
            return Redirect("/Portal/Index");
        }

        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login/Entrar");
        }
    }
}
