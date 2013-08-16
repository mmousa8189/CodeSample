using System;
using System.Data.Entity;


namespace Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext, new()
    {
        private readonly IDatabaseFactory<T> _databaseFactory;
        private T _dataContext;

        public UnitOfWork()
        {

        }

        public UnitOfWork(IDatabaseFactory<T> databaseFactory)
        {
            this._databaseFactory = databaseFactory;
            _dataContext = _databaseFactory.Get();
        }

        protected T DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
