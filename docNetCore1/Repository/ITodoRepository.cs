
using docNetCore1.Models;

namespace docNetCore1.Repository
{
    public interface ITodoRepository
    {
        // định nghĩa kiểu trả về ở đây luôn
        // IEnumerable định nghĩa tập hợp cho foreach, chính xác thì như cái list
        Task<TodoItem?> GetToDoListItemAsync(Guid id);
        Task<IEnumerable<TodoItem>> GetToDoListItemAsync();
        Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
    }
}
