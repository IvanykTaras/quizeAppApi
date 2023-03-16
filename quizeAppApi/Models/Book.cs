using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace quizeAppApi.Models
{
    public class Book
    {

        public Book()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
