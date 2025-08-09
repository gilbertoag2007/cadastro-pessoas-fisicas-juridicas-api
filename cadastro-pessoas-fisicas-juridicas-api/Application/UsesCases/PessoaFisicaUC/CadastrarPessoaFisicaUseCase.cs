using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC
{
    public class CadastrarPessoaFisicaUseCase
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public CadastrarPessoaFisicaUseCase(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> ExecuteAsync(PessoaFisicaRequestDto dto)
        {
            var entity = _mapper.Map<PessoaFisica>(dto);
            entity.DataCadastro = DateTime.UtcNow;
            await _repository.AdicionarAsync(entity);
            return entity.Id;
        }

        public static bool CpfValido(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            // CPFs inválidos conhecidos (todos os dígitos iguais)
            var invalidos = new[]
            {
        "00000000000", "11111111111", "22222222222", "33333333333",
        "44444444444", "55555555555", "66666666666", "77777777777",
        "88888888888", "99999999999"
    };
            if (invalidos.Contains(cpf))
                return false;

            // Valida os dois dígitos verificadores
            for (int j = 9; j < 11; j++)
            {
                int soma = 0;
                for (int i = 0; i < j; i++)
                    soma += (cpf[i] - '0') * ((j + 1) - i);

                int resto = (soma * 10) % 11;
                if (resto == 10) resto = 0;

                if ((cpf[j] - '0') != resto)
                    return false;
            }

            return true;
        }


    }
}
