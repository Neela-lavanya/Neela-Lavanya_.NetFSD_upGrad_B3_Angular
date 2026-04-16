using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category?> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Delete(int id);
    }
}