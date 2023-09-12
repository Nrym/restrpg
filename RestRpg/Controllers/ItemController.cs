using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestRpg.Models;
using System.Collections.Generic;

namespace RestRpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static List<Item> items = new List<Item>()
        {
            new Item() { Id = 0,Name="Item 0",Price=0.99},
            new Item() { Id = 1,Name="Item 1",Price=1.99},
            new Item() { Id = 2,Name="Item 2",Price=4.99},
            new Item() { Id = 3,Name="Item 3",Price=9.99}
        };

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        [HttpPost]
        public void Post([FromBody] Item item)
        {
            items.Add(item);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item item)
        {
            items[id] = item;
        }

        [HttpDelete("{id}")]
        public void Put(int id)
        {
            items.RemoveAt(id);
        }
    }
}
