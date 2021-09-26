using System.Threading.Tasks;
using MATC84.Domain.Model;

namespace MATC84.Application.Contracts
{
    public interface ISeminarioService
    {
        public Task<Seminario> AddSeminario(Seminario seminario);
        public Task<Seminario> UpdateSeminario(int id, Seminario seminario);
        public Task<bool> DeleteSeminario(int id);
        public Task<Seminario[]> GetAllSeminarios();
        public Task<Seminario[]> GetAllSeminariosByTema(string tema);
        public Task<Seminario[]> GetAllSeminariosByPessoa(string nomePessoa);
        public Task<Seminario> GetSeminarioById(int id);
    }
}