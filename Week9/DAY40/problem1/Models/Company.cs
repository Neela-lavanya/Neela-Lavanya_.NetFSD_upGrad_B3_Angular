using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
