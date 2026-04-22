namespace BackendProject.DTOs
{
    public class OrderDTO
    {
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}