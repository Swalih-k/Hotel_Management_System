using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Staff
    {
        [Key]
        public int Sid { get; set; }
        [Required(ErrorMessage = "Staff Name is required.")]
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Position is required.")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
       
    }
}
