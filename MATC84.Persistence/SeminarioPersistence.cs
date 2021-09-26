using System.Linq;
using System.Threading.Tasks;
using MATC84.Domain.Model;
using MATC84.Persistence.Context;
using MATC84.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MATC84.Persistence
{
    public class SeminarioPersistence : ISeminarioPersistence
    {
        public MATC84Context context;
        public SeminarioPersistence(MATC84Context context)
        {
            this.context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Seminario[]> GetAllSeminarios()
        {
            IQueryable<Seminario> query = this.context.Seminario.Include(s => s.Grupo)
                                                                .OrderBy(s => s.SeminarioId);

            return await query.ToArrayAsync();
        }

        public async Task<Seminario[]> GetSeminariosByTema(string tema)
        {
            IQueryable<Seminario> query = this.context.Seminario.Include(s => s.Grupo);

            query = query.OrderBy(s => s.SeminarioId)
                            .Where(s => s.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Seminario[]> GetSeminariosByPessoa(string nomePessoa)
        {
            IQueryable<Seminario> query = this.context.Seminario.Include(s => s.Grupo);

            query = query.OrderBy(s => s.SeminarioId)
                        .Where(s => 
                                    s.Grupo.Any(g => 
                                                g.Nome.ToLower().Contains(nomePessoa.ToLower())));

            return await query.ToArrayAsync();
        }

        public async Task<Seminario> GetSeminarioById(int id)
        {
            IQueryable<Seminario> query = this.context.Seminario.Include(s => s.Grupo);

            query = query.OrderBy(s => s.SeminarioId)
                        .Where(s => s.SeminarioId == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}