
using MyHealth_Data.Model;
using System;


namespace MyHealth_Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        HealthContext Context { get; }
        void Commit();
    }
}
