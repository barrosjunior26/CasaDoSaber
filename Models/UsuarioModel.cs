using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CasaDoSaber.Models
{
    public class UsuarioModel
    {
        [Key, DisplayName("Matrícula")]
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public required string Nome { get; set; }
        [MaxLength(11)]
        public required string CPF { get; set; }
        [MaxLength(7)]
        public required string RG { get; set; }
        [DisplayName("Função")]
        public required string Funcao { get; set; }
        [DisplayName("Foto do usuário")]
        public byte[]? ImagemFuncionario { get; set; }
        public string TipoImagem { get; set; } = string.Empty;
        [DisplayName("E-mail")]
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
