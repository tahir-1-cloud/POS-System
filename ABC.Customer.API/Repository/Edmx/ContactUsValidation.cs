using System.ComponentModel.DataAnnotations;

namespace ABC.Customer.API.Repository.Edmx
{
    public class ContactUsValidation
    {
        [Required(ErrorMessage ="Name is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]

        public string Message { get; set; }
    }
    [MetadataType(typeof(ContactUsValidation))]

    public partial class Contact
    {
    }
}
