using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService article;

        public HomeController(IArticleService article)
        {
            this.article = article;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await article.GetAllArticleSync();
            return View(articles);
        }
    }
}
