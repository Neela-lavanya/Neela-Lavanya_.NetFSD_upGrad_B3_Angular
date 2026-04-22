using System.ComponentModel.DataAnnotations;

public class OrderItemDTO
{
    [Required(ErrorMessage = "ProductId is required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
    public int Quantity { get; set; }
}
