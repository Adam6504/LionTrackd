using MongoDB.Driver;
using LionTrackdAPI.Configuration;
using LionTrackdAPI.Models;
using Microsoft.Extensions.Options;

namespace LionTrackdAPI.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Item> _itemsCollection;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly MongoClient _mongoClient;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _itemsCollection = _mongoDatabase.GetCollection<Item>("items");
        }

        // Test database connection
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                // Ping the database to verify connection
                await _mongoDatabase.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Get all items
        public async Task<List<Item>> GetAsync() =>
            await _itemsCollection.Find(_ => true).ToListAsync();

        // Get item by ID
        public async Task<Item?> GetAsync(string id) =>
            await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Create new item
        public async Task CreateAsync(Item newItem)
        {
            newItem.CreatedAt = DateTime.UtcNow;
            newItem.UpdatedAt = DateTime.UtcNow;
            await _itemsCollection.InsertOneAsync(newItem);
        }

        // Update existing item
        public async Task UpdateAsync(string id, Item updatedItem)
        {
            updatedItem.UpdatedAt = DateTime.UtcNow;
            await _itemsCollection.ReplaceOneAsync(x => x.Id == id, updatedItem);
        }

        // Delete item
        public async Task RemoveAsync(string id) =>
            await _itemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
