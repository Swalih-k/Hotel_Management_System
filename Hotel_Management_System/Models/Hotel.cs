using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Hotel
    {
        [Key]
        public int Hid { get; set; }
        [Required(ErrorMessage = "Hotel Name is required.")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "Place is required.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Rating is required.")]
        public int Rating { get; set; }
        
    }
}
