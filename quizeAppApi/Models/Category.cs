using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using quizeAppApi.Services.Interface;

namespace quizeAppApi.Models
{
    public class Category
    {

        public Category() {  
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public string? ImageUrl { get; set; } = String.Empty;



    }
}
