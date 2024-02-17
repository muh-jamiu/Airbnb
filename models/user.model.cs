using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Users.models{
    public class UsersModel{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string phone { get; set; } = null!;
        public string password { get; set; } = null!;

        public List<Product>? purchase { get; set; }
        
        public List<Product>? product { get; set; }

    }
}