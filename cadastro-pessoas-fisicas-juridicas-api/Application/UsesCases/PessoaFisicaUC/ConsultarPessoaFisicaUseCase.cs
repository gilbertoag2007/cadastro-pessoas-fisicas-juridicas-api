using AutoMapper;
using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC
{
    public class ConsultarPessoaFisicaUseCase
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public ConsultarPessoaFisicaUseCase(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PessoaFisicaResponseDto?> ObterPorIdAsync(int id)
        {
            var entity = await _repository.ObterPorIdAsync(id);
            return entity == null ? null : _mapper.Map<PessoaFisicaResponseDto>(entity);
        }

        public async Task<IEnumerable<PessoaFisicaResponseDto>> ListarTodosAsync()
        {
            var entidades = await _repository.ListarTodosAsync();
            return _mapper.Map<IEnumerable<PessoaFisicaResponseDto>>(entidades);
        }


    }
}
