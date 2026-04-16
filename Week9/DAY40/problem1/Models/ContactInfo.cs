using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [Range(1000000000, 9999999999)]
        public long MobileNo { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}