using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using quizeAppApi.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace quizeAppApi.Models
{
    public class User
    {
        public User() {
            Id = ObjectId.GenerateNewId().ToString();
            Role = RoleOfUser.User;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleOfUser Role { get; set; }
    }
}
