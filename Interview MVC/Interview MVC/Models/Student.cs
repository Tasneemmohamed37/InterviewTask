using System.ComponentModel.DataAnnotations;

namespace Interview_MVC.Models
{
    public class Student
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Phone number must be 11 digit only!")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
