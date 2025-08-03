using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.DTOs
{
    public class PessoaFisicaRequestDto
    {

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter exatamente 11 dígitos numéricos.")]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O RG deve ter no máximo 20 caracteres.")]
        public string Rg { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O órgão emissor deve ter no máximo 20 caracteres.")]
        public string OrgaoEmissor { get; set; } = string.Empty;

        public DateOnly? DataEmissao { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateOnly? DataNascimento { get; set; }

        [StringLength(100, ErrorMessage = "O nome do pai deve ter no máximo 100 caracteres.")]
        public string NomePai { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O nome da mãe deve ter no máximo 100 caracteres.")]
        public string NomeMae { get; set; } = string.Empty;

        public bool EstaAtivo { get; set; }

        public EnderecoDto? Endereco { get; set; }

        [MinLength(1, ErrorMessage = "Ao menos um telefone deve ser informado.")]
        public List<TelefoneDto> Telefones { get; set; } = new();

        public PresencaOnlineDto? PresencaOnline { get; set; }
    }
}
