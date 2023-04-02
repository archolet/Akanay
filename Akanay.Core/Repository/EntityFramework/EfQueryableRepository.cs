using Akanay.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akanay.Core.Repository.EntityFramework
{
    public class EfQueryableRepository<T>:IQueryableRepository<T> where T : class, IEntity, new()
    {
        //private IQueryable<T> _entities;
        //public EfQueryableRepository(IQueryable<T> entities)
        //{
        //    _entities = entities;
        //}
        //public IQueryable<T> Table => _entities;




        private DbContext _context;
        DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table { get; }


    }

}
