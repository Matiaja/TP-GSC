namespace Backend.API.DataAccess.Generic
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetOne(int id);
        public Task<List<T>?> GetAll();

        public Task<int> Add(T entity);

        public Task Update(T entity);

        public Task Delete(int id);

    }
}
