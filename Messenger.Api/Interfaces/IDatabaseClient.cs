namespace Messenger.Api.Interfaces
{
    public interface IDatabaseClient
    {
        Task<T> InsertItemAsync<T>(T item) where T : class, IRepositoryItem;
        Task<T> UpdateItemAsync<T>(T item) where T : class, IRepositoryItem;
        Task DeleteItemByIdAsync<T>(string id) where T : class, IRepositoryItem;
        Task<T> GetItemByIdAsync<T>(string id) where T : class, IRepositoryItem;
        Task<List<T>> GetItemsAsync<T>() where T : class, IRepositoryItem;
    }
}
