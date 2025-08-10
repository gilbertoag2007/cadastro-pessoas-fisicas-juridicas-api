using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Application.Validators;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization;
using cadastro_pessoas_fisicas_juridicas_api.Middlewares;
using cadastro_pessoas_fisicas_juridicas_api.Swagger.Filters;
using cadastro_pessoas_fisicas_juridicas_api.Swagger.SwaggerExamples;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Environment.EnvironmentName = Environments.Development;

// Add services to the container.

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API de Cadastro de Pessoas F�sicas e Jur�dicas",
        Version = "v1"
    });
    c.SchemaFilter<EnumSchemaFilter>();

    // Ativa os filtros de exemplo no gerador (SwaggerGenOptions)
    c.ExampleFilters();
});

// Registrar exemplos de DTOs para Swagger
builder.Services.AddSwaggerExamplesFromAssemblyOf<PessoaFisicaRequestDtoExample>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<PessoaJuridicaRequestDtoExample>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<EnderecoDtoExample>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<PresencaOnlineDtoExample>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<TelefoneDtoExample>();

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrando reposit�rios e casos de uso
builder.Services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
builder.Services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();

builder.Services.AddScoped<CadastrarPessoaFisicaUseCase>();
builder.Services.AddScoped<ConsultarPessoaFisicaUseCase>();
builder.Services.AddScoped<EditarPessoaFisicaUseCase>();
builder.Services.AddScoped<ExcluirPessoaFisicaUseCase>();

builder.Services.AddScoped<CadastrarPessoaJuridicaUseCase>();
builder.Services.AddScoped<ConsultarPessoaJuridicaUseCase>();
builder.Services.AddScoped<EditarPessoaJuridicaUseCase>();
builder.Services.AddScoped<ExcluirPessoaJuridicaUseCase>();

builder.Services.AddAutoMapper(typeof(Program));

// Configura��es JSON com conversores customizados
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new NullableDateOnlyConverter());
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverterComHora());
    });

// FluentValidation: registra todos os validadores e habilita valida��o autom�tica
builder.Services.AddValidatorsFromAssemblyContaining<PessoaFisicaRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Cultura PT-BR para datas
var cultureInfo = new CultureInfo("pt-BR");
cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
cultureInfo.DateTimeFormat.DateSeparator = "/";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

app.UseMiddleware<SecurityHeadersMiddleware>();
/*

// Middleware para adicionar cabe�alhos de seguran�a
app.Use(async (context, next) =>
{
    // Enforce HTTPS Strict Transport Security (HSTS) para garantir comunica��o segura
    context.Response.Headers["Strict-Transport-Security"] = "max-age=63072000; includeSubDomains; preload";
 
    // Previne MIME-type sniffing (impede que navegador interprete tipos errados)
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
      
     // Protege contra clickjacking
     context.Response.Headers["X-Frame-Options"] = "DENY";
 
    // Controla a informa��o enviada no header Referer para proteger dados sens�veis
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

    // Controla permiss�es de recursos sens�veis do navegador (microfone, c�mera, etc)
    context.Response.Headers["Permissions-Policy"] = "geolocation=(), microphone=(), camera=(), interest-cohort=()";

    // Remove informa��es do servidor para n�o expor vulnerabilidades
    context.Response.Headers.Remove("Server");

    // Evita cache de respostas da API (especialmente dados sens�veis)
    context.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";

    
// Pol�tica restritiva para carregamento de recursos e mitiga��o de XSS
  context.Response.Headers["Content-Security-Policy"] = "default-src 'none'; frame-ancestors 'none'; base-uri 'none'; form-action 'none'";
    /*


// CORS: Deve ser configurado estritamente para dom�nios confi�veis (exemplo com um dom�nio)
//   context.Response.Headers["Access-Control-Allow-Origin"] = "https://seudominio.com";
//   context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
//   context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization";
//   context.Response.Headers["Access-Control-Allow-Credentials"] = "true";


    await next();
});

*/

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure o pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cadastro v1");
        // Aqui N�O chama c.ExampleFilters() - esse m�todo n�o existe para SwaggerUIOptions.
        // Os exemplos j� est�o configurados via AddSwaggerGen
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
