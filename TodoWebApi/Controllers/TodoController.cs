using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Models;

namespace TodoWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _todoRepository.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = _todoRepository.Find(id);
            if(item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
                return BadRequest();

            _todoRepository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
                return BadRequest();

            var todoItem = _todoRepository.Find(id);
            if (todoItem == null)
                return NotFound();

            _todoRepository.Update(item);
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _todoRepository.Find(id);
            if (item == null)
                return BadRequest();

            _todoRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
