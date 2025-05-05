using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Food
    {
        [Key]
        public int Fid { get; set; }
        [Required(ErrorMessage = "Food Type is required.")]
        public string FoodType { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Time is required.")]
        public string Time { get; set; }
        [Required]
        public string Suggestion { get; set; }
        [Required]

        public string Status { get; set; }
    }
}
