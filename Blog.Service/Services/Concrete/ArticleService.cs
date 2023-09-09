using AutoMapper;
using Blog.Dal.UnitOfWorks.Abstract;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfwork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            this.unitOfwork = unitOfwork;
            this.mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userid = Guid.Parse("643B7BCC-E8AB-4321-A7EB-0E3D3D88795B");
            var article = new Article
            {
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                CategoryId = articleAddDto.CategoryId,
                UserId = userid
            };
            await unitOfwork.GetRepository<Article>().AddAsync(article);
            await unitOfwork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfwork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

    }
}
