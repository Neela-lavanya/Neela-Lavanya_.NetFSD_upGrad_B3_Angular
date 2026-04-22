using BackendProject.DTOs;
using BackendProject.Models;

namespace BackendProject.Services
{
    public interface IProductService
    {

        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(ProductDTO dto);
        Task UpdateAsync(int id, ProductDTO dto);
        Task DeleteAsync(int id);
    }
}
