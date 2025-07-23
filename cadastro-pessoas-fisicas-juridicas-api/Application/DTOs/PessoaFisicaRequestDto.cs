namespace cadastro_pessoas_fisicas_juridicas_api.Application.DTOs
{
    public class PessoaFisicaRequestDto
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

        public EnderecoDto? Endereco { get; set; }
        public List<TelefoneDto> Telefones { get; set; } = new();
        public PresencaOnlineDto? PresencaOnline { get; set; }
    }
}
