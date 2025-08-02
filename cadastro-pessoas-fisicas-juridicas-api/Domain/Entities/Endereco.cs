using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_pessoas_fisicas_juridicas_api.Domain.Entities
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;

        public int? PessoaFisicaId { get; set; }
        public PessoaFisica? PessoaFisica { get; set; }

        public int? PessoaJuridicaId { get; set; }
        public PessoaJuridica? PessoaJuridica { get; set; }

    }
}
