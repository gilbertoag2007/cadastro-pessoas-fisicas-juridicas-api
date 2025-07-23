using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories
{
    public interface IPessoaJuridicaRepository
    {
        Task<PessoaJuridica?> ObterPorIdAsync(int id);
        Task<IEnumerable<PessoaJuridica>> ListarTodosAsync();
        Task AdicionarAsync(PessoaJuridica pessoa);
        Task AtualizarAsync(PessoaJuridica pessoa);
        Task RemoverAsync(int id);
        Task<bool> ExisteCnpjAsync(string cnpj);
    }
}
