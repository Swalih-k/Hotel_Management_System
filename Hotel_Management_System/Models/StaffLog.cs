using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class StaffLog
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
