using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace cadastro_pessoas_fisicas_juridicas_api.SwaggerExamples
{
    public class TelefoneDtoExample : IExamplesProvider<List<TelefoneDto>>
    {
        public List<TelefoneDto> GetExamples()
        {
            return new List<TelefoneDto>
            {
                   new TelefoneDto
                    {
                        Ddd = "21",
                        Numero = "987654321",
                        Tipo = TipoTelefoneDto.Celular,
                        Assunto = "Contato pessoal",
                        FalarCom = "João",
                        EhWhatsApp = true
                    },
                    new TelefoneDto
                    {
                        Ddd = "21",
                        Numero = "34567890",
                        Tipo = TipoTelefoneDto.Residencial,
                        Assunto = "Casa",
                        FalarCom = "Maria",
                        EhWhatsApp = false
                    }
            };
        }

    }
}
