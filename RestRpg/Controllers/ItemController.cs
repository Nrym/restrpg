using Microsoft.AspNetCore.Mvc;
using RestRpg.Data;
using RestRpg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestRpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ApiDbContext _apiDbContext;

        public ItemController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _apiDbContext.Items;
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _apiDbContext.Items.Find(id);
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] Item item)
        {
            _apiDbContext.Items.Add(item);
            _apiDbContext.SaveChanges();
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item newInfo)
        {
            var item = _apiDbContext.Items.Find(id);
            item.Name = newInfo.Name;
            item.Price = newInfo.Price;
            _apiDbContext.SaveChanges();
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _apiDbContext.Items.Find(id);
            _apiDbContext.Items.Remove(item);
            _apiDbContext.SaveChanges();
        }
    }
}
