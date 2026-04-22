using System.ComponentModel.DataAnnotations;

public class Order
{
    public int OrderId { get; set; }

    [Required(ErrorMessage = "UserId is required")]
    public int UserId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Range(1, 1000000, ErrorMessage = "Total amount must be greater than 0")]
    public decimal TotalAmount { get; set; }

    // Navigation property
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}