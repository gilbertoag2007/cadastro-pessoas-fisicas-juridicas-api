namespace cadastro_pessoas_fisicas_juridicas_api.Application.DTOs
{
    public class PessoaJuridicaRequestDto
    {
        public string RazaoSocial { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public bool EhMatriz { get; set; }
        public string RamoAtividade { get; set; } = string.Empty;

        public EnderecoDto? Endereco { get; set; }
        public List<TelefoneDto>? Telefones { get; set; } = new();
        public PresencaOnlineDto? PresencaOnline { get; set; }
    }
}
