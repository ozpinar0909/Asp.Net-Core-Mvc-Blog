using Blog.Entity.DTOs.Articles;

namespace Blog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
    }
}
