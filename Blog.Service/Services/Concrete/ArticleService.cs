﻿using AutoMapper;
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

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfwork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

    }
}
