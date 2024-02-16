namespace Users.models
{
    public class MongoDBSettings {
        public string ConnectionURI { get; set; } = null!;
        public string DBName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}