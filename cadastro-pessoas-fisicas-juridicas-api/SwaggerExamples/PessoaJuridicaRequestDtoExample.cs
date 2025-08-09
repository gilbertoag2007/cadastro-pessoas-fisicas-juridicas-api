using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace cadastro_pessoas_fisicas_juridicas_api.SwaggerExamples
{
    public class PessoaJuridicaRequestDtoExample : IExamplesProvider<PessoaJuridicaRequestDto>
    {
        public PessoaJuridicaRequestDto GetExamples()
        {
            return new PessoaJuridicaRequestDto
            {
               RazaoSocial="Empresa de TI S/A",
               Cnpj= "12345678000195",
                EhMatriz=true , 
                RamoAtividade ="Empresa de Tecnologia",
                Endereco = new EnderecoDtoExample().GetExamples(),
                Telefones = new TelefoneDtoExample().GetExamples(),
                PresencaOnline = new PresencaOnlineDtoExample().GetExamples()
            };
        }

    }
}
