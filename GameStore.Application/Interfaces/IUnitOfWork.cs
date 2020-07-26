using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities.Base;

namespace GameStore.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<int>;

        Task<int> Commit();
    }
}
