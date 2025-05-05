using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Payment
    {
        [Key]
        public int Pid { get; set; }
       
        [Required]
        public int Uid { get; set; }
        [Required(ErrorMessage = "Account Number required.")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "IFSC is required.")]
        public string IFSC { get; set; }
        [Required(ErrorMessage = "UPI is required.")]
        public string UPI { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        public string Amount { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
