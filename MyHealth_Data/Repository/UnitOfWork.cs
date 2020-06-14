
using MyHealth_Data.Model;


namespace MyHealth_Data.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        public HealthContext Context { get; }

    public UnitOfWork(HealthContext context)
    {
        Context = context;
    }
    public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Context.Dispose();

    }

}
    
}
