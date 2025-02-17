using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CasaDoSaber.Models
{
    public class CarreirasModel
    {
        [Key, DisplayName("Código da vaga")]
        public int Codigo { get; set; }
        [DisplayName("Modo de trabalho"), Required]
        public string ModoTrabalho { get; set; } = string.Empty;
        [DisplayName("Tipo de vaga"), Required]
        public string TipoVaga { get; set; } = string.Empty;
        [Required]
        public string Estado { get; set; } = string.Empty;
        [Required, DisplayName("Data de publicação da vaga")]
        public DateTime Publicacao{ get; set; } = DateTime.Now;
        [Required, DisplayName("Data de encerramento da vaga")]
        public DateOnly EncerramentoVaga { get; set; }
        [Required, DisplayName("Descrição da vaga")]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        public string Responsabilidades { get; set; } = string.Empty;
        [Required, DisplayName("Requisitos e qualificações")]
        public string RequisitosQualificacoes { get; set; } = string.Empty;
        [DisplayName("Informações adicionais")]
        public string? Adicionais { get; set; }
    }
}
