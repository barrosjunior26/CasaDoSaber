using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CasaDoSaber.Models
{
    public class AlunoModel
    {
        [Key, DisplayName("Matrícula")]
        public int Matricula { get; set; }
        [DisplayName("Contrato")]
        public string Contrato { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        [DisplayName("Série")]
        public string Serie { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        [DisplayName("Data de matrícula")]
        public DateOnly DtMatricula { get; set; }
        [DisplayName("Português")]
        public double? Portugues { get; set; }
        [DisplayName("Matemática")]
        public double? Matematica { get; set; }
        [DisplayName("Ciências")]
        public double? Ciencias { get; set; }
        [DisplayName("Língua estrangeira")]
        public double? Estrangeira { get; set; }
        [DisplayName("Geografia")]
        public double? Geografia { get; set; }
        [DisplayName("Média geral")]
        public double? MediaGeral { get; set; }
        [DisplayName("Observações")]
        public string? Observacoes { get; set; } = string.Empty;
        [DisplayName("Foto do aluno")]
        public byte[]? imagemAluno { get; set; }
        public string TipoImagem { get; set; } = string.Empty;
    }
}
