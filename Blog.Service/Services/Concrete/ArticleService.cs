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
        //Yeni makaleleri db'ye kaydeden metot
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
        //Kategorisi silinmeyen Makaleleri getiren metot
        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfwork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleid)
        {
            var article = await unitOfwork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleid, x => x.Category);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
        //Güncelleme metotu
        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitOfwork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;

            await unitOfwork.GetRepository<Article>().UpdateAsync(article);
            await unitOfwork.SaveAsync();

        }
        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfwork.GetRepository<Article>().GetGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedTime = DateTime.Now;
            await unitOfwork.GetRepository<Article>().UpdateAsync(article);
            await unitOfwork.SaveAsync();


        }

    }
}
