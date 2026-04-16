using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Category>> GetAll() => _repo.GetAll();

        public Task<Category?> GetById(int id) => _repo.GetById(id);

        public Task<Category> Add(Category category) => _repo.Add(category);

        public Task<Category> Update(Category category) => _repo.Update(category);

        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}
