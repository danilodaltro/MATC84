using System.Threading.Tasks;
using MATC84.Domain.Model;

namespace MATC84.Persistence.Contracts
{
    public interface ISeminarioPersistence
    {
        public Task<Seminario[]> GetAllSeminarios();
        public Task<Seminario[]> GetSeminariosByTema(string tema);
        public Task<Seminario[]> GetSeminariosByPessoa(string nomePessoa);
        public Task<Seminario> GetSeminarioById(int id);
    }
}