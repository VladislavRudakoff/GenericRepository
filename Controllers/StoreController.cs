using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Controllers
{
    [ApiController]
    public class StoreController<TValue> : ControllerBase where TValue : class, IBaseEntity, new()
    {
        readonly IGenericRepository<TValue> storeRepository;
        readonly TValue modelInstance;

        public StoreController(StoreRepository<TValue> _repository)
        {
            storeRepository = _repository;
            modelInstance = new TValue();
        }

        [HttpPost("{modelInstance.GetType()}")]
        public void Post()
        {
            storeRepository.Create(modelInstance);
        }

        [HttpGet]
        public IEnumerable<TValue> GetAll()
        {
            return storeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IEnumerable<TValue> Get(int id)
        {
            return storeRepository.Get(x => x.Id == id);
        }

        [HttpPut]
        public void Update(int id)
        {
            modelInstance.Id = id;
            storeRepository.Update(modelInstance);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            modelInstance.Id = id;
            storeRepository.Delete(modelInstance);
        }

    }

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : StoreController<User>
    {
        public UserController(StoreRepository<User> _repository) : base(_repository)
        {
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class OderController : StoreController<Order>
    {
        public OderController(StoreRepository<Order> _repository) : base(_repository)
        {
        }
    }
}
