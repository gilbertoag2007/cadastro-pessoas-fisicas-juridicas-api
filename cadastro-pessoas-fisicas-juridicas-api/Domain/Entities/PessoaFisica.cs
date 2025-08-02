using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_pessoas_fisicas_juridicas_api.Domain.Entities
{
    [Table("pessoa_fisica")]
    public class PessoaFisica
    {

        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Rg { get; set; } = string.Empty;

        public string OrgaoEmissor { get; set; } = string.Empty;

        public DateTime DataEmissao { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomePai { get; set; } = string.Empty;

        public string NomeMae { get; set; } = string.Empty;

        public bool EstaAtivo { get; set; }

        public DateTime DataCadastro { get; set; }

        public Endereco? Endereco { get; set; }

        public List<Telefone> Telefones { get; set; } = new();

        public PresencaOnLine? PresencaOnline { get; set; }
    }
}
