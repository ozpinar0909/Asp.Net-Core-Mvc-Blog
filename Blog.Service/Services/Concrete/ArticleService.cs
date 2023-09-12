using AutoMapper;
using Blog.Dal.UnitOfWorks.Abstract;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfwork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfwork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfwork = unitOfwork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        //Yeni makaleleri db'ye kaydeden metot
        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            //var userid = Guid.Parse("643B7BCC-E8AB-4321-A7EB-0E3D3D88795B");
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageid = Guid.Parse("184BAF77-DE82-4DA0-8D25-7CC577FB58C1");
            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, imageid);
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
        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfwork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;
            article.ModifiedTime = DateTime.Now;
            article.ModifiedBy = userEmail;

            await unitOfwork.GetRepository<Article>().UpdateAsync(article);
            await unitOfwork.SaveAsync();
            return article.Title;

        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfwork.GetRepository<Article>().GetGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedTime = DateTime.Now;
            article.DeletedBy = userEmail;
            await unitOfwork.GetRepository<Article>().UpdateAsync(article);
            await unitOfwork.SaveAsync();
            return article.Title;


        }

    }
}
