using System.ComponentModel.DataAnnotations;

namespace CMS_Clinic_Management_System_.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]      
        public string CategoryName { get; set; }

        


    }
}
