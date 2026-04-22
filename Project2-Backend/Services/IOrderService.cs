using BackendProject.DTOs;

namespace BackendProject.Services
{
    public interface IOrderService
    {
        Task<object> CreateOrderAsync(OrderDTO dto, int userId);
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(int id);
    }
}