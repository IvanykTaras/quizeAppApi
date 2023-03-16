using MongoDB.Driver;

namespace quizeAppApi.Services.Interface
{
    public interface IService<T>
    {
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(string id);
        Task CreateAsync(T item);
        Task UpdateAsync(string id, T item);
        Task RemoveAsync(string id);
    }
}
