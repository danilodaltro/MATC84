using System;
using System.Threading.Tasks;
using MATC84.Application.Contracts;
using MATC84.Domain.Model;
using MATC84.Persistence.Contracts;

namespace MATC84.Application
{
    public class SeminarioService : ISeminarioService
    {
        private readonly IGeralPersistence geralPersist;
        private readonly ISeminarioPersistence seminarioPersist;
        public SeminarioService(IGeralPersistence geralPersist, ISeminarioPersistence seminarioPersist)
        {
            this.seminarioPersist = seminarioPersist;
            this.geralPersist = geralPersist;
        }

        public async Task<Seminario> AddSeminario(Seminario seminario)
        {
            try
            {
                this.geralPersist.Insert<Seminario>(seminario);
                if (await geralPersist.SaveChangesAsync())
                {
                    var seminarioRetorno = await this.seminarioPersist.GetSeminarioById(seminario.SeminarioId);
                    return seminarioRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Seminario> UpdateSeminario(int id, Seminario seminario)
        {
            try
            {
                var seminarioUp = await this.seminarioPersist.GetSeminarioById(id);
                if (seminarioUp == null) return null;

                seminario.SeminarioId = id;
                this.geralPersist.Update<Seminario>(seminario);

                if (await geralPersist.SaveChangesAsync())
                {
                    var seminarioRetorno = await seminarioPersist.GetSeminarioById(seminario.SeminarioId);
                    return seminarioRetorno;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSeminario(int id)
        {
            try
            {
                Seminario seminario = await this.seminarioPersist.GetSeminarioById(id);
                if (seminario == null) throw new Exception("O seminario a ser deletado não foi encontrado.");

                this.geralPersist.Delete<Seminario>(seminario);
                return await geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Seminario[]> GetAllSeminarios()
        {
            try
            {
                var seminarios = await this.seminarioPersist.GetAllSeminarios();
                if (seminarios == null) return null;

                return seminarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Seminario[]> GetAllSeminariosByPessoa(string nomePessoa)
        {
            try
            {
                var seminarios = await this.seminarioPersist.GetSeminariosByPessoa(nomePessoa);
                if (seminarios == null) return null;

                return seminarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Seminario[]> GetAllSeminariosByTema(string tema)
        {
            try
            {
                var seminarios = await this.seminarioPersist.GetSeminariosByTema(tema);
                if (seminarios == null) return null;

                return seminarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Seminario> GetSeminarioById(int id)
        {
            try
            {
                var seminarios = await this.seminarioPersist.GetSeminarioById(id);
                if (seminarios == null) return null;

                return seminarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}