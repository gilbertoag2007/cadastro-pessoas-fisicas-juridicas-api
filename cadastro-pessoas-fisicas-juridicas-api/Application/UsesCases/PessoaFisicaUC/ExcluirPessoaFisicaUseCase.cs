using cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories;

namespace cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaFisicaUC
{
    public class ExcluirPessoaFisicaUseCase
    {
        private readonly IPessoaFisicaRepository _repository;

        public ExcluirPessoaFisicaUseCase(IPessoaFisicaRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.RemoverAsync(id);
        }
    }
}
