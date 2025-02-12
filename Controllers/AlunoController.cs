using CasaDoSaber.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoSaber.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AlunoController(ApplicationDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            var numeroContrato = new AlunoModel
            {
                Contrato = Guid.NewGuid().ToString()
            };

            return View(numeroContrato);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(AlunoModel salvar, IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                if (imagem != null && imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await imagem.CopyToAsync(ms);
                        salvar.imagemAluno = ms.ToArray();
                        salvar.TipoImagem = imagem.ContentType;
                    }
                }

                _context.tb_alunos.Add(salvar);
                await _context.SaveChangesAsync();
                TempData["SucessoSalvar"] = "Dados gravados com sucesso!";
                return RedirectToAction("ListaAlunos");
            }

            TempData["ErroCadastro"] = "Não foi possível gravar os dados!";
            return View(salvar);
        }

        [HttpGet]
        public IActionResult ListaAlunos(string query, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(query))
            {
                IEnumerable<AlunoModel> listaAlunos = _context.tb_alunos;
                return View(listaAlunos);
            }else if (tipoPesquisa == "nome")
            {
                return View(_context.tb_alunos.Where(n => n.Nome.Contains(query)));
            }else if (tipoPesquisa == "cpf")
            {
                return View(_context.tb_alunos.Where(c => c.CPF.Contains(query)));
            }
            else
            {
                return View(_context.tb_alunos.ToList());
            }
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            AlunoModel detalhes = _context.tb_alunos.FirstOrDefault(d => d.Matricula == id);

            if (detalhes == null)
            {
                return NotFound();
            }

            return View(detalhes);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            AlunoModel detalhes = _context.tb_alunos.FirstOrDefault(d => d.Matricula == id);

            if (detalhes == null)
            {
                return NotFound();
            }

            return View(detalhes);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AlunoModel editar, IFormFile? novaImagem)
        {
            if (ModelState.IsValid)
            {
                var editarCadastro = _context.tb_alunos.Find(editar.Matricula);

                if (editarCadastro == null)
                {
                    return NotFound();
                }

                editarCadastro.Nome = editar.Nome;
                editarCadastro.RG = editar.RG;
                editarCadastro.Serie = editar.Serie;
                editarCadastro.Turno = editar.Turno;
                editarCadastro.Contrato = editar.Contrato;
                editarCadastro.Portugues = editar.Portugues;
                editarCadastro.Ciencias = editar.Ciencias;
                editarCadastro.Estrangeira = editar.Estrangeira;
                editarCadastro.Geografia = editar.Geografia;
                editarCadastro.Matematica = editar.Matematica;
                editarCadastro.MediaGeral = editar.MediaGeral;
                editarCadastro.Observacoes = editar.Observacoes;

                if (novaImagem != null && novaImagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await novaImagem.CopyToAsync(ms);
                        editarCadastro.imagemAluno = ms.ToArray();
                        editarCadastro.TipoImagem = novaImagem.ContentType;
                    }
                }

                _context.tb_alunos.Update(editarCadastro);
                await _context.SaveChangesAsync();
                TempData["SucessoAtualizar"] = "Dados atualizados com sucesso!";
                return RedirectToAction("ListaAlunos");
            }

            TempData["EdicaoError"] = "Não foi possível atualizar os dados!";
            return View(editar);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            var excluir = _context.tb_alunos.Find(id);

            if (excluir == null)
            {
                return NotFound();
            }

            AlunoModel alunoModel = _context.tb_alunos.FirstOrDefault(e => e.Matricula == id);

            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        [HttpPost]
        public IActionResult Excluir(AlunoModel excluir)
        {
            var delAluno = _context.tb_alunos.Find(excluir.Matricula);

            if (delAluno == null)
            {
                return NotFound();
            }

            _context.tb_alunos.Remove(delAluno);
            _context.SaveChanges();
            TempData["ExcluidoSucesso"] = "Cadastro excluído com sucesso!";
            return RedirectToAction("ListaAlunos");
        }

        [HttpGet]
        public IActionResult BuscarImagem(int id)
        {
            var obterImagem = _context.tb_alunos.Find(id);

            if(obterImagem?.imagemAluno != null)
            {
                return File(obterImagem.imagemAluno, obterImagem.TipoImagem);
            }

            return NotFound();
        }
    }
}
