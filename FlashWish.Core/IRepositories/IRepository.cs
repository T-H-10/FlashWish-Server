
namespace FlashWish.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        T Add(T entity);
        T Update(int id, T entity);
        void Delete(T entity);
    }
}
