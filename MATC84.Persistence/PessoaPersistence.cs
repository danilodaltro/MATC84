using System.Linq;
using System.Threading.Tasks;
using MATC84.Domain.Model;
using MATC84.Persistence.Context;
using MATC84.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MATC84.Persistence
{
    public class PessoaPersistence : IPessoaPersistence
    {
        public MATC84Context context;
        public PessoaPersistence(MATC84Context context)
        {
            this.context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Pessoa[]> GetAllPessoas()
        {
            IQueryable<Pessoa> query = this.context.Pessoa.Include(p => p.Seminario).OrderBy(p => p.PessoaId);

            return await query.ToArrayAsync();

        }

        public async Task<Pessoa> GetPessoaById(int id)
        {
            IQueryable<Pessoa> query = this.context.Pessoa.Include(p => p.Seminario);

            query = query.OrderBy(p => p.PessoaId).Where(p => p.PessoaId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetPessoaByMatricula(string matricula)
        {
            IQueryable<Pessoa> query = this.context.Pessoa.Include(p => p.Seminario);

            query = query.OrderBy(p => p.PessoaId).Where(p => p.Matricula == matricula);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa[]> GetPessoasByIdade(int idade)
        {
            IQueryable<Pessoa> query = this.context.Pessoa.Include(p => p.Seminario);

            query = query.OrderBy(p => p.PessoaId).Where(p => p.Idade == idade);

            return await query.ToArrayAsync();
        }

        public async Task<Pessoa[]> GetPessoasByNome(string nome)
        {
            IQueryable<Pessoa> query = this.context.Pessoa.Include(p => p.Seminario);

            query = query.OrderBy(p => p.PessoaId)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}