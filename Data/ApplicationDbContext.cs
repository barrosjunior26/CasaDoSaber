using CasaDoSaber.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoSaber
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> tb_usuarios {  get; set; }
        public DbSet<AlunoModel> tb_alunos { get; set; }
        public DbSet<CarreirasModel> tb_carreiras { get; set; }
    }
}