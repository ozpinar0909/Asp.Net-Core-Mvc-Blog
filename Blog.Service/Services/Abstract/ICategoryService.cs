using Blog.Entity.DTOs.Categories;

namespace Blog.Service.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
    }
}
