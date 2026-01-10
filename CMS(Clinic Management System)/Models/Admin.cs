using System.ComponentModel.DataAnnotations;

namespace CMS_Clinic_Management_System_.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
        public string? Image { get; set; }

    }
}
