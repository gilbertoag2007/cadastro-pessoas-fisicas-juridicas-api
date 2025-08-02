using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace cadastro_pessoas_fisicas_juridicas_api.Domain.Entities
{
    [Table("pessoa_juridica")]
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public bool EhMatriz { get; set; }
        public string RamoAtividade { get; set; } = string.Empty;

        public Endereco? Endereco { get; set; }
        public List<Telefone> Telefones { get; set; } = new();
        public PresencaOnLine? PresencaOnline { get; set; }

    }
}
