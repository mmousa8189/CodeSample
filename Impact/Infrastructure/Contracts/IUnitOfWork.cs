namespace Infrastructure
{
    public interface IUnitOfWork<T>
    {
        void Commit();
    }
}
