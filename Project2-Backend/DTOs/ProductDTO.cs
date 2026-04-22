using System.ComponentModel.DataAnnotations;

namespace BackendProject.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }
    }
}
