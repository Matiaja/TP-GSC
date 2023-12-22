namespace Backend.API.DataAccess.Generic
{
    public interface IRepository<T> where T : class
    {
        public T? GetOne(int id);
        public List<T> GetAll();

        public T Add(T entity);

        public T Update(T entity);

        public void Delete(int id);

    }
}
