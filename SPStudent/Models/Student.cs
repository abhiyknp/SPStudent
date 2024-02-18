using System.ComponentModel.DataAnnotations;

namespace SPStudent.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Course { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
  
    }
}
