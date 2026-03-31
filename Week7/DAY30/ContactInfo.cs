using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "ID is required")]
        [Range(1, 1000, ErrorMessage = "ID must be between 1 and 1000")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "Max 20 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [Range(6000000000, 9999999999, ErrorMessage = "Enter valid mobile number")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(30)]
        public string Designation { get; set; }
    }
}