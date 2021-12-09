using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController<TEntity> : ControllerBase where TEntity : class, IBaseEntity, new()
    {
        readonly IGenericRepository<TEntity> storeRepository;

        public StoreController(IGenericRepository<TEntity> _repository)
        {
            storeRepository = _repository;
        }

        [HttpPost]
        public void Post([FromBody]TEntity entity)
        {
            storeRepository.Create(entity);
        }

        [HttpGet]
        public IEnumerable<TEntity> GetAll()
        {
            return storeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IEnumerable<TEntity> Get(int id)
        {
            return storeRepository.Get(x => x.Id == id);
        }

        [HttpPut]
        public void Update(int id, [FromBody] TEntity entity)
        {
            entity.Id = id;
            storeRepository.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            storeRepository.Delete(id);
        }

    }

    public class UserController : StoreController<User>
    {
        public UserController(IGenericRepository<User> _repository) : base(_repository)
        {
        }
    }

    public class OrderController : StoreController<Order>
    {
        public OrderController(IGenericRepository<Order> _repository) : base(_repository)
        {
        }
    }

    public class RoleController : StoreController<Role>
    {
        public RoleController(IGenericRepository<Role> _repository) : base(_repository)
        {
        }
    }
}
