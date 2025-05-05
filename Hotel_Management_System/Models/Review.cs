using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Review
    {
        [Key]
        public int Reviewid { get; set; }

       
        [Required(ErrorMessage = "Review is required.")]
        public string Reviews {get; set; }
        [Required]
        public int Hid { get; set; }
        [Required]
        public string Replay { get; set; }
    }
}
