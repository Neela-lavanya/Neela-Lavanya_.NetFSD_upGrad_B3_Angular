using BackendProject.DTOs;
using BackendProject.Models;
using BackendProject.Repositories;

namespace BackendProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(ProductDTO dto)
        {
            if (dto == null) return;

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };

            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(int id, ProductDTO dto)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null) return;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Stock = dto.Stock;

            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null) return;

            await _repo.DeleteAsync(product);
        }
    }
}
