using System;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void Create(TEntity item);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Update(TEntity item);

        void Delete(int id);
    }
}
