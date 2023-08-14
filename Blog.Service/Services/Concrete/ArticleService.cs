using Blog.Dal.UnitOfWorks.Abstract;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfwork;

        public ArticleService(IUnitOfWork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }

        public async Task<List<Article>> GetAllArticleSync()
        {
            return await unitOfwork.GetRepository<Article>().GetAllAsync();
        }
    }
}
