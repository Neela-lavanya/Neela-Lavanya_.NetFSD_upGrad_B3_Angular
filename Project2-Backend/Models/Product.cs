using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 100000, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Image URL is required")]
    public string ImageUrl { get; set; } = string.Empty;

    [Range(0, 1000, ErrorMessage = "Stock must be 0 or more")]
    public int Stock { get; set; }

    // Navigation property
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}