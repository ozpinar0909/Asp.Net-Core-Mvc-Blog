using Blog.Dal.Context;
using Blog.Dal.UnitOfWorks.Abstract;
using Blog.Entity.Abstract;
using Blog.Entity.Concrete;

namespace Blog.Dal.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext dbContext;

        public UnitOfWork(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();

        }

        public Task<int> SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }
    }
}
