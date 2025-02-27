
namespace FlashWish.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T? GetById(int id);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}
