using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Configurar o AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
