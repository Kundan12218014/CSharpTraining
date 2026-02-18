namespace OnlineLearningPlatform.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T entity)
        {
            _items.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(Func<T, bool> predicate)
        {
            return _items.FirstOrDefault(predicate);
        }
    }
}
