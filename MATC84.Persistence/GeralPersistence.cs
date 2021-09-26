using System.Threading.Tasks;
using MATC84.Persistence.Context;
using MATC84.Persistence.Contracts;

namespace MATC84.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly MATC84Context context;

        public GeralPersistence(MATC84Context context)
        {
            this.context = context;
        }
        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public void Insert<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }
    }
}