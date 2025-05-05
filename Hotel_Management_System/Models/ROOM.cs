using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class ROOM
    {
        [Key]
        public int Rid { get; set; }


        [Required(ErrorMessage = "Room Type is required.")]
        public string RoomType { get; set; }


        [Required(ErrorMessage = "Room Capacity is required.")]
        public string Capacity { get; set; }

        [Required]
        public string CheckInDate { get; set; }
        [Required]
        public string CheckOutDate { get; set; }
        [Required]
        public int Hid { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
