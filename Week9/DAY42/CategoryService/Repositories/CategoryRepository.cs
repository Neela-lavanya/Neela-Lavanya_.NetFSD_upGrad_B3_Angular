using CategoryService.Data;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetById(int id)
            => await _context.Categories.FindAsync(id);

        public async Task<Category> Add(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return false;

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
