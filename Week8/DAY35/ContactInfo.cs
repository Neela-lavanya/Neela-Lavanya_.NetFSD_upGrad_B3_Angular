using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        [Required]
        public string? Designation { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Company")]
        public int CompanyId { get; set; }

        public int? DepartmentId { get; set; }

        public string? CompanyName { get; set; }
        public string? DepartmentName { get; set; }
    }
}