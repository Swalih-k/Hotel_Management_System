using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Log
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
