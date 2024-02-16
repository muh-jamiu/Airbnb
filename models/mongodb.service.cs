using MongoDB.Bson;
using MongoDB.Driver;
using Users.models;
using Microsoft.Extensions.Options;

namespace Users.service
{
    public class MongoDBService{
        private readonly IMongoCollection<UsersModel> _UserCollection = null!;

        public MongoDBService(IOptions<MongoDBSettings>  mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DBName);
            _UserCollection = database.GetCollection<UsersModel>(mongoDBSettings.Value.CollectionName);
        } 
        
    }
}