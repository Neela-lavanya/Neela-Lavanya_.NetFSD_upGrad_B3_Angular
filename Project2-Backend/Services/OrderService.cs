using BackendProject.DTOs;
using BackendProject.Models;
using BackendProject.Repositories;

namespace BackendProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        // CREATE ORDER
        public async Task<object> CreateOrderAsync(OrderDTO dto, int userId)
        {
            if (dto == null || dto.Items == null || dto.Items.Count == 0)
                return new { message = "Items required" };

            var orderItems = new List<OrderItem>();

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);

                if (product == null)
                    return new { message = "Product not found" };

                if (item.Quantity <= 0)
                    return new { message = "Invalid quantity" };

                if (product.Stock < item.Quantity)
                    return new { message = "Not enough stock" };

                product.Stock -= item.Quantity;
                await _productRepo.UpdateAsync(product);

                orderItems.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price * item.Quantity
                });
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                OrderItems = orderItems,
                TotalAmount = orderItems.Sum(x => x.Price)
            };

            await _orderRepo.CreateAsync(order);

            return new
            {
                message = "Order created successfully",
                order.OrderId,
                order.TotalAmount
            };
        }

        // GET ALL
        public async Task<object> GetAllAsync()
        {
            var orders = await _orderRepo.GetAllAsync();

            return orders.Select(o => new
            {
                o.OrderId,
                o.UserId,
                o.OrderDate,
                o.TotalAmount,
                Items = o.OrderItems.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product.Name,
                    i.Quantity,
                    i.Price
                })
            });
        }

        // GET BY ID
        public async Task<object> GetByIdAsync(int id)
        {
            var o = await _orderRepo.GetByIdAsync(id);

            if (o == null) return null;

            return new
            {
                o.OrderId,
                o.UserId,
                o.OrderDate,
                o.TotalAmount,
                Items = o.OrderItems.Select(i => new
                {
                    i.ProductId,
                    ProductName = i.Product.Name,
                    i.Quantity,
                    i.Price
                })
            };
        }
    }
}