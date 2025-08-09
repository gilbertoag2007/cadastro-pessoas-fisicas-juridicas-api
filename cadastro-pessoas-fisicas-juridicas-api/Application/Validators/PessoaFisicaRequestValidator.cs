using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;
using FluentValidation;
using System.Globalization;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.Validators
{
    public class PessoaFisicaRequestValidator : AbstractValidator<PessoaFisicaRequestDto>
    {
        public PessoaFisicaRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .Must(CpfValido)
                .WithMessage("O CPF informado é inválido.");

               RuleFor(x => x.DataNascimento)
                   .LessThan(DateOnly.FromDateTime(DateTime.Today))
                   .WithMessage("A data de nascimento deve ser anterior a data atual.");

               RuleFor(x => x.DataEmissao)
                   .LessThan(DateOnly.FromDateTime(DateTime.Today))
                   .WithMessage("A data de emissão deve ser anterior a data atual.");
            

           
        }

        private bool CpfValido(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1) return false;

            var tempCpf = cpf.Substring(0, 9);
            var d1 = CalcularDigito(tempCpf, peso: 10);
            var d2 = CalcularDigito(tempCpf + d1, peso: 11);
            return cpf.EndsWith(d1.ToString() + d2.ToString());
        }

        private int CalcularDigito(string baseCpf, int peso)
        {
            var soma = 0;
            for (int i = 0; i < baseCpf.Length; i++)
                soma += (baseCpf[i] - '0') * (peso - i);
            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
