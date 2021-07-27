using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
    public class StudentList
    {
        public int Id { get; set; }
        [Required, Display(Name = "First")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last")]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Level")]
        public Grade GradeLevel { get; set; }
        [Required, Display(Name = "Home Room")]
        public string Room { get; set; }
    }
}
