using CasaDoSaber.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDoSaber.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<IActionResult> ListaUsuario(string search, string tipoBusca)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View(_context.tb_usuarios.ToList());
            }else if (tipoBusca == "todos")
            {
                return View(_context.tb_usuarios.Where(x => x.Nome.Contains(search) || x.Email.Contains(search)));
            }else if (tipoBusca == "email")
            {
                return View(_context.tb_usuarios.Where(x => x.Email.Contains(search)));
            }else if (tipoBusca == "nome")
            {
                return View(_context.tb_usuarios.Where(x => x.Nome.Contains(search)));
            }
            else
            {
                IEnumerable<UsuarioModel> listaUsuarios = await _context.tb_usuarios.ToListAsync();
                return View(listaUsuarios);
            }
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(UsuarioModel salvar, IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                if (imagem != null && imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await imagem.CopyToAsync(ms);
                        salvar.ImagemFuncionario = ms.ToArray();
                        salvar.TipoImagem = imagem.ContentType;
                    }
                }

                _context.tb_usuarios.Add(salvar);
                await _context.SaveChangesAsync();
                TempData["CadastroSucesso"] = "Dados gravados com sucesso!";
                return Redirect("/Usuario/ListaUsuario");
            }

            TempData["ErroCadastro"] = "Não foi possível salvar os dados, por favor, tente novamente.";
            return View(salvar);
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuarioModel detalhes = _context.tb_usuarios.FirstOrDefault(u => u.Id == id);

            if (detalhes == null)
            {
                return NotFound();
            }

            return View(detalhes);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuarioModel editar = _context.tb_usuarios.FirstOrDefault(e => e.Id == id);

            if(editar == null)
            {
                return NotFound();
            }

            return View(editar);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioModel editar, IFormFile? novaImagem)
        {
            if (ModelState.IsValid)
            {
                var editarCadastro = _context.tb_usuarios.Find(editar.Id);

                if (editarCadastro == null)
                {
                    return NotFound();
                }

                // Atualiza os campos de usuário
                editarCadastro.Nome = editar.Nome;
                editarCadastro.CPF = editar.CPF;
                editarCadastro.RG = editar.RG;
                editarCadastro.Funcao = editar.Funcao;
                editarCadastro.Email = editar.Email;
                editarCadastro.Senha = editar.Senha;

                // Se uma nova imagem foi enviada, atualiza a imagem
                if (novaImagem != null && novaImagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await novaImagem.CopyToAsync(ms);
                        editarCadastro.ImagemFuncionario = ms.ToArray();
                        editarCadastro.TipoImagem = novaImagem.ContentType;
                    }
                }

                _context.tb_usuarios.Update(editarCadastro);
                await _context.SaveChangesAsync();
                TempData["EdicaoSucesso"] = "Cadastro atualizado com sucesso!";
                return RedirectToAction("ListaUsuario");
            }

            TempData["EdicaoError"] = "Não foi possível atualizar os dados!";
            return View(editar);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuarioModel excluir = _context.tb_usuarios.FirstOrDefault(x => x.Id == id);

            if (excluir == null)
            {
                return NotFound();
            }

            return View(excluir);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(UsuarioModel excluir)
        {
            if (excluir == null)
            {
                return NotFound();
            }

            _context.tb_usuarios.Remove(excluir);
            await _context.SaveChangesAsync();
            TempData["ExcluirSucesso"] = "Cadastro excluído com sucesso!";
            return RedirectToAction("ListaUsuario");
        }

        [HttpGet]
        public IActionResult ObterImagem(int id)
        {
            var obterImagem = _context.tb_usuarios.Find(id);

            if (obterImagem?.ImagemFuncionario != null)
            {
                return File(obterImagem.ImagemFuncionario, obterImagem.TipoImagem);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
