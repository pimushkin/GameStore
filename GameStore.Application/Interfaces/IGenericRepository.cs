using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Base;

namespace GameStore.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity<int>
    {
        IEnumerable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
