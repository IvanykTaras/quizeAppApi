using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quizeAppApi.Models
{
    public class Question
    {

        public Question() { 
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? TextOfQuestion { get; set; }
        public string? TextOfAnswer { get; set; }
        public string? ImageUrl { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        
    }
}

