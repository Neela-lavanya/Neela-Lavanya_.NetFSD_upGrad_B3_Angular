using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string EmailId { get; set; }
        

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10-digit Mobile Number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
    }
}