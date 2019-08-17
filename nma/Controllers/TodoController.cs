using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nma.Models;

namespace nma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static IList<TodoItem> TodoItems = new List<TodoItem> {
                new TodoItem {
                    Id = 1,
                    Name = "Todo1",
                    Descriotion = "My first todo description"
                },
                new TodoItem {
                    Id = 2,
                    Name = "Todo2",
                    Descriotion = "My second todo description"
                }
            };

        // GET api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(TodoItems);
        }

        // GET api/Todo/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var foundTOdo = TodoItems.FirstOrDefault (x => x.Id == id);
            if (foundTOdo is null)
                return NotFound ();
            
            return Ok(foundTOdo);
        }

        // POST api/Todo
        [HttpPost]
        public void Post([FromBody] TodoItem value)
        {
            TodoItems.Add (value);
        }

        // PUT api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
