using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Users.models{
    public class Product{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string price { get; set; } = null!;
        
        public string owner { get; set; }

    }
}