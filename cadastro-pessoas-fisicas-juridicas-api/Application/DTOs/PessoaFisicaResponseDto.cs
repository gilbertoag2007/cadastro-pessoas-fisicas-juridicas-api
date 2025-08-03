using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization;
using System.Text.Json.Serialization;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.DTOs
{
    public class PessoaFisicaResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string OrgaoEmissor { get; set; } = string.Empty;
        public DateOnly DataEmissao { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string NomePai { get; set; } = string.Empty;
        public string NomeMae { get; set; } = string.Empty;
        public bool EstaAtivo { get; set; }

        [JsonConverter(typeof(DateTimeConverterComHora))]
        public DateTime DataCadastro { get; set; }

        public EnderecoDto? Endereco { get; set; }
        public List<TelefoneDto> Telefones { get; set; } = new();
        public PresencaOnlineDto? PresencaOnline { get; set; }

    }
}
