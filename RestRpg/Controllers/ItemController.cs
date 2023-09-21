using Microsoft.AspNetCore.Http;
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
        public IActionResult Get(int id)
        {
            return Ok(_apiDbContext.Items.Find(id));
        }

        // POST api/<ItemController>
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            _apiDbContext.Items.Add(item);
            _apiDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, "Item Created");
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item newInfo)
        {
            var item = _apiDbContext.Items.Find(id);
            if (item == null)
                return NotFound("Item not found");
            item.Name = newInfo.Name;
            item.Price = newInfo.Price;
            _apiDbContext.SaveChanges();
            return Ok("Item Updated");
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _apiDbContext.Items.Find(id);
            _apiDbContext.Items.Remove(item);
            _apiDbContext.SaveChanges();
            return Ok("Item Deleted");
        }
    }
}
