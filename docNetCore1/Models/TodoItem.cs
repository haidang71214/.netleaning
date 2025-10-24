using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace docNetCore1.Models
{
    // Represents a to-do item.
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
