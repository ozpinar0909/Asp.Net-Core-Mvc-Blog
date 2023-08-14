using Blog.Core.Entities;
using Blog.Entity.Abstract;

namespace Blog.Dal.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();

    }
}
