namespace OnlineLearningPlatform.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(Func<T, bool> predicate);
    }
}
