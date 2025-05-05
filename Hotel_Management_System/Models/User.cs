using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }
        [Required(ErrorMessage = " Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
