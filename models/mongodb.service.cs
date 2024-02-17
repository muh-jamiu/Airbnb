using MongoDB.Bson;
using MongoDB.Driver;
using Users.models;
using Microsoft.Extensions.Options;

namespace Users.service
{
    public class MongoDBService
    {
        private readonly IMongoCollection<UsersModel> _UserCollection;
        private readonly IMongoCollection<Product> _Product;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DBName);
            _UserCollection = database.GetCollection<UsersModel>(mongoDBSettings.Value.CollectionName);
            _Product = database.GetCollection<Product>(mongoDBSettings.Value.CollectionName);
        }

        public async Task RegisteUserAsync(UsersModel user)
        {
            await _UserCollection.InsertOneAsync(user);
            return;
        }

        public async Task<List<UsersModel>> GetTaskAsync()
        {
            return await _UserCollection.Find(_ => true).ToListAsync();
        }

        public async Task<List<UsersModel>> GetUserByIdAsync(string id)
        {
            return await _UserCollection.Find(_ => _.id == id).ToListAsync();
        }

         public async Task<string> UpdateUserAsync(string id, UsersModel user)
        {
            FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Eq("id", id);
            UpdateDefinition<UsersModel> update = Builders<UsersModel>.Update
            .Set("name", user.name)
            .Set("email", user.email)
            .Set("password", user.password)
            .Set("phone", user.phone);

            await _UserCollection.UpdateOneAsync(filter, update);
            return "User is updated";
            
        }

         public async Task<string> DeleteUserAsync(string id)
        {
            FilterDefinition<UsersModel> filter = Builders<UsersModel>.Filter.Eq("id", id);
            await _UserCollection.DeleteOneAsync(filter);
            return "User is deleted successfully";
            
        }

    }
}