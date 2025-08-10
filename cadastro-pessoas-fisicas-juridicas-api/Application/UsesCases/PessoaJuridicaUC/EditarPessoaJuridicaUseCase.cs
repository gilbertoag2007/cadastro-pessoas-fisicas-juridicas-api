using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC

{
    public class EditarPessoaJuridicaUseCase
    {
        private readonly IPessoaJuridicaRepository _repository;
        private readonly IMapper _mapper;

        public EditarPessoaJuridicaUseCase(IPessoaJuridicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(int id, PessoaJuridicaRequestDto dto)
        {
            var entity = await _repository.ObterPorIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Pessoa juridica {id} não encontrada.");

            _mapper.Map(dto, entity); // Atualiza os campos sem criar novo objeto

            await _repository.AtualizarAsync(entity);
        }
    }
}
