using Blog.Bll.Abstract;
using Blog.Core.Entities;
using Blog.Dal.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Bll.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly BlogDbContext dbContext;

        public Repository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        //Silinmeyen makaleleri ve benzeri functionları burada tanımlıyoruz.
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            return await query.ToListAsync();

        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            return await query.SingleAsync();

        }
        //Tablodaki guid'yi burdan buluyoruz.
        public async Task<T> GetGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);

        }
        //tablodaki alanı güncelleme işlemi
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        //tablodaki alanı silme işlemi
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return Table.AnyAsync(predicate);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return Table.CountAsync(predicate);
        }
    }
}
