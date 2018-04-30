using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DatabaseTest.Web.Models.Data
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindAllInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> prediction, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FindByKey(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}