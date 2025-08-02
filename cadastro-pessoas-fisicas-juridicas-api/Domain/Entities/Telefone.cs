using cadastro_pessoas_fisicas_juridicas_api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_pessoas_fisicas_juridicas_api.Domain.Entities
{
    [Table("telefone")]
    public class Telefone
    {
       [Key]
        public int Id { get; set; }  
        public string Ddd { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public TipoTelefone Tipo { get; set; }
        public string? Assunto { get; set; }
        public string? FalarCom { get; set; }
        public bool EhWhatsApp { get; set; }

        // Relacionamentos opcionais
        public int? PessoaFisicaId { get; set; }
        public PessoaFisica? PessoaFisica { get; set; }

        public int? PessoaJuridicaId { get; set; }
        public PessoaJuridica? PessoaJuridica { get; set; }

    }
}
