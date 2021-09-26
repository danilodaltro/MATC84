using System.Threading.Tasks;
using MATC84.Domain.Model;

namespace MATC84.Persistence.Contracts
{
    public interface IPessoaPersistence
    {
        public Task<Pessoa[]> GetAllPessoas();
        public Task<Pessoa[]> GetPessoasByNome(string nome);
        public Task<Pessoa[]> GetPessoasByIdade(int idade);
        public Task<Pessoa> GetPessoaByMatricula(string matricula);
        public Task<Pessoa> GetPessoaById(int id);
    }
}