using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC
{
    public class ConsultarPessoaJuridicaUseCase
    {
        private readonly IPessoaJuridicaRepository _repository;
        private readonly IMapper _mapper;

        public ConsultarPessoaJuridicaUseCase(IPessoaJuridicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PessoaJuridicaResponseDto?> ObterPorIdAsync(int id)
        {
            var entity = await _repository.ObterPorIdAsync(id);
            return entity == null ? null : _mapper.Map<PessoaJuridicaResponseDto>(entity);
        }

        public async Task<IEnumerable<PessoaJuridicaResponseDto>> ListarTodosAsync()
        {
            var entidades = await _repository.ListarTodosAsync();
            return _mapper.Map<IEnumerable<PessoaJuridicaResponseDto>>(entidades);
        }
    }
}
