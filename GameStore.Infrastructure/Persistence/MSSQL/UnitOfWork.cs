using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities.Base;
using GameStore.Domain.Entities.Base.Interfaces;
using Microsoft.Extensions.Configuration;
using IUnitOfWork = GameStore.Application.Interfaces.IUnitOfWork;

namespace GameStore.Infrastructure.Persistence.MSSQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<int>
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                {
                    return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
                }
            }

            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_applicationDbContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> Commit()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
