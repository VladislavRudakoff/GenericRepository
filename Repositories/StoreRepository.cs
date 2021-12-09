using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class StoreRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        readonly DbContext dbContext;
        readonly DbSet<TEntity> dbSet;

        public StoreRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Create([FromBody]TEntity model)
        {
            dbSet.Add(model);
            dbContext.SaveChanges();
        }

        public void Delete(TEntity model)
        {
            dbContext.Remove(model);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        //TODO: Додумать как правильно передать ID для изменения строки
        public void Update([FromBody]TEntity model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
