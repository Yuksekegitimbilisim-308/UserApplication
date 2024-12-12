namespace UserApplication.Repository.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IQueryable<T> GetQueryable();
        Task<T> Add(T entity);
        Task Delete(int id);
        Task<T> Update(T entity);
    }
}
