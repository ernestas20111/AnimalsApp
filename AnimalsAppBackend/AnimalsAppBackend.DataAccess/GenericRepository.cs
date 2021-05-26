using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppBackend.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AnimalsAppDbContext _animalsAppDbContext;

        public GenericRepository(AnimalsAppDbContext animalsAppDbContext)
        {
            _animalsAppDbContext = animalsAppDbContext;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _animalsAppDbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _animalsAppDbContext.Set<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _animalsAppDbContext.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual void Remove(TEntity entity)
        {
            _animalsAppDbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _animalsAppDbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _animalsAppDbContext.Set<TEntity>().Add(entity).Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _animalsAppDbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _animalsAppDbContext.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _animalsAppDbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}
