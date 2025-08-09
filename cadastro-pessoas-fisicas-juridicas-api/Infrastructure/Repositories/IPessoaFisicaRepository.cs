using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories
{
    public interface IPessoaFisicaRepository
    {
        Task<PessoaFisica?> ObterPorIdAsync(int id);
        Task<IEnumerable<PessoaFisica>> ListarTodosAsync();
        Task AdicionarAsync(PessoaFisica pessoa);
        Task AtualizarAsync(PessoaFisica pessoa);
        Task RemoverAsync(int id);
        Task<bool> ExisteCpfAsync(string cpf);


    }
}
