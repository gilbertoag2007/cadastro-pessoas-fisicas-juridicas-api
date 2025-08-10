using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Swagger.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;

namespace cadastro_pessoas_fisicas_juridicas_api.Swagger.SwaggerExamples
{
    public class PessoaFisicaRequestDtoExample : IExamplesProvider<PessoaFisicaRequestDto>
    {
        public PessoaFisicaRequestDto GetExamples()
        {
            return new PessoaFisicaRequestDto
            {
                Nome = "João da Silva",
                Cpf = "12345678909",
                Rg = "MG1234567",
                OrgaoEmissor = "SSP",
                DataEmissao = DateOnly.ParseExact("15/08/2010", "dd/MM/yyyy", null),
                DataNascimento = DateOnly.ParseExact("20/05/1983", "dd/MM/yyyy", null),
                NomePai = "José da Silva",
                NomeMae = "Maria da Silva",
                EstaAtivo = true,
                Endereco = new EnderecoDtoExample().GetExamples(),
                Telefones = new TelefoneDtoExample().GetExamples(),
                PresencaOnline = new PresencaOnlineDtoExample().GetExamples()
            };
        }
    }
}
