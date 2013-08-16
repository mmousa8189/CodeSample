using System;

namespace Infrastructure
{
    public interface IDatabaseFactory<T> : IDisposable
    {
         T Get();
    }
}
