using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace cadastro_pessoas_fisicas_juridicas_api.Swagger.SwaggerExamples
{
    public class PresencaOnlineDtoExample : IExamplesProvider<PresencaOnlineDto>
    {
        public PresencaOnlineDto GetExamples()
        {
            return new PresencaOnlineDto
            {
                Email = "exemplo@email.com",
                WebsiteUrl = "https://www.exemplo.com",
                FacebookUrl = "https://www.facebook.com/exemplo",
                InstagramUrl = "https://www.instagram.com/exemplo",
                TwitterUrl = "https://twitter.com/exemplo",
                LinkedInUrl = "https://www.linkedin.com/in/exemplo"
            };
        }
    }
}
