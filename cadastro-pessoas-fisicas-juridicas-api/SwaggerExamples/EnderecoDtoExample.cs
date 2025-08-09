using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace cadastro_pessoas_fisicas_juridicas_api.SwaggerExamples
{
    public class EnderecoDtoExample : IExamplesProvider<EnderecoDto>
    {
        public EnderecoDto GetExamples()
        {
            return new EnderecoDto
            {
                Logradouro = "Avenida Paulista",
                Numero = "1000",
                Complemento = "Apto 101",
                Bairro = "Bela Vista",
                Cidade = "São Paulo",
                Uf = "SP",
                Cep = "01310-100"
            };
        }
    }
}
