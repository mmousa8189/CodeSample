using System.Data.Entity;

namespace Infrastructure
{

    public class DatabaseFactory<T> : Disposable, IDatabaseFactory<T>
    where T : DbContext, new()
    {
        private T _dataContext;

        public T Get()
        {
            return _dataContext ?? (_dataContext = new T());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
