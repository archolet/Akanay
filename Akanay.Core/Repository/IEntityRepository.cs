using Akanay.Core.Entities;
using System.Linq.Expressions;

namespace Akanay.Core.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll(Expression<Func<T, bool>> filter = null);
        
        T Get(Expression<Func<T, bool>> filter);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

    }
}
