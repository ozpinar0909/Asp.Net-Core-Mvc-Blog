using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService article;

        public HomeController(IArticleService article)
        {
            this.article = article;
        }
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var articles = await article.GetAllArticleSync();
            return View(articles);
        }
    }
}
