using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {

          private readonly AppDbContext _context;

        public PessoaJuridicaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PessoaJuridica?> ObterPorIdAsync(int id)
        {
            return await _context.PessoaJuridica
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .Include(p => p.PresencaOnline)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PessoaJuridica>> ListarTodosAsync()
        {
            return await _context.PessoaJuridica
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .Include(p => p.PresencaOnline)
                .ToListAsync();
        }

        public async Task AdicionarAsync(PessoaJuridica pessoa)
        {
            await _context.PessoaJuridica.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(PessoaJuridica pessoa)
        {
            _context.PessoaJuridica.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            if (pessoa != null)
            {
                _context.PessoaJuridica.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCnpjAsync(string cnpj)
        {
            return await _context.PessoaJuridica.AnyAsync(p => p.Cnpj == cnpj);
        }
    }

    }

