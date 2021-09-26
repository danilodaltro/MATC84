using System.Threading.Tasks;
using MATC84.Domain.Model;

namespace MATC84.Application.Contracts
{
    public interface IPessoaService
    {
        public Task<Pessoa> AddPessoa(Pessoa pessoa);
        public Task<Pessoa> UpdatePessoa(int id, Pessoa pessoa);
        public Task<bool> DeletePessoa(int id);
        public Task<Pessoa[]> GetAllPessoas();
        public Task<Pessoa[]> GetAllPessoasByNome(string nome);
        public Task<Pessoa[]> GetAllPessoasByIdade(int idade);
        public Task<Pessoa> GetPessoaByMatricula(string matricula);
        public Task<Pessoa> GetPessoaById(int id);
    }
}