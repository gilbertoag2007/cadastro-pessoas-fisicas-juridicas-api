using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC
{
    public class ExcluirPessoaJuridicaUseCase
    {
        private readonly IPessoaJuridicaRepository _repository;

        public ExcluirPessoaJuridicaUseCase(IPessoaJuridicaRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.RemoverAsync(id);
        }
    }
}
