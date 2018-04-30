using DatabaseTest.Web.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseTest.Web.Models.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindAll()
        {
            var result = _dbSet.AsNoTracking().Where(t => t.IsDeleted == false).ToList();
            return result;
        }

        public IEnumerable<TEntity> FindAllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.ToList();

            return results;
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> prediction,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(prediction).ToList();
            return results;
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = _dbSet.AsNoTracking().Where(t => t.IsDeleted == false);

            return includeProperties.Aggregate(queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public TEntity FindByKey(int id)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(e => e.Id == id && e.IsDeleted == false);
        }

        public void Insert(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.LastModifiedAt = DateTime.UtcNow;
            entity.IsDeleted = false;

            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.LastModifiedAt = DateTime.UtcNow;

            _dbSet.Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}