using Messenger.Api.Constants;
using Messenger.Api.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Messenger.Api.Database
{
    public class DatabaseClient : IDatabaseClient
    {
        private readonly IMongoDatabase _database;
        public DatabaseClient(IConfiguration configuration)
        {
            var client = new MongoClient(configuration[DatabaseSettings.ConnectionString]);
            _database = client.GetDatabase(configuration[DatabaseSettings.DatabaseName]);
        }
        private IMongoCollection<BsonDocument> GetCollection<T>() where T : class, IRepositoryItem
        {
            return _database.GetCollection<BsonDocument>(typeof(T).Name);
        }
        public async Task<T> InsertItemAsync<T>(T item) where T : class, IRepositoryItem
        {
            var collection = GetCollection<T>();
            var itemInBsonDocument = item.ToBsonDocument();
            await collection.InsertOneAsync(itemInBsonDocument);
            return item;
        }
        public async Task<T> UpdateItemAsync<T>(T item) where T : class, IRepositoryItem
        {
            var collection = GetCollection<T>();
            var itemInBsonDocument = item.ToBsonDocument();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", item.Id);
            await collection.ReplaceOneAsync(filter, itemInBsonDocument);
            return item;
        }
        public async Task DeleteItemByIdAsync<T>(string id) where T : class, IRepositoryItem
        {
            var collection = GetCollection<T>();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            await collection.DeleteOneAsync(filter);
        }
        public async Task<T> GetItemByIdAsync<T>(string id) where T : class, IRepositoryItem
        {
            var collection = GetCollection<T>();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var item = await collection.Find(filter).FirstOrDefaultAsync();
            return BsonSerializer.Deserialize<T>(item);

        }
        public async Task<List<T>> GetItemsAsync<T>() where T : class, IRepositoryItem
        {
            var collection = GetCollection<T>();
            var bsonDocuments = await collection.FindAsync(item => true);
            var items = bsonDocuments.ToList();
            return BsonSerializer.Deserialize<List<T>>(items.ToJson());
        }
    }
}
