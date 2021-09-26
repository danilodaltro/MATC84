using System.Threading.Tasks;

namespace MATC84.Persistence.Contracts
{
    public interface IGeralPersistence
    {
        public void Insert<T>(T entity) where T: class;
        public void Update<T>(T entity) where T: class;
        public void Delete<T>(T entity) where T: class;
        public Task<bool> SaveChangesAsync();
    }
}