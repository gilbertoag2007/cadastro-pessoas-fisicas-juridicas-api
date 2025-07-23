using System.ComponentModel.DataAnnotations;

namespace cadastro_pessoas_fisicas_juridicas_api.Domain.Entities
{
    public class PresencaOnLine
    {
        [Key]
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? LinkedInUrl { get; set; }

        public int? PessoaFisicaId { get; set; }
        public PessoaFisica? PessoaFisica { get; set; }

        public int? PessoaJuridicaId { get; set; }
        public PessoaJuridica? PessoaJuridica { get; set; }

    }
}
