using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.DAL;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class StoreRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        DbContext dbContext { get; }
        DbSet<TEntity> dbSet { get; }

        public StoreRepository(StoreDbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity model)
        {
            dbSet.Add(model);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = dbContext.Find<TEntity>(id);
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

        public virtual void Update(TEntity model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }

    public class UserRepository : StoreRepository<User>
    {
        public UserRepository(StoreDbContext _dbContext) : base(_dbContext)
        {
        }
    }

    public class OrderRepository : StoreRepository<Order>
    {
        public OrderRepository(StoreDbContext _dbContext) : base(_dbContext)
        {
        }
    }

    public class RoleRepository : StoreRepository<Role>
    {
        public RoleRepository(StoreDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
