using System.Threading.Tasks;
using docNetCore1.Models;
using docNetCore1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace docNetCore1.Controllers
{
    [Route("api/todoitem")]
    [ApiController]
    public class TodoController : ControllerBase
    {   
        private readonly ITodoRepository  todoRepository;
        public TodoController(ITodoRepository todoRepository) {
            this.todoRepository = todoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetToDoListItem() {
            return Ok(await todoRepository.GetToDoListItemAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetaiItem(Guid  id) {
            return Ok(await todoRepository.GetToDoListItemAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoItem todoItem) {
            return Ok(await todoRepository.CreateTodoItemAsync(todoItem));
        }
    }

}
