using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories
{
    public class PessoaFisicaRepository: IPessoaFisicaRepository
    {
        private readonly AppDbContext _context;

        public PessoaFisicaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PessoaFisica?> ObterPorIdAsync(int id)
        {
            return await _context.PessoaFisica
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .Include(p => p.PresencaOnline)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PessoaFisica>> ListarTodosAsync()
        {
            return await _context.PessoaFisica
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .Include(p => p.PresencaOnline)
                .ToListAsync();
        }

        public async Task AdicionarAsync(PessoaFisica pessoa)
        {
            await _context.PessoaFisica.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(PessoaFisica pessoa)
        {
            _context.PessoaFisica.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            if (pessoa != null)
            {
                _context.PessoaFisica.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            return await _context.PessoaFisica.AnyAsync(p => p.Cpf == cpf);
        }



    }
}
