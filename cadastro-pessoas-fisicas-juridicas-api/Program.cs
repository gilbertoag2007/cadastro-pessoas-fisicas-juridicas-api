using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Application.Validators;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Serialization;
using cadastro_pessoas_fisicas_juridicas_api.Middlewares;
using cadastro_pessoas_fisicas_juridicas_api.SwaggerExamples;
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
        Title = "API de Cadastro de Pessoas Físicas e Jurídicas",
        Version = "v1"
    });

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

// Registrando repositórios e casos de uso
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

// Configurações JSON com conversores customizados
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new NullableDateOnlyConverter());
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverterComHora());
    });

// FluentValidation: registra todos os validadores e habilita validação automática
builder.Services.AddValidatorsFromAssemblyContaining<PessoaFisicaRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Cultura PT-BR para datas
var cultureInfo = new CultureInfo("pt-BR");
cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
cultureInfo.DateTimeFormat.DateSeparator = "/";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure o pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cadastro v1");
        // Aqui NÃO chama c.ExampleFilters() - esse método não existe para SwaggerUIOptions.
        // Os exemplos já estão configurados via AddSwaggerGen
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
