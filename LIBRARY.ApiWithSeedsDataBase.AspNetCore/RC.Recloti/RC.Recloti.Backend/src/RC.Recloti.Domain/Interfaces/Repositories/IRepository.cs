using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IList<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby,
            params Expression<Func<TEntity, object>>[] includes);

        void Save(TEntity entity);

        void SaveMany(IList<TEntity> entity);

        void UpdateRange(List<TEntity> e);

        void Update(TEntity e);

        void Delete(TEntity entity);

        void DeleteMany(IList<TEntity> entity);
        Task<int> Count();
        Task<bool> Existe(Expression<Func<TEntity, bool>> where);
    }
}
