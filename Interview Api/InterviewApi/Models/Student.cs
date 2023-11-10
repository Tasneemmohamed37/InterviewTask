using System.ComponentModel.DataAnnotations;

namespace InterviewApi.Models
{
    public class Student
    {
        [Key]
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
