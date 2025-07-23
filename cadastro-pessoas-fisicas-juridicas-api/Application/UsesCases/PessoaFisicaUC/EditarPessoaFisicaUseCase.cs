using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC
{
    public class EditarPessoaFisicaUseCase
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public EditarPessoaFisicaUseCase(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(int id, PessoaFisicaRequestDto dto)
        {
            var entity = _mapper.Map<PessoaFisica>(dto);
            await _repository.AtualizarAsync(entity);
        }

    }
}
