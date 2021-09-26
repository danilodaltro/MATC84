using System;
using System.Threading.Tasks;
using MATC84.Application.Contracts;
using MATC84.Domain.Model;
using MATC84.Persistence.Contracts;

namespace MATC84.Application
{
    public class PessoaService : IPessoaService
    {
        private readonly IGeralPersistence geralPersist;
        private readonly IPessoaPersistence pessoaPersist;

        public PessoaService(IGeralPersistence geralPersist, IPessoaPersistence pessoaPersist)
        {
            this.pessoaPersist = pessoaPersist;
            this.geralPersist = geralPersist;
        }

        public async Task<Pessoa> AddPessoa(Pessoa pessoa)
        {
            try
            {
                this.geralPersist.Insert<Pessoa>(pessoa);
                if (await geralPersist.SaveChangesAsync())
                {
                    var pessoaRetorno = await this.pessoaPersist.GetPessoaById(pessoa.PessoaId);
                    return pessoaRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> UpdatePessoa(int id, Pessoa pessoa)
        {
            try
            {
                var pessoaUp = await this.pessoaPersist.GetPessoaById(id);
                if (pessoaUp == null) return null;

                pessoa.PessoaId = id;
                this.geralPersist.Update<Pessoa>(pessoa);

                if (await geralPersist.SaveChangesAsync())
                {
                    var pessoaRetorno = await pessoaPersist.GetPessoaById(pessoa.PessoaId);
                    return pessoaRetorno;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePessoa(int id)
        {
            try
            {
                Pessoa pessoa = await this.pessoaPersist.GetPessoaById(id);
                if (pessoa == null) throw new Exception("A pessoa a ser deletada não foi encontrada.");

                this.geralPersist.Delete<Pessoa>(pessoa);
                return await geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa[]> GetAllPessoas()
        {
            try
            {
                var pessoas = await this.pessoaPersist.GetAllPessoas();
                if (pessoas == null) return null;

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa[]> GetAllPessoasByIdade(int idade)
        {
            try
            {
                var pessoas = await this.pessoaPersist.GetPessoasByIdade(idade);
                if (pessoas == null) return null;

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa[]> GetAllPessoasByNome(string nome)
        {
            try
            {
                var pessoas = await this.pessoaPersist.GetPessoasByNome(nome);
                if (pessoas == null) return null;

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> GetPessoaById(int id)
        {
            try
            {
                var pessoas = await this.pessoaPersist.GetPessoaById(id);
                if (pessoas == null) return null;

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> GetPessoaByMatricula(string matricula)
        {
            try
            {
                var pessoas = await this.pessoaPersist.GetPessoaByMatricula(matricula);
                if (pessoas == null) return null;

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}