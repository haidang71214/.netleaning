using docNetCore1.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace docNetCore1.Repository
{
    // cho nos implement cái này
    public class MongoDbTodoRepository : ITodoRepository
    {
        // làm xong thì nhớ thêm cái này vô để truy xuất
        private readonly IMongoCollection<TodoItem> collection;

        public MongoDbTodoRepository(IConfiguration configuration) {
            var client = new MongoClient(configuration.GetConnectionString("fuckThisdotNet")); // client, database và collection(tự như table)
            var database = client.GetDatabase("dumamaydotnet");
            this.collection = database.GetCollection<TodoItem>("TodoItemCollection");
        }
        // test kết nối 
        public MongoDbTodoRepository(string connectionString, string databaseName) {
            var client = new MongoClient(connectionString); // client, database và collection(tự như table)
            var database = client.GetDatabase("dumamaydotnet");
            this.collection = database.GetCollection<TodoItem>("TodoItemCollection");
        }
        public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
        {
             await collection.InsertOneAsync(todoItem);
            return todoItem;
        }

        public async Task<TodoItem?> GetToDoListItemAsync(Guid id)
        {
            return await collection.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetToDoListItemAsync()
        {
            return await collection.Find(item => true).ToListAsync();
        }
    }
    // bất kì thằng nào implement interface thì luôn cần có hàm :

}
