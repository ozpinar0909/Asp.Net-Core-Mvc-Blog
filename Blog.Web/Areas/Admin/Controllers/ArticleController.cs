﻿using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var article = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(article);
        }
        //Dropdown'da kategorileri çağırdığımız yer
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        // Makaleleri eklediğimiz metotları burada yazıyoruz
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
            }
        }

        //Update çağırdığımız yer
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleid)
        {
            var article = await articleService.GetArticlesWithCategoryNonDeletedAsync(articleid);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            await articleService.UpdateArticleAsync(articleUpdateDto);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await articleService.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

    }
}
