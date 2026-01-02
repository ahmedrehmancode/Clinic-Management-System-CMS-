using System.ComponentModel.DataAnnotations;

namespace CMS_Clinic_Management_System_.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone required")]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
    }
}
