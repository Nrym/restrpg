using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestRpg.Data;
using RestRpg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            return Ok(await _apiDbContext.Items.ToListAsync());
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _apiDbContext.Items.FindAsync(id));
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            await _apiDbContext.Items.AddAsync(item);
            await _apiDbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, "Item Created");
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item newInfo)
        {
            var item = await _apiDbContext.Items.FindAsync(id);
            if (item == null)
                return NotFound("Item not found");
            item.Name = newInfo.Name;
            item.Price = newInfo.Price;
            item.Amount = newInfo.Amount;
            await _apiDbContext.SaveChangesAsync();
            return Ok("Item Updated");
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _apiDbContext.Items.FindAsync(id);
            _apiDbContext.Items.Remove(item);
            await _apiDbContext.SaveChangesAsync();
            return Ok("Item Deleted");
        }
    }
}
