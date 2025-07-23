namespace cadastro_pessoas_fisicas_juridicas_api.Application.DTOs
{
    public class TelefoneDto
    {
        public string Ddd { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public TipoTelefoneDto Tipo { get; set; }
        public string? Assunto { get; set; }
        public string? FalarCom { get; set; }
        public bool EhWhatsApp { get; set; }

    }
}
