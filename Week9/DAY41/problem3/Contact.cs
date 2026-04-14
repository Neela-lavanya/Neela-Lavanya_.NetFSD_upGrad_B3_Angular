using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
